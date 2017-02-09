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
    internal class TickerSystem : EntityProcessingSystem
    {
        public double elapsedTimeSinceTick = 0;
        public int TickInterval = 2;
        public List<int> causesDamage = new List<int>();

        public TickerSystem()
            : base(Aspect.All(typeof(Image), typeof(PlatformPosition), typeof(ScreenPosition)))
        {
        }

        
        public override void Process(Entity entity)
        {

            entity.GetComponent<Image>().isActive = true;
            entity.GetComponent<Image>().Alpha = 0;

            if (entity.GetComponent<PlatformPosition>().position == 4)
            {
                entity.GetComponent<Image>().SpriteSheetEffect.CurrentFrame.Y = 0;
                entity.GetComponent<ScreenPosition>().position =
                ScreenManager.Instance.Dimensions / 2 +
                new Vector2(150 - entity.GetComponent<Image>().SourceRect.Width / 2,
                            0 - entity.GetComponent<Image>().SourceRect.Height);
            }
            else if (entity.GetComponent<PlatformPosition>().position == 2)
            {
                entity.GetComponent<Image>().SpriteSheetEffect.CurrentFrame.Y = 2;
                entity.GetComponent<ScreenPosition>().position =
                ScreenManager.Instance.Dimensions / 2 +
                new Vector2(-150 - entity.GetComponent<Image>().SourceRect.Width / 2,
                            0 - entity.GetComponent<Image>().SourceRect.Height);
            }
            else if (entity.GetComponent<PlatformPosition>().position == 1)
            {
                entity.GetComponent<Image>().SpriteSheetEffect.CurrentFrame.Y = 1;
                entity.GetComponent<ScreenPosition>().position =
                ScreenManager.Instance.Dimensions / 2 +
                new Vector2(0 - entity.GetComponent<Image>().SourceRect.Width / 2,
                            -150 - entity.GetComponent<Image>().SourceRect.Height);
            }
            else if (entity.GetComponent<PlatformPosition>().position == 3)
            {
                entity.GetComponent<Image>().SpriteSheetEffect.CurrentFrame.Y = 3;
                entity.GetComponent<ScreenPosition>().position =
                ScreenManager.Instance.Dimensions / 2 +
                new Vector2(0 - entity.GetComponent<Image>().SourceRect.Width / 2,
                            150 - entity.GetComponent<Image>().SourceRect.Height);
            }

            foreach (int position in causesDamage)
                if (entity.GetComponent<PlatformPosition>().position == position)
                {
                    Health health = entity.GetComponent<Health>();
                    health.currentHealth--;
                    health.healthBarFilling.Scale.Y = 287 * health.currentHealth / health.maxHealth;
                }

        }

        private void setDamage(IDictionary<int, Entity> entities)
        {
            foreach (Entity entity in entities.Values)
            {
                var damagePosition = entity.GetComponent<PlatformPosition>().position + 1;
                if (damagePosition == 5)
                    damagePosition = 1;
                this.causesDamage.Add(damagePosition);
            }
        }
            
        protected override void ProcessEntities(IDictionary<int, Entity> entities)
        {
            GameTime gameTime = EntitySystem.BlackBoard.GetEntry<GameTime>("GameTime");
            elapsedTimeSinceTick += gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedTimeSinceTick >= TickInterval)
            {
                elapsedTimeSinceTick -= TickInterval;
                setDamage(entities);
                base.ProcessEntities(entities);
                this.causesDamage = new List<int>();
            }
            
            //System.Diagnostics.Debug.WriteLine(EntitySystem.BlackBoard.GetEntry<GameTime>("GameTime").TotalGameTime);
        }
    }
}
