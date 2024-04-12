using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Play {
    internal class PlayingCards {
        private string[] _color = { "Spade", "Diamond", "Club", "Hearth" };
        
        private string[] _face = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

        private string[] _abbr = { "A-S", "2-S", "3-S", "4-S", "5-S", "6-S", "7-S", "8-S", "9-S", "10S", "J-S", "Q-S", "K-S",
            "A-D", "2-D", "3-D", "4-D", "5-D", "6-D", "7-D", "8-D", "9-D", "10D", "J-D", "Q-D", "K-D",
            "K-C", "Q-C", "J-C", "10C", "9-C", "8-C", "7-C", "6-C", "5-C", "4-C", "3-C", "2-C", "A-C",
            "K-H", "Q-H", "J-H", "10H", "9-H", "8-H", "7-H", "6-H", "5-H", "4-H", "3-H", "2-H", "A-H" };

        private int[,] _pack = { {0,0}, {1,0}, {2,0}, {3,0}, {4,0}, {5,0}, {6,0}, {7,0}, {8,0}, {9,0}, {10,0}, {11,0}, {12,0},
            {0,1}, {1,1}, {2,1}, {3,1}, {4,1}, {5,1}, {6,1}, {7,1}, {8,1}, {9,1}, {10,1}, {11,1}, {12,1},
            {12,2}, {11,2}, {10,2}, {9,2}, {8,2}, {7,2}, {6,2}, {5,2}, {4,2}, {3,2}, {2,2}, {1,2}, {0,2},
            {12,3}, {11,3}, {10,3}, {9,3}, {8,3}, {7,3}, {6,3}, {5,3}, {4,3}, {3,3}, {2,3}, {1,3}, {0,3} };

        private string _playLabel = "Play#,PH1,PH2,PH3,BH1,BH2,BH3,Result,P1N,P1A,P1F,P1PB,P1BB,P1BT,P2N,P2A,P2F,P2PB,P2BB,P2BT," +
            "P3N,P3A,P3F,P3PB,P3BB,P3BT,P4N,P4A,P4F,P4PB,P4BB,P4BT,";
        private string _eventLabel = "Event#;Type;";

        private string _playLine = "";
        private string _eventLine = "";
        private string _shoeLine = "";
        private int _playCount = 0;
        private int _eventCount = 0;
        private Boolean _diretoryKnown  = false;
        private string _directoryName = "";
        private Boolean _playFirstUse = true;
        private Boolean _eventFirstUse = true;
        private string _shoeFilename = "Shoe.csv";
        private string _playFilename = "Plays.csv";
        private string _eventFilename = "Events.csv";

        public PlayingCards() { for (int i = 0; i < _abbr.Length; i++) { _eventLabel += _abbr[i] + ","; } }

        public string Color(int n) { return _color[n]; }
        public string Face(int n) { return _face[n]; }
        public string GetLongCardID(int n) { return (Face(_pack[n, 0]) + " of " + Color(_pack[n, 1])); }
        public string GetAbbrCardID(int n) { return _abbr[n]; }
        public void SetDirectoryName(string DirName) { _directoryName = DirName; }
        public void SetDirectoryKnown(Boolean Known) { _diretoryKnown = Known; }

        public void LineUpHands(int[] Player, int[] Banker, Boolean[] ThirdCard, string Results) {
            _playCount++;
            _playLine = "";
            _playLine += "Play#" + _playCount + "," + _abbr[Player[0]] + "," + _abbr[Player[1]] + ",";
            if (ThirdCard[0]) { _playLine += _abbr[Player[2]] + ","; } else { _playLine += ","; }
            _playLine += _abbr[Banker[0]] + "," + _abbr[Banker[1]] + ",";
            if (ThirdCard[1]) { _playLine += _abbr[Banker[2]] + ","; } else { _playLine += ","; }
            _playLine += Results + ",";
        }

        public void LineUpPlayer(int PlayerState, string Name, int Avatar, int Funds, int[] Bets) {
            if (PlayerState == 0) { _playLine += ",,,,,,"; }
            else { _playLine += Name + "," + Avatar + "," + Funds + "," + Bets[0] + "," + Bets[1] + "," + Bets[2] + ","; }
        }

        public void SaveShoe(int Tally, int Position, int[] ShoeN) {
            _shoeLine = Tally + "," + Position + ",";
            for (int i = 0; i < ShoeN.Length; i++) { _shoeLine += ShoeN[i] + ","; }
            WriteInShoeFile();
        }

        public void SavePlay() { }

        public void SavePlayEvent(int Play, int[] Player, int[] Banker, Boolean[] ThirdCard) {
            SetEvent();
            int ExtraCard = 0;
            if (ThirdCard[0]) { ExtraCard += 1; }
            if (ThirdCard[1]) { ExtraCard += 1; }
            int[] TotalCard = new int[4 + ExtraCard];
            TotalCard[0] = Player[0]; TotalCard[1] = Player[1]; TotalCard[2] = Banker[0]; TotalCard[3] = Banker[1];
            if (ThirdCard[0]) { TotalCard[4] = Player[2]; }
            if (ThirdCard[1]) { if (ThirdCard[0]) { TotalCard[5] = Banker[2]; } else { TotalCard[4] = Banker[2]; } }
            _eventLine += "Play#" + Play + "," + SortingCards(TotalCard);
        }

        public void SavePrimingEvent(int Tally, int[] CardP) {
            SetEvent();
            _eventLine += "Priming#" + Tally + "," + SortingCards(CardP);
        }

        public void SaveDrainingEvent(int Tally, int[] CarD) {
            SetEvent();
            _eventLine += "Draining#" + Tally + "," + SortingCards(CarD);
        }

        private string SortingCards(int[] CardPicked) {
            string CardCount = "";
            int[] CardDeck = new int[52];
            int i;
            for (i = 0; i < CardDeck.Length; i++) { CardDeck[i] = 0; }
            for (i = 0; i < CardPicked.Length; i++) { CardDeck[CardPicked[i]] += 1; }
            for (i = 0; i < CardDeck.Length; i++) { CardCount += CardDeck[i] + ","; }
            return CardCount; 
        }

        private void SetEvent() { _eventCount++; _eventLine = ""; }

        private void WriteInShoeFile() {
            if (_diretoryKnown) { 
            }
            string aPath = "C:\\Users\\nicol\\OneDrive\\Documents\\Travail\\Info\\Cours\\420-910-Progr1\\Project\\Test.csv";
            TextWriter txt = null;
            txt = new StreamWriter(aPath);
            txt.Write(_shoeLine);
            txt.Close();
        }

        private void WriteinPlayFile() {
            if (_diretoryKnown) { 
            }
        }

        private void WriteinEventFile() {
            if (_diretoryKnown) { 
            }
        }
    }
}
