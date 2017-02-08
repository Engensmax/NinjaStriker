using Artemis;
using Artemis.Attributes;
using Artemis.Interface;

using NinjaStriker.Components;
using Microsoft.Xna.Framework;

namespace NinjaStriker.Templates
{

    /// <summary>The player template.</summary>
    [ArtemisEntityTemplate(Name)]
    public class PlayerTemplate : IEntityTemplate
    {
        /// <summary>The name.</summary>
        public const string Name = "Player";

        /// <summary>The build entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="entityWorld">The entityWorld.</param>
        /// <param name="args">The args.</param>
        /// <returns>The <see cref="Entity" />.</returns>
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            entity.AddComponentFromPool<Health>();
            entity.AddComponentFromPool<ScreenPosition>();
            entity.AddComponentFromPool<PlatformPosition>();
            entity.AddComponentFromPool<PlayerNumber>();
            entity.AddComponentFromPool<Input>();

            entity.Refresh();
            
            return entity;
        }
    }
}