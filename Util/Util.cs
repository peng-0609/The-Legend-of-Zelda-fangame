using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    [Serializable]
    class Util
    {
        private static Util instance = new Util();
        public static Util Instance { get => instance; set { instance = value; } }
        private Util()
        {

        }
        private readonly int int_0 = 0;
        public int ZERO { get => int_0; }
        private readonly int int_100 = 100;
        public int HUNDRED { get => int_100; }
        private readonly int int_3 = 3;
        public int Int_3 { get => int_3; }
        private readonly int int_2 = 2;
        public int Int_2 { get => int_2; }
        private readonly int int_1 = 1;
        public int Int_1 { get => int_1; }

    }
}
