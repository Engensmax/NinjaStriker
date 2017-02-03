using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Artemis;

namespace NinjaStriker
{
    class Placement : ComponentPoolable
    {
        public Vector2 position;
        public float scaling { get; set; }


        public Placement(Vector2 position)
        {
            this.position = position;
        }
            
    }
}
