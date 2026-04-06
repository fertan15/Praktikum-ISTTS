using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MateriW3
{
    public static class PlayerInfo
    {
        public static int money = 0;
        public static int oak = 0;
        public static int mahogany = 0;
        public static int mystic = 0;

        public static Boolean stoneAxe = true;
        public static Boolean ironAxe = false;
        public static Boolean diamondAxe = false;

        public static int equippedAxe = 0; //0 = stone, 1 = iron, 2 = steel

        public static bool chopped = false;
    }
}
