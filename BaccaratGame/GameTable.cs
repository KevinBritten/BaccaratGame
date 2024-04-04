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
using System.Xml.Serialization;

namespace BaccaratGame
{
    public partial class GameTable : Form
    {
        Shoe S = new Shoe();
        PictureBox[] ShoeBoxes = new PictureBox[11];
        PictureBox[] PlayerBoxes = new PictureBox[3];
        PictureBox[] BankerBoxes = new PictureBox[3];
        Player[] players = new Player[4];
        int currentGameState = 0;
        String[] gameStates = { "Sit", "Bet", "Play", "Settle" };


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
            disableControlsBasedOnGameState();
            setActionButtonText();
        }

        public void advanceGameState()
        {
            currentGameState = (currentGameState + 1) % gameStates.Length;
            disableControlsBasedOnGameState();
            setActionButtonText();
        }

        public void disableControlsBasedOnGameState()
        {
            if (currentGameState == 0)
            {
                BettingAreaGroupBox.Enabled = false;
                SitPlayerPanel.Enabled = true;
            }
            else if (currentGameState == 1)
            {
                BettingAreaGroupBox.Enabled = true;
                SitPlayerPanel.Enabled = false;
            } else
            {
                BettingAreaGroupBox.Enabled = false;
                SitPlayerPanel.Enabled = false;
            }
        }

        public void setActionButtonText()
        {
            GameControlButton.Text = gameStates[(currentGameState + 1) % gameStates.Length];
        }

        private void GameControlButton_Click(object sender, EventArgs e)
        {
            Hand H = new Hand();
            int i;
            //Checking the conditions of the shoe
            ResetShoeBoxes();
            if (S.CheckCutCard()) {
                int[] CardD = S.DrainingShoe();
                for (i = 0; i < CardD.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[CardD[i]]; }
            }
            ResetShoeBoxes();
            if (S.Position() == 0) {
                int[] CardP = S.PrimingShoe();
                ShoeBoxes[0].Image = PlayingCardsList.Images[CardP[0]];
                for (i = 1; i < CardP.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[52]; }
            }
            //Play a hand for the Player and Banker
            int[] CardH = new int[4];
            for (i = 0; i < CardH.Length; i++) { CardH[i] = S.PickCard(); }
            H.DistributeFourCards(CardH);
            if (H.NoNaturalHand()) {
                if (H.NeedPlayerThirdCard()) { H.GetPlayerThirdCard(S.PickCard()); }
                if (H.NeedBankerThirdCard()) { H.GetBankerThirdCard(S.PickCard()); }
            }
            H.DetermineWinningHand();
            ShoeProgressBar.Value = 100 * (S.DeckN() * S.CardN() - S.Position()) / (S.DeckN() * S.CardN());
            //Summarizing the result of the play
            int[] ThirdCard = H.ThirdCard();
            int[] PlayerH = H.Player();
            int[] BankerH = H.Banker();
            int[] Scores = H.Scores();
            ResetShoeBoxes();
            for (i = 0; i < PlayerBoxes.Length; i++) { PlayerBoxes[i].Image = PlayingCardsList.Images[53]; }
            for (i = 0; i < BankerBoxes.Length; i++) { BankerBoxes[i].Image = PlayingCardsList.Images[53]; }
            ShoeBoxes[0].Image = PlayingCardsList.Images[PlayerH[0]]; ShoeBoxes[1].Image = PlayingCardsList.Images[BankerH[0]];
            ShoeBoxes[2].Image = PlayingCardsList.Images[PlayerH[1]]; ShoeBoxes[3].Image = PlayingCardsList.Images[BankerH[1]];
            if (ThirdCard[0] == 1) { ShoeBoxes[4].Image = PlayingCardsList.Images[PlayerH[2]]; }
            if (ThirdCard[1] == 1) {
                if (ThirdCard[0] == 0) { ShoeBoxes[4].Image = PlayingCardsList.Images[BankerH[2]]; }
                else { ShoeBoxes[5].Image = PlayingCardsList.Images[BankerH[2]]; }
            }
            PlayerBoxes[0].Image = PlayingCardsList.Images[PlayerH[0]]; PlayerBoxes[1].Image = PlayingCardsList.Images[PlayerH[1]];
            BankerBoxes[0].Image = PlayingCardsList.Images[BankerH[0]]; BankerBoxes[1].Image = PlayingCardsList.Images[BankerH[1]];
            if (ThirdCard[0] == 1) { PlayerBoxes[2].Image = PlayingCardsList.Images[PlayerH[2]]; }
            if (ThirdCard[1] == 1) { BankerBoxes[2].Image = PlayingCardsList.Images[BankerH[2]]; }
            PlayerScoreV.Text = Convert.ToString(Scores[0]);
            BankerScoreV.Text = Convert.ToString(Scores[1]);
            //TODO: Only advance when it is appropriate, function call below is only for testing
            advanceGameState();
        }

        private void ResetShoeBoxes() { for (int i = 0; i < ShoeBoxes.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[53]; } }

        private void Seat1ControlButton_Click(object sender, EventArgs e)
        {
            sitPlayer(0, 10, new EventHandler(FundBoxPlayer1_FundsChanged));
        }

        private void Seat2ControlButton_Click(object sender, EventArgs e)
        {
            sitPlayer(1, 15, new EventHandler(FundBoxPlayer2_FundsChanged));
        }

        private void Seat3ControButton_Click(object sender, EventArgs e)
        {
            sitPlayer(2, 13, new EventHandler(FundBoxPlayer3_FundsChanged));
        }

        private void Seat4ControlButton_Click(object sender, EventArgs e)
        {
            sitPlayer(3, 3555, new EventHandler(FundBoxPlayer4_FundsChanged));
        }

        private void sitPlayer(int position, int funds, EventHandler fundsChangedCallback)
        {
            players[position] = new Player("placeholder",funds, "placeholder");
            players[position].FundsChanged += fundsChangedCallback;
            players[position].Funds = funds;
            string controlPanelName = $"BetControlsPanelPlayer{position+1}";
            BettingAreaGroupBox.Controls.Find(controlPanelName, false)[0].Enabled = true;

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
