using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;

namespace NinjaStriker.Components
{
    class PlayerNumber : ComponentPoolable
    {
        public int playerNumber;

        PlayerNumber(int playerNumber)
        {
            this.playerNumber = playerNumber;
        }
    }
}
