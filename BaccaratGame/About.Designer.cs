namespace BaccaratGame
{
    partial class About
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            ReturnButton = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ProjectTiltleLabel = new Label();
            PurposeLabel = new Label();
            AuthorLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // ReturnButton
            // 
            ReturnButton.Location = new Point(606, 305);
            ReturnButton.Margin = new Padding(3, 2, 3, 2);
            ReturnButton.Name = "ReturnButton";
            ReturnButton.Size = new Size(82, 22);
            ReturnButton.TabIndex = 2;
            ReturnButton.Text = "Return";
            ReturnButton.UseVisualStyleBackColor = true;
            ReturnButton.Click += ReturnButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(39, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 180);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(128, 125);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(120, 180);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // ProjectTiltleLabel
            // 
            ProjectTiltleLabel.AutoSize = true;
            ProjectTiltleLabel.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProjectTiltleLabel.Location = new Point(215, 19);
            ProjectTiltleLabel.Name = "ProjectTiltleLabel";
            ProjectTiltleLabel.Size = new Size(462, 50);
            ProjectTiltleLabel.TabIndex = 5;
            ProjectTiltleLabel.Text = "Baccarat Game Simulator";
            // 
            // PurposeLabel
            // 
            PurposeLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PurposeLabel.Location = new Point(277, 83);
            PurposeLabel.Name = "PurposeLabel";
            PurposeLabel.Size = new Size(350, 100);
            PurposeLabel.TabIndex = 6;
            PurposeLabel.Text = "Project for Course 420-910, Programming Concepts 1, Vanier College, April 2024 ";
            // 
            // AuthorLabel
            // 
            AuthorLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AuthorLabel.Location = new Point(277, 209);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new Size(240, 70);
            AuthorLabel.TabIndex = 7;
            AuthorLabel.Text = "By Kevin Britten and Nicolas Lauzon";
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(AuthorLabel);
            Controls.Add(PurposeLabel);
            Controls.Add(ProjectTiltleLabel);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(ReturnButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "About";
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button ReturnButton;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label ProjectTiltleLabel;
        private Label PurposeLabel;
        private Label AuthorLabel;
    }
}
