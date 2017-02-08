using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;

namespace NinjaStriker.Components
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class PlayerNumber : ComponentPoolable
    {
        public int playerNumber;

        public PlayerNumber()
        {
            this.playerNumber = 1;
        }
    }
}
