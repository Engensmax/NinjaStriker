using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
namespace NinjaStriker.Components
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Health : ComponentPoolable
    {
        public float health;

        public Health()
        {
            this.health = 1;
        }

        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
