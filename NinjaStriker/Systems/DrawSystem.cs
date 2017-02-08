using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Artemis.Utils;
using NinjaStriker.Components;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaStriker.Systems
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Draw, Layer = 3)]
    internal class DrawSystem : EntityProcessingSystem
    {
        public DrawSystem()
            : base(Aspect.All(typeof(Image)))
        {
        }
        
        public override void Process(Entity entity)
        {
            entity.GetComponent<Image>().Position = entity.GetComponent<ScreenPosition>().position;
            entity.GetComponent<Image>().Draw();
        }
    }
}
