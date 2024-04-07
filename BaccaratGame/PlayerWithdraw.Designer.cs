namespace BaccaratGame
{
    partial class PlayerWithdraw
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
            SeatNumberLabel = new Label();
            button1 = new Button();
            panel1 = new Panel();
            button2 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // SeatNumberLabel
            // 
            SeatNumberLabel.AutoSize = true;
            SeatNumberLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SeatNumberLabel.Location = new Point(12, 18);
            SeatNumberLabel.Name = "SeatNumberLabel";
            SeatNumberLabel.Size = new Size(700, 41);
            SeatNumberLabel.TabIndex = 2;
            SeatNumberLabel.Text = "Would you like to take your winnings and leave?";
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Yes!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(214, 91);
            panel1.Name = "panel1";
            panel1.Size = new Size(296, 41);
            panel1.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(103, 3);
            button2.Name = "button2";
            button2.Size = new Size(187, 29);
            button2.TabIndex = 4;
            button2.Text = "No, keep playing.";
            button2.UseVisualStyleBackColor = true;
            button2.Click += this.button2_Click;
            // 
            // PlayerWithdraw
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 152);
            Controls.Add(panel1);
            Controls.Add(SeatNumberLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PlayerWithdraw";
            Text = "Welcome for playing";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SeatNumberLabel;
        private Button button1;
        private Panel panel1;
        private Button button2;
    }
}