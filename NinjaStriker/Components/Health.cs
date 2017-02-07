using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
namespace NinjaStriker.Components
{
    class Health : ComponentPoolable
    {
        public int health;

        public Health()
        {
            this.health = 3;
        }

        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
