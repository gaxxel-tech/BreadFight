using BreadFight.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadFight.GlobalData
{
    public static class GlobalData
    {
        private static int coin = 0;
        public static int Coin { get { return coin; } set { coin = value; } }

        private static float playerAtkSpeed = 1f;
        public static float PlayerAtkSpeed { get { return playerAtkSpeed; } set { playerAtkSpeed = value; } }
        
        private static int playerHPMax = 20;
        public static int PlayerHPMax { get { return playerHPMax; } set { playerHPMax = value; } }

        


    }
}
