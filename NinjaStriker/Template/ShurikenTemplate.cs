﻿using Artemis;
using Artemis.Attributes;
using Artemis.Interface;

using NinjaStriker.Components;

namespace NinjaStriker.Template
{

    /// <summary>The shuriken template.</summary>
    [ArtemisEntityTemplate(Name)]
    public class ShurikenTemplate : IEntityTemplate
    {
        /// <summary>The name.</summary>
        public const string Name = "ShurikenTemplate";

        /// <summary>The build entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="entityWorld">The entityWorld.</param>
        /// <param name="args">The args.</param>
        /// <returns>The <see cref="Entity" />.</returns>
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            entity.AddComponent(new Damage(1f));
            
            entity.Refresh();
            
            return entity;
        }
    }
}