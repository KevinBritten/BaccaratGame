namespace BaccaratGame
{
    partial class PlayerBusted
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
            BustedPlayerLabel = new Label();
            button1 = new Button();
            label2 = new Label();
            panel1 = new Panel();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // BustedPlayerLabel
            // 
            BustedPlayerLabel.AutoSize = true;
            BustedPlayerLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BustedPlayerLabel.Location = new Point(1, 9);
            BustedPlayerLabel.Name = "BustedPlayerLabel";
            BustedPlayerLabel.Size = new Size(696, 41);
            BustedPlayerLabel.TabIndex = 2;
            BustedPlayerLabel.Text = "Sorry, you don't have enough funds to continue.";
            // 
            // button1
            // 
            button1.Location = new Point(302, 170);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "Goodbye.";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(236, 66);
            label2.Name = "label2";
            label2.Size = new Size(227, 28);
            label2.TabIndex = 6;
            label2.Text = "Please top up or get out.";
            // 
            // panel1
            // 
            panel1.Controls.Add(numericUpDown1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(224, 114);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 40);
            panel1.TabIndex = 7;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(93, 7);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 10);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 5;
            label1.Text = "Add funds:";
            // 
            // PlayerBusted
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(709, 239);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(BustedPlayerLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PlayerBusted";
            Text = "Game time decision for the player";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label BustedPlayerLabel;
        private Button button1;
        private Label label2;
        private Panel panel1;
        private NumericUpDown numericUpDown1;
        private Label label1;
    }
}