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
    public partial class PlayerSit : Form
    {
        public PlayerSit(int S)
        {
            InitializeComponent();
            SeatNumberLabel.Text = "Let's occupy seat " + S.ToString();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
