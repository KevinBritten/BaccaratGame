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
    public partial class PlayerWithdraw : Form
    {
        int[] _playerStates;
        int _playerIndex;
        public PlayerWithdraw(int playerIndex, int[] playerStates)
        {
            InitializeComponent();
            _playerStates = playerStates;
            _playerIndex = playerIndex;
        }


        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            _playerStates[_playerIndex] = 1;
            this.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
