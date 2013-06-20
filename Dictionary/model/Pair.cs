using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dictionary
{
    struct Pair
    {
        public string EngWord;
        public string RusWord;

        public Pair(string en, string ru)
        {
            EngWord = en;
            RusWord = ru;
        }
    }
}
