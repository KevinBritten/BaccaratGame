using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public PlayingCards() { }

        public string Color(int n) { return _color[n]; }
        public string Face(int n) { return _face[n]; }
        public string GetLongCardID(int n) { return (Face(_pack[n, 0]) + " of " + Color(_pack[n, 1])); }
        public string GetAbbrCardID(int n) { return _abbr[n]; }
    }
}
