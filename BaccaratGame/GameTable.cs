using Play;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BaccaratGame
{
    public partial class GameTable : Form
    {
        Shoe S = new Shoe();
        Hand H = new Hand();
        PictureBox[] ShoeBoxes = new PictureBox[11];
        PictureBox[] PlayerBoxes = new PictureBox[3];
        PictureBox[] BankerBoxes = new PictureBox[3];
        Player[] players = new Player[4];
        int[] playerStates = { 0, 0, 0, 0 };
        Boolean PLAYER = true; Boolean BANKER = false;
        int GameState = 1;


        public GameTable()
        {
            InitializeComponent();
            int i;
            ShoeBoxes[0] = ShoeBox0; ShoeBoxes[1] = ShoeBox1; ShoeBoxes[2] = ShoeBox2; ShoeBoxes[3] = ShoeBox3;
            ShoeBoxes[4] = ShoeBox4; ShoeBoxes[5] = ShoeBox5; ShoeBoxes[6] = ShoeBox6; ShoeBoxes[7] = ShoeBox7;
            ShoeBoxes[8] = ShoeBox8; ShoeBoxes[9] = ShoeBox9; ShoeBoxes[10] = ShoeBox10;
            PlayerBoxes[0] = PlayerBox0; PlayerBoxes[1] = PlayerBox1; PlayerBoxes[2] = PlayerBox2;
            BankerBoxes[0] = BankerBox0; BankerBoxes[1] = BankerBox1; BankerBoxes[2] = BankerBox2;
            for (i = 0; i < ShoeBoxes.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[53]; }
            for (i = 0; i < PlayerBoxes.Length; i++) { PlayerBoxes[i].Image = PlayingCardsList.Images[53]; }
            for (i = 0; i < BankerBoxes.Length; i++) { BankerBoxes[i].Image = PlayingCardsList.Images[53]; }
            panel1.Enabled = false; panel2.Enabled = false; panel3.Enabled = false; panel4.Enabled = false;

            //TODO: test player, remove after implimenting player add function
            //players[0] = new Player("Test", 10, "empty");
            //players[0].FundsChanged += FundBoxPlayer1_FundsChanged;
            //players[0].Funds = 11;
        }

        private void GameControlButton_Click(object sender, EventArgs e)
        {
            switch (GameState)
            {
                case 1:
                    if (NoPlayerAtTable()) { break; }
                    if (BustedPlayerAtTable()) { break; }
                    if (playerStates[0] == 2) { panel1.Enabled = true; }
                    if (playerStates[1] == 2) { panel2.Enabled = true; }
                    if (playerStates[2] == 2) { panel3.Enabled = true; }
                    if (playerStates[3] == 2) { panel4.Enabled = true; }
                    Seat1ControlButton.Enabled = false;
                    Seat2ControlButton.Enabled = false;
                    Seat3ControlButton.Enabled = false;
                    Seat4ControlButton.Enabled = false;
                    GameState = 2;
                    GameControlButton.Text = "Play";
                    break;
                case 2:
                    if (NoBetMadeAtTable()) { break; }
                    int i;
                    //Checking the conditions of the shoe
                    ResetShoeBoxes();
                    if (S.CheckCutCard())
                    {
                        int[] CardD = S.DrainingShoe();
                        for (i = 0; i < CardD.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[CardD[i]]; }
                    }
                    ResetShoeBoxes();
                    if (S.Position() == 0)
                    {
                        int[] CardP = S.PrimingShoe();
                        ShoeBoxes[0].Image = PlayingCardsList.Images[CardP[0]];
                        for (i = 1; i < CardP.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[52]; }
                    }
                    //Play a hand for the Player and Banker
                    int[] CardH = new int[4];
                    for (i = 0; i < CardH.Length; i++) { CardH[i] = S.PickCard(); }
                    H.DistributeFourCards(CardH);
                    if (H.NoNaturalHand())
                    {
                        if (H.NeedPlayerThirdCard()) { H.GetThirdCard(S.PickCard(), PLAYER); }
                        if (H.NeedBankerThirdCard()) { H.GetThirdCard(S.PickCard(), BANKER); }
                    }
                    H.DetermineWinningHand();
                    ShoeProgressBar.Value = 100 * (S.DeckN() * S.CardN() - S.Position()) / (S.DeckN() * S.CardN());
                    //Summarizing the result of the play
                    Boolean[] ThirdCard = H.ThirdCard();
                    int[] PlayerH = H.Player();
                    int[] BankerH = H.Banker();
                    int[] Scores = H.Scores();
                    ResetShoeBoxes();
                    for (i = 0; i < PlayerBoxes.Length; i++) { PlayerBoxes[i].Image = PlayingCardsList.Images[53]; }
                    for (i = 0; i < BankerBoxes.Length; i++) { BankerBoxes[i].Image = PlayingCardsList.Images[53]; }
                    ShoeBoxes[0].Image = PlayingCardsList.Images[PlayerH[0]]; ShoeBoxes[1].Image = PlayingCardsList.Images[BankerH[0]];
                    ShoeBoxes[2].Image = PlayingCardsList.Images[PlayerH[1]]; ShoeBoxes[3].Image = PlayingCardsList.Images[BankerH[1]];
                    if (ThirdCard[0]) { ShoeBoxes[4].Image = PlayingCardsList.Images[PlayerH[2]]; }
                    if (ThirdCard[1])
                    {
                        if (!ThirdCard[0]) { ShoeBoxes[4].Image = PlayingCardsList.Images[BankerH[2]]; }
                        else { ShoeBoxes[5].Image = PlayingCardsList.Images[BankerH[2]]; }
                    }
                    PlayerBoxes[0].Image = PlayingCardsList.Images[PlayerH[0]]; PlayerBoxes[1].Image = PlayingCardsList.Images[PlayerH[1]];
                    BankerBoxes[0].Image = PlayingCardsList.Images[BankerH[0]]; BankerBoxes[1].Image = PlayingCardsList.Images[BankerH[1]];
                    if (ThirdCard[0]) { PlayerBoxes[2].Image = PlayingCardsList.Images[PlayerH[2]]; }
                    if (ThirdCard[1]) { BankerBoxes[2].Image = PlayingCardsList.Images[BankerH[2]]; }
                    PlayerScoreV.Text = Convert.ToString(Scores[0]);
                    BankerScoreV.Text = Convert.ToString(Scores[1]);
                    H.ResetHand();
                    GameState = 3;
                    GameControlButton.Text = "Settle bet";
                    break;
                case 3:
                    AdjustPlayersFunds();
                    ClearPlayerBets();
                    CheckForBustedPlayer();
                    if (playerStates[0] == 2) {
                        PlayerBetPlayer1.Value = PlayerBetPlayer1.Minimum;
                        DealerBetPlayer1.Value = DealerBetPlayer1.Minimum;
                        TieBetPlayer1.Value = TieBetPlayer1.Minimum;
                        panel1.Enabled = false; 
                    }
                    if (playerStates[1] == 2) {
                        PlayerBetPlayer2.Value = PlayerBetPlayer2.Minimum;
                        DealerBetPlayer2.Value = DealerBetPlayer2.Minimum;
                        TieBetPlayer2.Value = TieBetPlayer2.Minimum;
                        panel2.Enabled = false; 
                    }
                    if (playerStates[2] == 2) {
                        PlayerBetPlayer3.Value = PlayerBetPlayer3.Minimum;
                        DealerBetPlayer3.Value = DealerBetPlayer3.Minimum;
                        TieBetPlayer3.Value = TieBetPlayer3.Minimum;
                        panel3.Enabled = false;
                    }
                    if (playerStates[3] == 2) {
                        PlayerBetPlayer4.Value = PlayerBetPlayer3.Minimum;
                        DealerBetPlayer4.Value = DealerBetPlayer3.Minimum;
                        TieBetPlayer4.Value = TieBetPlayer4.Minimum;
                        panel4.Enabled = false; 
                    }
                    Seat1ControlButton.Enabled = true;
                    Seat2ControlButton.Enabled = true;
                    Seat3ControlButton.Enabled = true;
                    Seat4ControlButton.Enabled = true;
                    GameState = 1;
                    GameControlButton.Text = "Bet";
                    break;
                default: break;
            }
        }

        private Boolean NoPlayerAtTable() {
            if ((playerStates[0] + playerStates[1] + playerStates[2] + playerStates[3]) == 0) { return true; }
            else { return false; }
        }

        private Boolean BustedPlayerAtTable () {
            int Busted = 0;
            for (int i = 0; i < playerStates.Length; i++) { if (playerStates[i] == 1) { Busted++; } }
            if (Busted > 0) { return true;} else { return false; }
        }

        private void CheckForBustedPlayer() {
            if (playerStates[0] == 2) { if (players[0].Funds < 100) { playerStates[0] = 1; UpdatePlayerSitButtonText(); } }
            if (playerStates[1] == 2) { if (players[1].Funds < 100) { playerStates[1] = 1; UpdatePlayerSitButtonText(); } }
            if (playerStates[2] == 2) { if (players[2].Funds < 100) { playerStates[2] = 1; UpdatePlayerSitButtonText(); } }
            if (playerStates[3] == 2) { if (players[3].Funds < 100) { playerStates[3] = 1; UpdatePlayerSitButtonText(); } }
        }

        private Boolean NoBetMadeAtTable() {
            int ShyPlayer = 0;
            if ((playerStates[0] == 2)) {
                if ((PlayerBetPlayer1.Value + DealerBetPlayer1.Value + TieBetPlayer1.Value) == 0) { ShyPlayer++; }
            }
            if ((playerStates[1] == 2)) {
                if ((PlayerBetPlayer2.Value + DealerBetPlayer2.Value + TieBetPlayer2.Value) == 0) { ShyPlayer++; }
            }
            if ((playerStates[2] == 2)) {
                if ((PlayerBetPlayer3.Value + DealerBetPlayer3.Value + TieBetPlayer3.Value) == 0) { ShyPlayer++; }
            }
            if ((playerStates[3] == 2)) {
                if ((PlayerBetPlayer4.Value + DealerBetPlayer4.Value + TieBetPlayer4.Value) == 0) { ShyPlayer++; }
            }
            if (ShyPlayer > 0) { return true; } else { return false; }
        }

        private void AdjustPlayersFunds() {
            switch(H.Result()) {
                case 0:
                    if ((playerStates[0] == 2)) { 
                        players[0].Funds += (int)PlayerBetPlayer1.Value;
                        players[0].Funds -= (int)DealerBetPlayer1.Value;
                        players[0].Funds -= (int)TieBetPlayer1.Value;
                    }
                    if ((playerStates[1] == 2)) { 
                        players[1].Funds += (int)PlayerBetPlayer2.Value;
                        players[1].Funds -= (int)DealerBetPlayer2.Value;
                        players[1].Funds -= (int)TieBetPlayer2.Value;
                    }
                    if ((playerStates[2] == 2)) {
                        players[2].Funds += (int)PlayerBetPlayer3.Value;
                        players[2].Funds -= (int)DealerBetPlayer3.Value;
                        players[2].Funds -= (int)TieBetPlayer3.Value;
                    }
                    if ((playerStates[3] == 2)) { 
                        players[3].Funds += (int)PlayerBetPlayer4.Value;
                        players[3].Funds -= (int)DealerBetPlayer4.Value;
                        players[3].Funds -= (int)TieBetPlayer4.Value;
                    }
                    break;
                case 1:
                    if ((playerStates[0] == 2)) {
                        players[0].Funds -= (int)PlayerBetPlayer1.Value;
                        players[0].Funds += (int)(0.95 * (int)DealerBetPlayer1.Value);
                        players[0].Funds -= (int)TieBetPlayer1.Value;
                    }
                    if ((playerStates[1] == 2)) {
                        players[1].Funds -= (int)PlayerBetPlayer2.Value;
                        players[1].Funds += (int)(0.95 * (int)DealerBetPlayer2.Value);
                        players[1].Funds -= (int)TieBetPlayer2.Value;
                    }
                    if ((playerStates[2] == 2)) {
                        players[2].Funds -= (int)PlayerBetPlayer3.Value;
                        players[2].Funds += (int)(0.95 * (int)DealerBetPlayer3.Value);
                        players[2].Funds -= (int)TieBetPlayer3.Value;
                    }
                    if ((playerStates[3] == 2)) {
                        players[3].Funds -= (int)PlayerBetPlayer4.Value;
                        players[3].Funds += (int)(0.95 * (int)DealerBetPlayer4.Value);
                        players[3].Funds -= (int)TieBetPlayer4.Value;
                    }
                    break;
                case 2:
                    if ((playerStates[0] == 2)) {
                        players[0].Funds -= (int)PlayerBetPlayer1.Value;
                        players[0].Funds -= (int)DealerBetPlayer1.Value;
                        players[0].Funds += 8 * (int)TieBetPlayer1.Value; 
                    }
                    if ((playerStates[1] == 2)) {
                        players[1].Funds -= (int)PlayerBetPlayer2.Value;
                        players[1].Funds -= (int)DealerBetPlayer2.Value;
                        players[1].Funds += 8 * (int)TieBetPlayer2.Value; 
                    }
                    if ((playerStates[2] == 2)) {
                        players[2].Funds -= (int)PlayerBetPlayer3.Value;
                        players[2].Funds -= (int)DealerBetPlayer3.Value;
                        players[2].Funds += 8 * (int)TieBetPlayer3.Value; 
                    }
                    if ((playerStates[3] == 2)) {
                        players[3].Funds -= (int)PlayerBetPlayer4.Value;
                        players[3].Funds -= (int)DealerBetPlayer4.Value;
                        players[3].Funds += 8 * (int)TieBetPlayer4.Value; 
                    }
                    break;
                default: break;
            }
        }

        private void ResetShoeBoxes() { for (int i = 0; i < ShoeBoxes.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[53]; } }

        private void Seat1ControlButton_Click(object sender, EventArgs e)
        {
            int PlayerState = playerStates[0];
            switch (PlayerState)
            {
                case 0: ActivatePlayerSitForm(0, FundBoxPlayer1_FundsChanged); break;
                case 1: ActivatePlayerBustedForm(0); break;
                case 2: ActivatePlayerWithdrawForm(0); break;
                default: break;
            }
        }

        private void Seat2ControlButton_Click(object sender, EventArgs e)
        {
            int PlayerState = playerStates[1];
            switch (PlayerState)
            {
                case 0: ActivatePlayerSitForm(1, FundBoxPlayer2_FundsChanged); break;
                case 1: ActivatePlayerBustedForm(1); break;
                case 2: ActivatePlayerWithdrawForm(1); break;
                default: break;
            }
        }

        private void Seat3ControButton_Click(object sender, EventArgs e)
        {
            int PlayerState = playerStates[2];
            switch (PlayerState)
            {
                case 0: ActivatePlayerSitForm(2, FundBoxPlayer3_FundsChanged); break;
                case 1: ActivatePlayerBustedForm(2); break;
                case 2: ActivatePlayerWithdrawForm(2); break;
                default: break;
            }
        }

        private void Seat4ControlButton_Click(object sender, EventArgs e)
        {
            int PlayerState = playerStates[3];
            switch (PlayerState)
            {
                case 0: ActivatePlayerSitForm(3, FundBoxPlayer4_FundsChanged); break;
                case 1: ActivatePlayerBustedForm(3); break;
                case 2: ActivatePlayerWithdrawForm(3); break;
                default: break;
            }
        }

        public void ActivatePlayerSitForm(int P, EventHandler fundsChangedCallback)
        {
            PlayerSit SecondForm = new PlayerSit(P, players, fundsChangedCallback, playerStates);
            SecondForm.ShowDialog();
            UpdatePlayerSitButtonText();
        }

        public void ActivatePlayerBustedForm(int P)
        {
            PlayerBusted SecondForm = new PlayerBusted();
            SecondForm.ShowDialog();
        }

        public void ActivatePlayerWithdrawForm(int P)
        {
            PlayerWithdraw SecondForm = new PlayerWithdraw();
            SecondForm.ShowDialog();
        }

        public void UpdatePlayerSitButtonText()
        {

            for (int i = 0; i < playerStates.Length; i++)
            {
                int playerNumber = i + 1;
                String[] buttonTexts = { $"Seat {playerNumber} free", $"Player {playerNumber} Busted", $"Cashout Player {playerNumber}" };
                String controlName = $"Seat{playerNumber.ToString()}ControlButton";
                SitPlayerButtonsPanel.Controls.Find(controlName, false)[0].Text = buttonTexts[playerStates[i]];

            }
        }

        private void FundBoxPlayer1_FundsChanged(object sender, EventArgs e)
        {
            FundBoxPlayer1.Text = players[0].Funds.ToString();
        }
        private void FundBoxPlayer2_FundsChanged(object sender, EventArgs e)
        {
            FundBoxPlayer2.Text = players[1].Funds.ToString();
        }
        private void FundBoxPlayer3_FundsChanged(object sender, EventArgs e)
        {
            FundBoxPlayer3.Text = players[2].Funds.ToString();
        }
        private void FundBoxPlayer4_FundsChanged(object sender, EventArgs e)
        {
            FundBoxPlayer4.Text = players[3].Funds.ToString();
        }

        private void PlayerBetPlayer1_ValueChanged(object sender, EventArgs e)
        {
            int S = players[0].Funds - (int)DealerBetPlayer1.Value - (int)TieBetPlayer1.Value;
            if (PlayerBetPlayer1.Value > S) { PlayerBetPlayer1.Value -= PlayerBetPlayer1.Increment; }
            updateBet(0, PlayerBetPlayer1.Value, players[0]);
        }

        private void PlayerBetPlayer2_ValueChanged(object sender, EventArgs e)
        {
            int S = players[1].Funds - (int)DealerBetPlayer2.Value - (int)TieBetPlayer2.Value;
            if (PlayerBetPlayer2.Value > S) { PlayerBetPlayer2.Value -= PlayerBetPlayer2.Increment; }
            updateBet(0, PlayerBetPlayer2.Value, players[1]);
        }

        private void PlayerBetPlayer3_ValueChanged(object sender, EventArgs e)
        {
            int S = players[2].Funds - (int)DealerBetPlayer3.Value - (int)TieBetPlayer3.Value;
            if (PlayerBetPlayer3.Value > S) { PlayerBetPlayer3.Value -= PlayerBetPlayer3.Increment; }
            updateBet(0, PlayerBetPlayer3.Value, players[2]);
        }

        private void PlayerBetPlayer4_ValueChanged(object sender, EventArgs e)
        {
            int S = players[3].Funds - (int)DealerBetPlayer4.Value - (int)TieBetPlayer4.Value;
            if (PlayerBetPlayer4.Value > S) { PlayerBetPlayer4.Value -= PlayerBetPlayer4.Increment; }
            updateBet(0, PlayerBetPlayer4.Value, players[3]);
        }

        private void DealerBetPlayer1_ValueChanged(object sender, EventArgs e)
        {
            int S = players[0].Funds - (int)PlayerBetPlayer1.Value - (int)TieBetPlayer1.Value;
            if (DealerBetPlayer1.Value > S) { DealerBetPlayer1.Value -= DealerBetPlayer1.Increment; }
            updateBet(1, DealerBetPlayer1.Value, players[0]);
        }

        private void DealerBetPlayer2_ValueChanged(object sender, EventArgs e)
        {
            int S = players[1].Funds - (int)PlayerBetPlayer2.Value - (int)TieBetPlayer2.Value;
            if (DealerBetPlayer2.Value > S) { DealerBetPlayer2.Value -= DealerBetPlayer2.Increment; }
            updateBet(1, DealerBetPlayer2.Value, players[1]);
        }

        private void DealerBetPlayer3_ValueChanged(object sender, EventArgs e)
        {
            int S = players[2].Funds - (int)PlayerBetPlayer3.Value - (int)TieBetPlayer3.Value;
            if (DealerBetPlayer3.Value > S) { DealerBetPlayer3.Value -= DealerBetPlayer3.Increment; }
            updateBet(1, DealerBetPlayer3.Value, players[2]);
        }

        private void DealerBetPlayer4_ValueChanged(object sender, EventArgs e)
        {
            int S = players[3].Funds - (int)PlayerBetPlayer4.Value - (int)TieBetPlayer4.Value;
            if (DealerBetPlayer4.Value > S) { DealerBetPlayer4.Value -= DealerBetPlayer4.Increment; }
            updateBet(1, DealerBetPlayer4.Value, players[3]);
        }

        private void TieBetPlayer1_ValueChanged(object sender, EventArgs e)
        {
            int S = players[0].Funds - (int)PlayerBetPlayer1.Value - (int)DealerBetPlayer1.Value;
            if (TieBetPlayer1.Value > S) { TieBetPlayer1.Value -= TieBetPlayer1.Increment; }
            updateBet(2, TieBetPlayer1.Value, players[0]);
        }

        private void TieBetPlayer2_ValueChanged(object sender, EventArgs e)
        {
            int S = players[1].Funds - (int)PlayerBetPlayer2.Value - (int)DealerBetPlayer2.Value;
            if (TieBetPlayer2.Value > S) { TieBetPlayer2.Value -= TieBetPlayer2.Increment; }
            updateBet(2, TieBetPlayer2.Value, players[1]);
        }

        private void TieBetPlayer3_ValueChanged(object sender, EventArgs e)
        {
            int S = players[2].Funds - (int)PlayerBetPlayer3.Value - (int)DealerBetPlayer3.Value;
            if (TieBetPlayer3.Value > S) { TieBetPlayer3.Value -= TieBetPlayer3.Increment; }
            updateBet(2, TieBetPlayer3.Value, players[2]);
        }

        private void TieBetPlayer4_ValueChanged(object sender, EventArgs e)
        {
            int S = players[3].Funds - (int)PlayerBetPlayer4.Value - (int)DealerBetPlayer4.Value;
            if (TieBetPlayer4.Value > S) { TieBetPlayer4.Value -= TieBetPlayer4.Increment; }
            updateBet(2, TieBetPlayer4.Value, players[3]);
        }
        private void updateBet(int index, decimal value, Player player)
        {
            player.updateBet(index, (int)value);
        }

        private void ClearPlayerBets() {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] != null) { players[i].clearAllBets();}
            }
        }

        private void RulesButton_Click(object sender, EventArgs e)
        {
            Rules SecondForm = new Rules();
            SecondForm.ShowDialog();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            About SecondForm = new About();
            SecondForm.ShowDialog();

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
