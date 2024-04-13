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
    public partial class PlayerBusted : Form
    {

        Player[] _players;
        int _playerIndex;
        public PlayerBusted(int playerIndex, Player[] players)
        {
            InitializeComponent();
            _players = players;
            _playerIndex = playerIndex;
            SetHeaderText();
        }

        private void SetHeaderText()
        {
            BustedPlayerLabel.Text = $"Sorry {_players[_playerIndex].Name}, you don't have enough funds to continue.";
        }
        private void FundsInput_ValueChanged(object sender, EventArgs e)
        {
            ConfirmButton.Text = FundsInput.Value > 0 ? "Add Funds" : "Goodbye.";
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (FundsInput.Value > 0) { _players[_playerIndex].Funds += (int)FundsInput.Value; }
            this.Close();
        }
    }
}
