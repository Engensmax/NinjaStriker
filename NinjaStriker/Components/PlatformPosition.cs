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
    class PlatformPosition : ComponentPoolable
    {
        public int position;

        public PlatformPosition()
        {
            this.position = 1;
        }
            
    }
}
