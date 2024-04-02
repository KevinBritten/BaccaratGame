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
        PictureBox[] ShoeBoxes = new PictureBox[11];
        PictureBox[] PlayerBoxes = new PictureBox[3];
        PictureBox[] BankerBoxes = new PictureBox[3];
        Player[] players = new Player[4];

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
            players[0] = new Player("Test", 10m, "empty");
            players[0].FundsChanged += FundBoxPlayer1_FundsChanged;
            players[0].Funds = 11m;
        }

        private void GameControlButton_Click(object sender, EventArgs e)
        {
            PlayingCards PC = new PlayingCards();
            Hand H = new Hand();
            int i;

            //Checking the conditions of the shoe
            for (i = 0; i < ShoeBoxes.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[53]; }
            if (S.CheckCutCard())
            {
                int[] CardD = S.DrainingShoe();
                string Results = "Draining the shoe; discarded cards:";
                for (i = 0; i < CardD.Length; i++) { Results = Results + "   " + PC.GetAbbrCardID(CardD[i]); }
                for (i = 0; i < CardD.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[CardD[i]]; }
            }
            for (i = 0; i < ShoeBoxes.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[53]; }
            if (S.Position() == 0)
            {
                int[] CardP = S.PrimingShoe();
                string Results = "Priming the shoe; discarded cards:";
                for (i = 0; i < CardP.Length; i++) { Results = Results + "   " + PC.GetAbbrCardID(CardP[i]); }
                ShoeBoxes[0].Image = PlayingCardsList.Images[CardP[0]];
                for (i = 1; i < CardP.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[52]; }
            }
            //Play a hand for the Player and Banker
            int[] CardH = new int[4];
            for (i = 0; i < CardH.Length; i++) { CardH[i] = S.PickCard(); }
            H.DistributeFourCards(CardH);
            if (H.NoNaturalHand())
            {
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
            for (i = 0; i < ShoeBoxes.Length; i++) { ShoeBoxes[i].Image = PlayingCardsList.Images[53]; }
            for (i = 0; i < PlayerBoxes.Length; i++) { PlayerBoxes[i].Image = PlayingCardsList.Images[53]; }
            for (i = 0; i < BankerBoxes.Length; i++) { BankerBoxes[i].Image = PlayingCardsList.Images[53]; }
            ShoeBoxes[0].Image = PlayingCardsList.Images[PlayerH[0]]; ShoeBoxes[1].Image = PlayingCardsList.Images[BankerH[0]];
            ShoeBoxes[2].Image = PlayingCardsList.Images[PlayerH[1]]; ShoeBoxes[3].Image = PlayingCardsList.Images[BankerH[1]];
            if (ThirdCard[0] == 1) { ShoeBoxes[4].Image = PlayingCardsList.Images[PlayerH[2]]; }
            if (ThirdCard[1] == 1)
            {
                if (ThirdCard[0] == 0) { ShoeBoxes[4].Image = PlayingCardsList.Images[BankerH[2]]; }
                else { ShoeBoxes[5].Image = PlayingCardsList.Images[BankerH[2]]; }
            }
            PlayerBoxes[0].Image = PlayingCardsList.Images[PlayerH[0]]; PlayerBoxes[1].Image = PlayingCardsList.Images[PlayerH[1]];
            BankerBoxes[0].Image = PlayingCardsList.Images[BankerH[0]]; BankerBoxes[1].Image = PlayingCardsList.Images[BankerH[1]];
            if (ThirdCard[0] == 1) { PlayerBoxes[2].Image = PlayingCardsList.Images[PlayerH[2]]; }
            if (ThirdCard[1] == 1) { BankerBoxes[2].Image = PlayingCardsList.Images[BankerH[2]]; }
            PlayerScoreV.Text = Convert.ToString(Scores[0]);
            BankerScoreV.Text = Convert.ToString(Scores[1]);
        }

        private void RulesButton_Click(object sender, EventArgs e)
        {
            Rules SecondForm = new Rules();
            SecondForm.ShowDialog();
        }

        private void Seat1ControlButton_Click(object sender, EventArgs e)
        {
            //Until we develop the sitplayer, busted and withdraw forms...
        }

        private void Seat2ControlButton_Click(object sender, EventArgs e)
        {
            //Until we develop the sitplayer, busted and withdraw forms...
        }

        private void Seat3ControButton_Click(object sender, EventArgs e)
        {
            //Until we develop the sitplayer, busted and withdraw forms...
        }

        private void Seat4ControlButton_Click(object sender, EventArgs e)
        {
            //Until we develop the sitplayer, busted and withdraw forms...
        }

        private void FundBoxPlayer1_FundsChanged(object sender, EventArgs e)
        {
            FundBoxPlayer1.Text = players[0].Funds.ToString();
        }
        private void FundBoxPlayer2_FundsChanged(object sender, EventArgs e)
        {
            FundBoxPlayer1.Text = players[1].Funds.ToString();
        }
        private void FundBoxPlayer3_FundsChanged(object sender, EventArgs e)
        {
            FundBoxPlayer1.Text = players[2].Funds.ToString();
        }
        private void FundBoxPlayer4_FundsChanged(object sender, EventArgs e)
        {
            FundBoxPlayer1.Text = players[3].Funds.ToString();
        }
    }
}
