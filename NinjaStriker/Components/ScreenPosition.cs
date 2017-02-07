using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Artemis;

namespace NinjaStriker.Components
{
    class ScreenPosition : ComponentPoolable
    {
        public Vector2 position;

        public ScreenPosition(Vector2 position)
        {
            this.position = position;
        }
            
    }
}
