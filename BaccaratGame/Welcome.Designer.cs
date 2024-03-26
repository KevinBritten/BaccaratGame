namespace BaccaratGame
{
    partial class Welcome
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
            btnRules = new Button();
            btnSetTable = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnRules
            // 
            btnRules.Location = new Point(215, 76);
            btnRules.Name = "btnRules";
            btnRules.Size = new Size(94, 29);
            btnRules.TabIndex = 0;
            btnRules.Text = "Rules";
            btnRules.UseVisualStyleBackColor = true;
            // 
            // btnSetTable
            // 
            btnSetTable.Location = new Point(215, 124);
            btnSetTable.Name = "btnSetTable";
            btnSetTable.Size = new Size(94, 29);
            btnSetTable.TabIndex = 1;
            btnSetTable.Text = "Set Table";
            btnSetTable.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(215, 174);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 2;
            btnExit.Text = "Exit Game";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // Welcome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Controls.Add(btnSetTable);
            Controls.Add(btnRules);
            Name = "Welcome";
            Text = "Welcome";
            ResumeLayout(false);
        }

        #endregion

        private Button btnRules;
        private Button btnSetTable;
        private Button btnExit;
    }
}
