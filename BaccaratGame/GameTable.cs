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

        public GameTable()
        {
            InitializeComponent();
            ShoeBoxes[0] = ShoeBox0; ShoeBoxes[1] = ShoeBox1; ShoeBoxes[2] = ShoeBox2; ShoeBoxes[3] = ShoeBox3;
            ShoeBoxes[4] = ShoeBox4; ShoeBoxes[5] = ShoeBox5; ShoeBoxes[6] = ShoeBox6; ShoeBoxes[7] = ShoeBox7;
            ShoeBoxes[8] = ShoeBox8; ShoeBoxes[9] = ShoeBox9; ShoeBoxes[10] = ShoeBox10;
            PlayerBoxes[0] = PlayerBox0; PlayerBoxes[1] = PlayerBox1; PlayerBoxes[2] = PlayerBox2;
            BankerBoxes[0] = BankerBox0; BankerBoxes[1] = BankerBox1; BankerBoxes[2] = BankerBox2;
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
    }
}
