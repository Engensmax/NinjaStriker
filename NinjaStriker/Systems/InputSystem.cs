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

namespace NinjaStriker.Systems
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    internal class InputSystem : EntitySystem
    {
        public InputSystem()
            : base(Aspect.All(typeof(PlatformPosition),typeof(Input),typeof(Image)))
        {
        }

        protected override void ProcessEntities(IDictionary<int, Entity> entities)
        {
            base.ProcessEntities(entities);
            foreach (Entity entity in entities.Values)
            {
                if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                    actionKeysMap[Input.Action.MoveCharacterRight]))
                {
                    entity.GetComponent<PlatformPosition>().position = 4;
                    entity.GetComponent<ScreenPosition>().position = new Vector2(600, 240);
                }
                else if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                    actionKeysMap[Input.Action.MoveCharacterLeft]))
                {
                    entity.GetComponent<PlatformPosition>().position = 2;
                    entity.GetComponent<ScreenPosition>().position = new Vector2(200, 240);
                }
                else if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                    actionKeysMap[Input.Action.MoveCharacterUp]))
                {
                    entity.GetComponent<PlatformPosition>().position = 1;
                    entity.GetComponent<ScreenPosition>().position = new Vector2(400, 140);
                }
                else if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                    actionKeysMap[Input.Action.MoveCharacterDown]))
                {
                    entity.GetComponent<PlatformPosition>().position = 3;
                    entity.GetComponent<ScreenPosition>().position = new Vector2(400, 340);
                }
            }
        }
        

    }
}
