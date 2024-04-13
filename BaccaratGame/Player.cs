using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BaccaratGame
{
    public class Player
    {
        private String _name;
        private int _funds;
        private Image _avatar;
        private string _avatarName;
        private int[] _bets = new int[3];

        public Player(String name, int funds)
        {
            _name = name;
            _funds = funds;
        }

        public String Name
        {
            get { return _name; }
        }

        public int Funds
        {
            get { return _funds; }
            set
            {
                _funds = value;
                OnMyFundsChanged();
            }
        }

        public Image Avatar
        {
            set
            {
                _avatar = value;
                OnMyAvatarChanged();
            }
            get { return _avatar; }
        }

        public string AvatarName
        {
            get { return _avatarName; }
            set
            {
                _avatarName = value;
                Avatar = getAvatarImage(value);
            }
        }

        public Image getAvatarImage(string avatarName)
        {
            ResourceManager resourceManager = new ResourceManager("BaccaratGame.Properties.Resources", Assembly.GetExecutingAssembly());
            object imageObject = resourceManager.GetObject(avatarName);
            return (Image)imageObject;
        }

        public int[] Bets
        {
            get { return _bets; }
        }


        public void clearAllBets()
        {
            for (int i = 0; i < _bets.Length; i++)
            {
                _bets[i] = 0;
            }
        }

        public void changeAvatarMood()
        {
            Avatar = getAvatarImage(_avatarName);
        }
        public void changeAvatarMood(string mood)
        {
            Avatar = getAvatarImage($"{_avatarName}-{mood}");
        }

        public event EventHandler FundsChanged;

        protected virtual void OnMyFundsChanged()
        {
            FundsChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler AvatarChanged;

        protected virtual void OnMyAvatarChanged()
        {
            AvatarChanged?.Invoke(this, EventArgs.Empty);
        }

        public void unsubscribeAllListeners()
        {
            FundsChanged = null;
            AvatarChanged = null;
        }

        public void updateBet(int index, int value)
        {
            _bets[index] = value;
        }
    }
}
