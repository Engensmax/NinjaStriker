using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Artemis;

namespace NinjaStriker.Components
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class ScreenPosition : ComponentPoolable
    {
        public Vector2 position;

        public ScreenPosition()
        {
            this.position = Vector2.Zero;
        }
            
    }
}
