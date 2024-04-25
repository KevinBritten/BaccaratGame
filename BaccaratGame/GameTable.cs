using Play;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace BaccaratGame
{
    public partial class GameTable : Form
    {
        Shoe S = new Shoe();
        Hand H = new Hand();
        PlayingCards PC = new PlayingCards();
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
            UpdateAllPlayerNamesInBettingArea();
            ClearAllWinLossLabels();
        }

        private void GameControlButton_Click(object sender, EventArgs e)
        {
            ClearMessageBox();
            switch (GameState)
            {
                case 1:
                    if (NoPlayerAtTable()) { UpdateMessageBox(0); break; }
                    if (BustedPlayerAtTable()) { UpdateMessageBox(1); break; }
                    if (playerStates[0] == 2) { panel1.Enabled = true; }
                    if (playerStates[1] == 2) { panel2.Enabled = true; }
                    if (playerStates[2] == 2) { panel3.Enabled = true; }
                    if (playerStates[3] == 2) { panel4.Enabled = true; }
                    GameState = 2;
                    SetBettingAreaEnabled();
                    SetSeatControlButtonsEnabled();
                    GameControlButton.Text = "Play";
                    ResetAllPlayerMoods();
                    ClearAllWinLossLabels();
                    break;
                case 2:
                    if (NoBetMadeAtTable()) { UpdateMessageBox(2); break; }
                    int i;
                    //Checking the conditions of the shoe
                    ResetShoeBoxes();
                    if (S.CheckCutCard())
                    {
                        int[] CardD = S.DrainingShoe();
                        for (i = 0; i < CardD.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[CardD[i]]; }
                        PC.RecordDrainingEvent(S.TallyS() - 1, CardD);
                        PC.WriteinEventFile();
                    }
                    ResetShoeBoxes();
                    if (S.Position() == 0)
                    {
                        int[] CardP = S.PrimingShoe();
                        ShoeBoxes[0].Image = PlayingCardsList.Images[CardP[0]];
                        for (i = 1; i < CardP.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[52]; }
                        PC.RecordPrimingEvent(S.TallyS(), CardP);
                        PC.WriteinEventFile();
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
                    SetWinningHandMessage();

                    ShoeProgressBar.Value = 100 * (S.DeckN() * S.CardN() - S.Position()) / (S.DeckN() * S.CardN());
                    //Summarizing the result of the play
                    Boolean[] ThirdCard = H.ThirdCard();
                    int[] PlayerH = H.Player();
                    int[] BankerH = H.Banker();
                    int[] Scores = H.Scores();
                    ResetShoeBoxes();
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
                    SaveDataInFile();
                    GameState = 3;
                    SetBettingAreaEnabled();
                    GameControlButton.Text = "Settle bet";
                    break;
                case 3:
                    AdjustPlayersFunds();
                    ClearPlayerBets();
                    UpdatePlayerStates();
                    H.ResetHand();
                    ClearAndDisableAllBettingInputs();
                    ResetShoeBoxes();
                    ResetPlayerAndBankerBoxes();
                    PlayerScoreV.Text = "";
                    BankerScoreV.Text = "";
                    GameState = 1;
                    SetSeatControlButtonsEnabled();
                    GameControlButton.Text = "Bet";
                    break;
                default: break;
            }
        }

        private void SetBettingAreaEnabled()
        {
            if (GameState == 2)
            {
                BettingAreaGroupBox.Enabled = true;
            }
            else
            {
                BettingAreaGroupBox.Enabled = false;
            }
        }

        private void SetSeatControlButtonsEnabled()
        {
            bool state = GameState == 1 ? true : false;
            Control[] seatControlButtons = { Seat1ControlButton, Seat2ControlButton, Seat3ControlButton, Seat4ControlButton };
            foreach (Control seatControlButton in seatControlButtons)
            {
                seatControlButton.Enabled = state;
            }
        }

        private void SetWinningHandMessage()
        {
            switch (H.ResultName)
            {
                case "Player": UpdateMessageBox(3); break;
                case "Banker": UpdateMessageBox(4); break;
                case "Tie": UpdateMessageBox(5); break;
                default: break;
            }
        }

        private void UpdateMessageBox(int messageCode)
        {
            String[] messages =
            {
                "Please seat at least one player to make bets.",
                "Busted players, leave or up the ante please.",
                "Please make sure all players have bet to play.",
                "Player hand wins!",
                "Banker hand wins!",
                "This round is a tie.",
                "No save files were found in selected directory"
            };
            messageBox.Text = messages[messageCode];
        }

        private void ClearMessageBox()
        {
            messageBox.Text = "";
        }

        private Boolean NoPlayerAtTable()
        {
            if ((playerStates[0] + playerStates[1] + playerStates[2] + playerStates[3]) == 0) { return true; }
            else { return false; }
        }

        private Boolean BustedPlayerAtTable()
        {
            int Busted = 0;
            for (int i = 0; i < playerStates.Length; i++) { if (playerStates[i] == 1) { Busted++; } }
            if (Busted > 0) { return true; } else { return false; }
        }

        private void ResetAllPlayerMoods()
        {
            foreach (Player player in players)
            {
                if (player != null) player.changeAvatarMood();
            }
        }

        private void ClearAllWinLossLabels()
        {
            for (int i = 0; i < players.Length; i++)
            {
                ClearWinLossLabel(i);
            }
        }

        private void ClearWinLossLabel(int playerIndex)
        {
            groupBox1.Controls.Find($"WinLossLabelPlayer{playerIndex + 1}", true)[0].Text = "";
        }

        private void UpdatePlayerStates()
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] == null) { playerStates[i] = 0; }
                else
                {
                    if (players[i].Funds < 100)
                    {
                        playerStates[i] = 1;
                    }
                    else { playerStates[i] = 2; }
                }
            }
            UpdatePlayerSitButtonText();
        }
        private void ClearAndDisableAllBettingInputs()
        {
            Panel[] bettingPanels = { panel1, panel2, panel3, panel4 };
            foreach (Panel panel in bettingPanels)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is NumericUpDown numericUpDown)
                    {
                        numericUpDown.Value = numericUpDown.Minimum;
                    }
                }
                panel.Enabled = false;
            }
        }



        private Boolean NoBetMadeAtTable()
        {
            int ShyPlayer = 0;
            if ((playerStates[0] == 2))
            {
                if ((PlayerBetPlayer1.Value + DealerBetPlayer1.Value + TieBetPlayer1.Value) == 0) { ShyPlayer++; }
            }
            if ((playerStates[1] == 2))
            {
                if ((PlayerBetPlayer2.Value + DealerBetPlayer2.Value + TieBetPlayer2.Value) == 0) { ShyPlayer++; }
            }
            if ((playerStates[2] == 2))
            {
                if ((PlayerBetPlayer3.Value + DealerBetPlayer3.Value + TieBetPlayer3.Value) == 0) { ShyPlayer++; }
            }
            if ((playerStates[3] == 2))
            {
                if ((PlayerBetPlayer4.Value + DealerBetPlayer4.Value + TieBetPlayer4.Value) == 0) { ShyPlayer++; }
            }
            if (ShyPlayer > 0) { return true; } else { return false; }
        }

        private void AdjustPlayersFunds()
        {
            //Store player funds before adjustment
            int[] previousPlayerFunds = new int[players.Length];
            for (int i = 0; i < players.Length; i++)
            {
                if (playerStates[i] == 2)
                {
                    previousPlayerFunds[i] = players[i].Funds;
                }
            }
            switch (H.Result)
            {
                case 0:
                    if ((playerStates[0] == 2))
                    {
                        players[0].Funds += (int)PlayerBetPlayer1.Value;
                        players[0].Funds -= (int)DealerBetPlayer1.Value;
                        players[0].Funds -= (int)TieBetPlayer1.Value;
                    }
                    if ((playerStates[1] == 2))
                    {
                        players[1].Funds += (int)PlayerBetPlayer2.Value;
                        players[1].Funds -= (int)DealerBetPlayer2.Value;
                        players[1].Funds -= (int)TieBetPlayer2.Value;
                    }
                    if ((playerStates[2] == 2))
                    {
                        players[2].Funds += (int)PlayerBetPlayer3.Value;
                        players[2].Funds -= (int)DealerBetPlayer3.Value;
                        players[2].Funds -= (int)TieBetPlayer3.Value;
                    }
                    if ((playerStates[3] == 2))
                    {
                        players[3].Funds += (int)PlayerBetPlayer4.Value;
                        players[3].Funds -= (int)DealerBetPlayer4.Value;
                        players[3].Funds -= (int)TieBetPlayer4.Value;
                    }
                    break;
                case 1:
                    if ((playerStates[0] == 2))
                    {
                        players[0].Funds -= (int)PlayerBetPlayer1.Value;
                        players[0].Funds += (int)(0.95 * (int)DealerBetPlayer1.Value);
                        players[0].Funds -= (int)TieBetPlayer1.Value;
                    }
                    if ((playerStates[1] == 2))
                    {
                        players[1].Funds -= (int)PlayerBetPlayer2.Value;
                        players[1].Funds += (int)(0.95 * (int)DealerBetPlayer2.Value);
                        players[1].Funds -= (int)TieBetPlayer2.Value;
                    }
                    if ((playerStates[2] == 2))
                    {
                        players[2].Funds -= (int)PlayerBetPlayer3.Value;
                        players[2].Funds += (int)(0.95 * (int)DealerBetPlayer3.Value);
                        players[2].Funds -= (int)TieBetPlayer3.Value;
                    }
                    if ((playerStates[3] == 2))
                    {
                        players[3].Funds -= (int)PlayerBetPlayer4.Value;
                        players[3].Funds += (int)(0.95 * (int)DealerBetPlayer4.Value);
                        players[3].Funds -= (int)TieBetPlayer4.Value;
                    }
                    break;
                case 2:
                    if ((playerStates[0] == 2)) { players[0].Funds += 8 * (int)TieBetPlayer1.Value; }
                    if ((playerStates[1] == 2)) { players[1].Funds += 8 * (int)TieBetPlayer2.Value; }
                    if ((playerStates[2] == 2)) { players[2].Funds += 8 * (int)TieBetPlayer3.Value; }
                    if ((playerStates[3] == 2)) { players[3].Funds += 8 * (int)TieBetPlayer4.Value; }
                    break;
                default: break;
            }
            for (int i = 0; i < players.Length; i++)
            {
                if (playerStates[i] == 2)
                {
                    int fundsDifference = players[i].Funds - previousPlayerFunds[i];
                    Control winLossLabel = groupBox1.Controls.Find($"winLossLabelPlayer{i + 1}", true)[0];
                    if (fundsDifference > 0) { winLossLabel.ForeColor = System.Drawing.Color.Blue; winLossLabel.Text = $"+${fundsDifference}"; players[i].changeAvatarMood("happy"); }
                    else if (fundsDifference < 0) { winLossLabel.ForeColor = System.Drawing.Color.Red; winLossLabel.Text = $"-${fundsDifference * -1}"; players[i].changeAvatarMood("sad"); }
                    else { winLossLabel.ForeColor = System.Drawing.Color.Blue; winLossLabel.Text = "+$0"; }


                }
            }


        }

        private void ResetShoeBoxes() { for (int i = 0; i < ShoeBoxes.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[53]; } }
        private void ResetPlayerAndBankerBoxes()
        {
            for (int i = 0; i < PlayerBoxes.Length; i++) { PlayerBoxes[i].Image = PlayingCardsList.Images[53]; }
            for (int i = 0; i < BankerBoxes.Length; i++) { BankerBoxes[i].Image = PlayingCardsList.Images[53]; }
        }


        private void Seat1ControlButton_Click(object sender, EventArgs e)
        {
            int PlayerState = playerStates[0];
            switch (PlayerState)
            {
                case 0: ActivatePlayerSitForm(0, FundBoxPlayer1_FundsChanged, AvatarPictureBoxPlayer1_ImageChanged); break;
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
                case 0: ActivatePlayerSitForm(1, FundBoxPlayer2_FundsChanged, AvatarPictureBoxPlayer2_ImageChanged); break;
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
                case 0: ActivatePlayerSitForm(2, FundBoxPlayer3_FundsChanged, AvatarPictureBoxPlayer3_ImageChanged); break;
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
                case 0: ActivatePlayerSitForm(3, FundBoxPlayer4_FundsChanged, AvatarPictureBoxPlayer4_ImageChanged); break;
                case 1: ActivatePlayerBustedForm(3); break;
                case 2: ActivatePlayerWithdrawForm(3); break;
                default: break;
            }
        }

        public void ActivatePlayerSitForm(int P, EventHandler fundsChangedCallback, EventHandler avatarChangedCallback)
        {
            PlayerSit SecondForm = new PlayerSit(P, players, fundsChangedCallback, avatarChangedCallback);
            SecondForm.ShowDialog();
            UpdatePlayerStates();
            UpdatePlayerNameInBettingArea(P);
        }

        public void ActivatePlayerBustedForm(int P)
        {
            PlayerBusted SecondForm = new PlayerBusted(P, players);
            SecondForm.ShowDialog();
            UpdatePlayerStates();
            if (playerStates[P] == 1)
            {
                WithdrawPlayer(P);
            }
        }

        public void ActivatePlayerWithdrawForm(int P)
        {
            PlayerWithdraw SecondForm = new PlayerWithdraw(P, playerStates, players[P]);
            SecondForm.ShowDialog();
            if (playerStates[P] == 1)
            {
                WithdrawPlayer(P);
            }
        }

        public void UpdatePlayerNameInBettingArea(int playerIndex)
        {
            string playerLabelString = $"NameLabelPlayer{playerIndex + 1}";
            Control playerLabel = BettingAreaGroupBox.Controls.Find(playerLabelString, true)[0];
            if (players[playerIndex] != null)
            {

                playerLabel.Text = players[playerIndex].Name;
            }
            else
            {
                playerLabel.Text = $"Empty Seat {playerIndex + 1}";
            }
        }

        public void UpdateAllPlayerNamesInBettingArea()
        {
            for (int i = 0; i < players.Length; i++)
            {
                UpdatePlayerNameInBettingArea(i);
            }
        }

        private void WithdrawPlayer(int playerIndex)
        {
            BettingAreaGroupBox.Controls.Find($"FundBoxPlayer{playerIndex + 1}", true)[0].Text = "";
            players[playerIndex].Avatar = null;
            players[playerIndex].unsubscribeAllListeners();
            players[playerIndex] = null;
            ClearWinLossLabel(playerIndex);
            UpdatePlayerStates();
            UpdatePlayerNameInBettingArea(playerIndex);
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

        private void AvatarPictureBoxPlayer1_ImageChanged(object sender, EventArgs e)
        {
            AvatarPictureBoxPlayer1.Image = players[0].Avatar;
        }
        private void AvatarPictureBoxPlayer2_ImageChanged(object sender, EventArgs e)
        {
            AvatarPictureBoxPlayer2.Image = players[1].Avatar;
        }
        private void AvatarPictureBoxPlayer3_ImageChanged(object sender, EventArgs e)
        {
            AvatarPictureBoxPlayer3.Image = players[2].Avatar;
        }
        private void AvatarPictureBoxPlayer4_ImageChanged(object sender, EventArgs e)
        {
            AvatarPictureBoxPlayer4.Image = players[3].Avatar;
        }

        private void PlayerBetPlayer1_ValueChanged(object sender, EventArgs e)
        {
            int S = players[0].Funds - (int)DealerBetPlayer1.Value - (int)TieBetPlayer1.Value;
            if (PlayerBetPlayer1.Value > S)
            {
                decimal newValue = PlayerBetPlayer1.Value - PlayerBetPlayer1.Increment;
                PlayerBetPlayer1.Value = newValue < 0 ? 0 : newValue;
            }
            updateBet(0, PlayerBetPlayer1.Value, players[0]);
        }

        private void PlayerBetPlayer2_ValueChanged(object sender, EventArgs e)
        {
            int S = players[1].Funds - (int)DealerBetPlayer2.Value - (int)TieBetPlayer2.Value;
            if (PlayerBetPlayer2.Value > S)
            {

                decimal newValue = PlayerBetPlayer2.Value - PlayerBetPlayer2.Increment;
                PlayerBetPlayer2.Value = newValue < 0 ? 0 : newValue;
            }
            updateBet(0, PlayerBetPlayer2.Value, players[1]);
        }

        private void PlayerBetPlayer3_ValueChanged(object sender, EventArgs e)
        {
            int S = players[2].Funds - (int)DealerBetPlayer3.Value - (int)TieBetPlayer3.Value;
            if (PlayerBetPlayer3.Value > S)
            {
                decimal newValue = PlayerBetPlayer3.Value - PlayerBetPlayer3.Increment;
                PlayerBetPlayer3.Value = newValue < 0 ? 0 : newValue;
            }
            updateBet(0, PlayerBetPlayer3.Value, players[2]);
        }

        private void PlayerBetPlayer4_ValueChanged(object sender, EventArgs e)
        {
            int S = players[3].Funds - (int)DealerBetPlayer4.Value - (int)TieBetPlayer4.Value;
            if (PlayerBetPlayer4.Value > S)
            {
                decimal newValue = PlayerBetPlayer4.Value - PlayerBetPlayer4.Increment;
                PlayerBetPlayer4.Value = newValue < 0 ? 0 : newValue;
            }
            updateBet(0, PlayerBetPlayer4.Value, players[3]);
        }

        private void DealerBetPlayer1_ValueChanged(object sender, EventArgs e)
        {
            int S = players[0].Funds - (int)PlayerBetPlayer1.Value - (int)TieBetPlayer1.Value;
            if (DealerBetPlayer1.Value > S)
            {
                decimal newValue = DealerBetPlayer1.Value - DealerBetPlayer1.Increment;
                DealerBetPlayer1.Value = newValue < 0 ? 0 : newValue;
            }
            updateBet(1, DealerBetPlayer1.Value, players[0]);
        }

        private void DealerBetPlayer2_ValueChanged(object sender, EventArgs e)
        {
            int S = players[1].Funds - (int)PlayerBetPlayer2.Value - (int)TieBetPlayer2.Value;
            if (DealerBetPlayer2.Value > S)
            {
                decimal newValue = DealerBetPlayer2.Value - DealerBetPlayer2.Increment;
                DealerBetPlayer2.Value = newValue < 0 ? 0 : newValue;
            }
            updateBet(1, DealerBetPlayer2.Value, players[1]);
        }

        private void DealerBetPlayer3_ValueChanged(object sender, EventArgs e)
        {
            int S = players[2].Funds - (int)PlayerBetPlayer3.Value - (int)TieBetPlayer3.Value;
            if (DealerBetPlayer3.Value > S)
            {
                decimal newValue = DealerBetPlayer3.Value - DealerBetPlayer3.Increment;
                DealerBetPlayer3.Value = newValue < 0 ? 0 : newValue;
            }
            updateBet(1, DealerBetPlayer3.Value, players[2]);
        }

        private void DealerBetPlayer4_ValueChanged(object sender, EventArgs e)
        {
            int S = players[3].Funds - (int)PlayerBetPlayer4.Value - (int)TieBetPlayer4.Value;
            if (DealerBetPlayer4.Value > S)
            {
                decimal newValue = DealerBetPlayer4.Value - DealerBetPlayer4.Increment;
                DealerBetPlayer4.Value = newValue < 0 ? 0 : newValue;
            }
            updateBet(1, DealerBetPlayer4.Value, players[3]);
        }

        private void TieBetPlayer1_ValueChanged(object sender, EventArgs e)
        {
            int S = players[0].Funds - (int)PlayerBetPlayer1.Value - (int)DealerBetPlayer1.Value;
            if (TieBetPlayer1.Value > S)
            {
                decimal newValue = TieBetPlayer1.Value - TieBetPlayer1.Increment;
                TieBetPlayer1.Value = newValue < 0 ? 0 : newValue;
            }
            updateBet(2, TieBetPlayer1.Value, players[0]);
        }

        private void TieBetPlayer2_ValueChanged(object sender, EventArgs e)
        {
            int S = players[1].Funds - (int)PlayerBetPlayer2.Value - (int)DealerBetPlayer2.Value;
            if (TieBetPlayer2.Value > S)
            {
                decimal newValue = TieBetPlayer2.Value - TieBetPlayer2.Increment;
                TieBetPlayer2.Value = newValue < 0 ? 0 : newValue;
            }
            updateBet(2, TieBetPlayer2.Value, players[1]);
        }

        private void TieBetPlayer3_ValueChanged(object sender, EventArgs e)
        {
            int S = players[2].Funds - (int)PlayerBetPlayer3.Value - (int)DealerBetPlayer3.Value;
            if (TieBetPlayer3.Value > S)
            {
                decimal newValue = TieBetPlayer3.Value - TieBetPlayer3.Increment;
                TieBetPlayer3.Value = newValue < 0 ? 0 : newValue;
            }
            updateBet(2, TieBetPlayer3.Value, players[2]);
        }

        private void TieBetPlayer4_ValueChanged(object sender, EventArgs e)
        {
            int S = players[3].Funds - (int)PlayerBetPlayer4.Value - (int)DealerBetPlayer4.Value;
            if (TieBetPlayer4.Value > S)
            {
                decimal newValue = TieBetPlayer4.Value - TieBetPlayer4.Increment;
                TieBetPlayer4.Value = newValue < 0 ? 0 : newValue;
            }
            updateBet(2, TieBetPlayer4.Value, players[3]);
        }
        private void updateBet(int index, decimal value, Player player)
        {
            player.updateBet(index, (int)value);
        }

        private void SaveDataInFile()
        {
            PC.UpdatePlayEventCounts();
            PC.WriteInShoeFile(S.TallyS(), S.Position(), S.Stack());
            PC.LineUpHands(H.Player(), H.Banker(), H.ThirdCard(), H.Scores(), H.ResultName);
            for (int i = 0; i < players.Length; i++)
            {
                if (playerStates[i] == 0) { PC.LineUpNoPlayer(); }
                else { PC.LineUpPlayer(players[i].Name, players[i].AvatarName, players[i].Funds, players[i].Bets); }
            }
            PC.WriteinPlayFile();
            PC.RecordPlayEvent(H.Player(), H.Banker(), H.ThirdCard());
            PC.WriteinEventFile();
        }

        private void ClearPlayerBets()
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] != null) { players[i].clearAllBets(); }
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

        private void SetDataSavebutton_Click(object sender, EventArgs e)
        {
            DialogResult result = saveDatafolderBDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(saveDatafolderBDialog.SelectedPath))
            {
                PC.SetDirectoryName(saveDatafolderBDialog.SelectedPath);
                PC.SetDirectoryKnown(true);
                PC.SetPlayCount(0);
                PC.SetEventCount(0);
            }
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            ClearMessageBox();

            DialogResult result = saveDatafolderBDialog.ShowDialog();
            string directoryPath = saveDatafolderBDialog.SelectedPath;
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(directoryPath))
            {
                if (!checkForSaveFiles(directoryPath)) UpdateMessageBox(6);
                else
                {
                    ClearAllWinLossLabels();
                    ResetShoeBoxes();
                    ResetPlayerAndBankerBoxes();
                    PC.SetDirectoryName(directoryPath);
                    PC.SetDirectoryKnown(true);
                    //TODO:Uncomment when functions written

                    ExtractShoeData();
                    ExtractEventData();
                    ExtractPlayData();

                }

            }
        }

        private bool checkForSaveFiles(string directoryPath)
        {
            bool result = true;
            string[] fileNames = { PC.GetShoeFileName(), PC.GetEventFileName(), PC.GetPlayFileName() };
            foreach (string fileName in fileNames)
            {
                string path = Path.Combine(directoryPath, fileName);
                if (!File.Exists(path)) result = false;
            }
            return result;
        }

        private void ExtractShoeData()
        {
            string aPath = "";
            TextReader txt = null;
            if (PC.GetDirectoryKnown())
            {
                try
                {
                    int[] CardStack = new int[S.DeckN() * S.CardN()];
                    aPath = Path.Combine(PC.GetDirectoryName(), PC.GetShoeFileName());
                    txt = new StreamReader(aPath);
                    S.GetTallyS(Convert.ToInt16(txt.ReadLine()));
                    S.GetPosition(Convert.ToInt16(txt.ReadLine()));
                    for (int i = 0; i < CardStack.Length; i++) { CardStack[i] = Convert.ToInt16(txt.ReadLine()); }
                    S.GetStack(CardStack);
                    ShoeProgressBar.Value = 100 * (S.DeckN() * S.CardN() - S.Position()) / (S.DeckN() * S.CardN());
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { txt.Close(); }
            }
        }

        private void ExtractEventData()
        {
            string aPath = "";
            int EventN = 0;
            TextReader txt = null;
            if (PC.GetDirectoryKnown())
            {
                try
                {
                    string Line;
                    aPath = Path.Combine(PC.GetDirectoryName(), PC.GetEventFileName());
                    txt = new StreamReader(aPath);
                    Line = txt.ReadLine();
                    while ((Line = txt.ReadLine()) != null) { string[] fields = Line.Split(','); EventN = Convert.ToInt16(fields[0]); }
                    PC.SetEventCount(EventN);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { txt.Close(); }
            }
        }
        private void ExtractPlayData()
        {
            string aPath = Path.Combine(PC.GetDirectoryName(), PC.GetPlayFileName());
            string[] currentPlay = GetLastNonEmptyLine(aPath).Split(',');
            PC.SetPlayCount(Convert.ToInt16(currentPlay[0]));
            SetLoadedPlayers(currentPlay);
            SetHandAttributesFromPlayData(currentPlay);
            SetDealtCardsFromPlayData(currentPlay);
            UpdatePlayerStates();
            UpdateAllPlayerNamesInBettingArea();
            GameState = 3;
            GameControlButton.Text = "Settle bet";
            SetBettingAreaEnabled();
            SetSeatControlButtonsEnabled();
            SetBettingAreaEnabled();
            SetWinningHandMessage();
        }

        private string GetLastNonEmptyLine(string filePath)
        {
            string? lastNonEmptyLine = null;
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        lastNonEmptyLine = line;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                reader.Close();
            }
            return lastNonEmptyLine;
        }

        private void SetLoadedPlayers(string[] currentPlay)
        {
            EventHandler[] fundsHandlers = { FundBoxPlayer1_FundsChanged, FundBoxPlayer2_FundsChanged, FundBoxPlayer3_FundsChanged, FundBoxPlayer4_FundsChanged };
            EventHandler[] avatarHandlers = { AvatarPictureBoxPlayer1_ImageChanged, AvatarPictureBoxPlayer2_ImageChanged, AvatarPictureBoxPlayer3_ImageChanged, AvatarPictureBoxPlayer4_ImageChanged };
            NumericUpDown[][] bettingControls = new NumericUpDown[][] {
                new NumericUpDown[]{ PlayerBetPlayer1, DealerBetPlayer1, TieBetPlayer1 },
                new NumericUpDown[]{ PlayerBetPlayer2, DealerBetPlayer2, TieBetPlayer2 },
                new NumericUpDown[]{ PlayerBetPlayer3, DealerBetPlayer3, TieBetPlayer3 },
                new NumericUpDown[]{ PlayerBetPlayer4, DealerBetPlayer4, TieBetPlayer4 }, };

            ResetAllBettingControls(bettingControls);
            ResetAllPlayers();
            //look for player names on index 10,16,22,28 and set them if found
            for (int i = 10; i < 29; i += 6)
            {
                if (!string.IsNullOrWhiteSpace(currentPlay[i]))
                {
                    int playerIndex = (i - 10) / 6;
                    string name = currentPlay[i];
                    int funds = int.Parse(currentPlay[i + 2]);
                    string avatarName = currentPlay[i + 1];
                    players[playerIndex] = new Player(name, 0);
                    players[playerIndex].FundsChanged += fundsHandlers[playerIndex];
                    players[playerIndex].AvatarChanged += avatarHandlers[playerIndex];
                    players[playerIndex].Funds = funds;
                    players[playerIndex].AvatarName = avatarName;
                    bettingControls[playerIndex][0].Value = int.Parse(currentPlay[i + 3]);
                    bettingControls[playerIndex][1].Value = int.Parse(currentPlay[i + 4]);
                    bettingControls[playerIndex][2].Value = int.Parse(currentPlay[i + 5]);
                }
            }
        }
        private void SetHandAttributesFromPlayData(string[] currentPlay)
        {
            string ResultName = currentPlay[9];
            switch (ResultName)
            {
                case "Player": H.Result = 0; break;
                case "Banker": H.Result = 1; break;
                case "Tie": H.Result = 2; break;
                default: break;
            }
        }

        private void SetDealtCardsFromPlayData(string[] currentPlay)
        {
            ShoeBoxes[0].Image = PlayingCardsList.Images[PC.GetCardNumber(currentPlay[1])];
            ShoeBoxes[1].Image = PlayingCardsList.Images[PC.GetCardNumber(currentPlay[5])];
            ShoeBoxes[2].Image = PlayingCardsList.Images[PC.GetCardNumber(currentPlay[2])];
            ShoeBoxes[3].Image = PlayingCardsList.Images[PC.GetCardNumber(currentPlay[6])];
            if (currentPlay[3] != null) { ShoeBoxes[4].Image = PlayingCardsList.Images[PC.GetCardNumber(currentPlay[3])]; }
            if (currentPlay[7] != null) {
                if (currentPlay[3] == null) { ShoeBoxes[4].Image = PlayingCardsList.Images[PC.GetCardNumber(currentPlay[7])]; }
                else { ShoeBoxes[5].Image = PlayingCardsList.Images[PC.GetCardNumber(currentPlay[7])]; }
            }
            PlayerBoxes[0].Image = PlayingCardsList.Images[PC.GetCardNumber(currentPlay[1])];
            PlayerBoxes[1].Image = PlayingCardsList.Images[PC.GetCardNumber(currentPlay[2])];
            BankerBoxes[0].Image = PlayingCardsList.Images[PC.GetCardNumber(currentPlay[5])];
            BankerBoxes[1].Image = PlayingCardsList.Images[PC.GetCardNumber(currentPlay[6])];
            if (currentPlay[3] != null) { PlayerBoxes[2].Image = PlayingCardsList.Images[PC.GetCardNumber(currentPlay[3])]; }
            if (currentPlay[7] != null) { BankerBoxes[2].Image = PlayingCardsList.Images[PC.GetCardNumber(currentPlay[7])]; }
            PlayerScoreV.Text = currentPlay[4];
            BankerScoreV.Text = currentPlay[8];
        }

        private void ResetAllPlayers()
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] != null)
                {
                    WithdrawPlayer(i);
                }
            }
        }

        private void ResetAllBettingControls(NumericUpDown[][] bettingControls)
        {
            foreach (NumericUpDown[] innerArray in bettingControls)
            {
                foreach (NumericUpDown bettingControl in innerArray)
                {
                    if (bettingControl.Value != 0) bettingControl.Value = 0;
                }
            }
        }
    }
}
