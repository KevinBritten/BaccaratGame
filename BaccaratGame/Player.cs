using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaccaratGame
{
    public class Player
    {
        private String _name;
        private int _funds;
        //TODO: add avatar files
        //private Image _avatar;
        private int[] _bets = new int[3]; 

        public Player(String name, int funds, String avatarFilePath)
        {
            _name = name;
            _funds = funds;
            //_avatar = Image.FromFile(avatarFilePath);
        }

        public String Name
        {
            get { return _name; }
        }

        public int Funds
        {
            get { return _funds; }
            set {
                _funds = value;
                OnMyFundsChanged();
            }
        }

        //public Image Avatar
        //{
        //    get { return _avatar; }
        //}

        public int[] Bets
        {
            get { return _bets; }
        }
    

        public void clearAllBets() { 
            for (int i = 0; i < _bets.Length; i++)
            {
                _bets[i] = 0;
            }
        }

        public event EventHandler FundsChanged;

        protected virtual void OnMyFundsChanged()
        {
            FundsChanged?.Invoke(this, EventArgs.Empty);
        }

        public void unsubscribeAllListeners()
        {
            FundsChanged = null;
        }

        public void updateBet(int index, int value)
        {
            _bets[index] = value;
        }
    }
}
