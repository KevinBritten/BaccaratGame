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
                    GameState = 2;
                    GameControlButton.Text = "Play";
                    break;
                case 2:
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
                    GameState = 1;
                    GameControlButton.Text = "Bet";
                    break;
                default: break;
            }
        }

        private void ResetShoeBoxes() { for (int i = 0; i < ShoeBoxes.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[53]; } }

        private void Seat1ControlButton_Click(object sender, EventArgs e)
        {
            int PlayerState = 1;
            switch (PlayerState)
            {
                case 1: ActivatePlayerSitForm(0, FundBoxPlayer1_FundsChanged); break;
                case 2: ActivatePlayerBustedForm(1); break;
                case 3: ActivatePlayerWithdrawForm(1); break;
                default: break;
            }
        }

        private void Seat2ControlButton_Click(object sender, EventArgs e)
        {
            int PlayerState = 1;
            switch (PlayerState)
            {
                case 1: ActivatePlayerSitForm(1, FundBoxPlayer2_FundsChanged); break;
                case 2: ActivatePlayerBustedForm(2); break;
                case 3: ActivatePlayerWithdrawForm(2); break;
                default: break;
            }
        }

        private void Seat3ControButton_Click(object sender, EventArgs e)
        {
            int PlayerState = 1;
            switch (PlayerState)
            {
                case 1: ActivatePlayerSitForm(2, FundBoxPlayer3_FundsChanged); break;
                case 2: ActivatePlayerBustedForm(3); break;
                case 3: ActivatePlayerWithdrawForm(3); break;
                default: break;
            }
        }

        private void Seat4ControlButton_Click(object sender, EventArgs e)
        {
            int PlayerState = 1;
            switch (PlayerState)
            {
                case 1: ActivatePlayerSitForm(3, FundBoxPlayer4_FundsChanged); break;
                case 2: ActivatePlayerBustedForm(4); break;
                case 3: ActivatePlayerWithdrawForm(4); break;
                default: break;
            }
        }

        public void ActivatePlayerSitForm(int P, EventHandler fundsChangedCallback)
        {
            PlayerSit SecondForm = new PlayerSit(P, players, fundsChangedCallback);
            SecondForm.ShowDialog();
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
            updateBet(0, PlayerBetPlayer1.Value, players[0]);
        }

        private void PlayerBetPlayer2_ValueChanged(object sender, EventArgs e)
        {
            updateBet(0, PlayerBetPlayer2.Value, players[1]);
        }

        private void PlayerBetPlayer3_ValueChanged(object sender, EventArgs e)
        {
            updateBet(0, PlayerBetPlayer3.Value, players[2]);
        }

        private void PlayerBetPlayer4_ValueChanged(object sender, EventArgs e)
        {
            updateBet(0, PlayerBetPlayer4.Value, players[3]);
        }

        private void DealerBetPlayer1_ValueChanged(object sender, EventArgs e)
        {
            updateBet(1, DealerBetPlayer1.Value, players[0]);
        }

        private void DealerBetPlayer2_ValueChanged(object sender, EventArgs e)
        {
            updateBet(1, DealerBetPlayer2.Value, players[1]);
        }

        private void DealerBetPlayer3_ValueChanged(object sender, EventArgs e)
        {
            updateBet(1, DealerBetPlayer3.Value, players[2]);
        }

        private void DealerBetPlayer4_ValueChanged(object sender, EventArgs e)
        {
            updateBet(1, DealerBetPlayer4.Value, players[3]);
        }

        private void TieBetPlayer1_ValueChanged(object sender, EventArgs e)
        {
            updateBet(2, TieBetPlayer1.Value, players[0]);
        }

        private void TieBetPlayer2_ValueChanged(object sender, EventArgs e)
        {
            updateBet(2, TieBetPlayer2.Value, players[1]);
        }

        private void TieBetPlayer3_ValueChanged(object sender, EventArgs e)
        {
            updateBet(2, TieBetPlayer3.Value, players[2]);
        }

        private void TieBetPlayer4_ValueChanged(object sender, EventArgs e)
        {
            updateBet(2, TieBetPlayer4.Value, players[3]);
        }
        private void updateBet(int index, decimal value, Player player)
        {
            player.updateBet(index, (int)value);
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
