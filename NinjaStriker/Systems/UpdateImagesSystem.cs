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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaStriker.Systems
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    internal class UpdateImagesSystem : EntityProcessingSystem
    {
        public UpdateImagesSystem()
            : base(Aspect.All(typeof(Image)))
        {
        }
        
        public override void Process(Entity entity)
        {
            entity.GetComponent<Image>().Update(EntitySystem.BlackBoard.GetEntry<GameTime>("GameTime"));
            //System.Diagnostics.Debug.WriteLine(EntitySystem.BlackBoard.GetEntry<GameTime>("GameTime").TotalGameTime);
        }
    }
}
