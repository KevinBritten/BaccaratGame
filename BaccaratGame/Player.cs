using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaccaratGame
{
    internal class Player
    {
        private String _name;
        private decimal _funds;
        //TODO: add avatar files
        //private Image _avatar;
        private decimal _currentBet;

        public Player(String name, decimal funds, String avatarFilePath)
        {
            _name = name;
            _funds = funds;
            //_avatar = Image.FromFile(avatarFilePath);
        }

        public String Name
        {
            get { return _name; }
        }

        public decimal Funds
        {
            get { return _funds; }
            set { _funds = value; }
        }

        //public Image Avatar
        //{
        //    get { return _avatar; }
        //}

        public decimal CurrentBet
        {
            get { return _currentBet; }
            set { if (value <= _funds) _currentBet = value;
                else _currentBet = _funds;
            }
        }

        public void clearBet() { _currentBet = 0; }
       
    }
}
