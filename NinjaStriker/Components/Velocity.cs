using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Microsoft.Xna.Framework;


namespace NinjaStriker.Components
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Velocity : ComponentPoolable
    {
        private float velocity;
        private float angle;

        public Velocity() { }

        public Velocity(float vector)
        {
            velocity = vector;
        }

        public Velocity(float velocity, float angle)
        {
            this.velocity = velocity;
            this.angle = angle;
        }

        public float Speed { get; set; }

        public float Angle { get; set; }

        public void AddAngle(float a)
        {
            angle = (angle + a) % 360;
        }

        public float AngleAsRadians
        {
            get { return (float)Math.PI * angle / 180.0f; }
        }

        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
