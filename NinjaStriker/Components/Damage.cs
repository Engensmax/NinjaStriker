using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;

namespace NinjaStriker.Components
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Damage : ComponentPoolable
    {
        public float damage;

        public Damage(float damage)
        {
            this.damage = damage;
        }
    }
}
