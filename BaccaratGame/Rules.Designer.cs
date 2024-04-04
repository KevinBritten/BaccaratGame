namespace BaccaratGame
{
    partial class Rules
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnReturn = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(776, 494);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(94, 29);
            btnReturn.TabIndex = 0;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 28;
            listBox1.Items.AddRange(new object[] { "THE OBJECT OF THE GAME:", "In each game, the player attempts to predict which of the two hands, the player's or the ", "banker's, will come closest to a total of nine points, the highest value for a Baccarat hand.", "", "THE CARDS:", "Baccarat is played with 8 decks of 52 cards. The king, queen, jack and 10 have a value of 0,", "the ace has a value of 1, and the other cards are counted at face value. The value of a hand", "is the last digit of the sum of the cards.", "", "THE SHOE:", "Cards are dealt from a shoe. A cut-card is placed in front of the seventh from last card,", "and the drawing of the cut-card indicates the last coup of the shoe. The dealer burns the first", "card face up and then based on its respective numerical value, with aces worth 1 and face", "cards worth 10, the dealer burns that many cards face down.", "", "THE BETS:", "The maximum number of players seated at the table is four. No standing players are ", "allowed. Each player can bet on the player's and/or on the banker's hand and/or on a tie.", "The minimum and maximum bets are 100$ and 500$, respectively. Bets must be made by", "players before the first card is dealt. Bets cannot be added, changed or withdrawn after this ", "point.", "", "THE DEAL:", "Cards are dealt by the dealer. During each deal, the first and third cards dealt from the shoe", "make up the player’s hand, while the second and fourth cards make up the banker’s hand.", "", "Once the cards are dealt, if the value of one of the two hands equals 8 or 9, the hand is", "called a “Natural,” no other card is dealt and the game comes to an end.", "", "If the hands have any other value, the dealer draws a third card or stays for the player’s", "and/or banker’s hand according to rules hereafter.", "", "The Player's rule:", "If the player has an initial total of 5 or less, a third card is drawn to the player. If the player", "has an initial total of 6 or 7, no other card is drawn.", "", "The Banker’s rule:", "If the player’s stands at two cards, the banker acts according to the same rule as the player’s.", "", "If the player drew a third card, the banker acts according to the rules below:", "1. If the banker total is 2 or less, they draw a third card regardless of the player's third card.", "2. If the banker total is 3, they draw a third card unless the player's third card is an 8.", "3. If the banker total is 4, they draw a third card if the player's third card is 2, 3, 4, 5, 6, or 7.", "4. If the banker total is 5, they draw a third card if the player's third card is 4, 5, 6, or 7.", "5. If the banker total is 6, they draw a third card if the player's third card is a 6 or 7.", "6. If the banker total is 7, no other card is drawn.", "", "THE PAYOUTS:", "For bets on the player’s hand:", "1. If the player’s hand is higher than the banker’s hand, bets on the player’s hand win and", "    are paid 100 to 100.", "2. If the player’s hand is lower than the banker’s hand, bets on the player’s hand lose.", "3. If the player’s hand ties with the banker’s hand, bets on the player’s hand are a push.", "", "For bets on the banker’s hand:", "1. If the banker’s hand is higher than the player’s hand, bets on the banker’s hand win and", "    are paid 95 to 100.", "2. If the banker’s hand is lower than the player’s hand, bets on the banker’s hand lose.", "3. If the banker’s hand ties with the player’s hand, bets on the banker’s hand are a push.", "", "For the tie bet:", "1. If the player’s hand ties with the banker’s hand, tie bets win and are paid 800 to 100.", "2. If the player’s hand and the banker’s hand are not equal, tie bets lose." });
            listBox1.Location = new Point(14, 29);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(856, 452);
            listBox1.TabIndex = 1;
            // 
            // Rules
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 535);
            Controls.Add(listBox1);
            Controls.Add(btnReturn);
            Name = "Rules";
            Text = "Rules of Baccart";
            ResumeLayout(false);
        }

        #endregion

        private Button btnReturn;
        private ListBox listBox1;
    }
}