using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Artemis;

namespace NinjaStriker
{
    class TilePosition : ComponentPoolable
    {
        public int position;

        public TilePosition(int position)
        {
            this.position = position;
        }
            
    }
}
