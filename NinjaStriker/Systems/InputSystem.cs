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
    internal class InputSystem : EntityProcessingSystem
    {
        public InputSystem()
            : base(Aspect.All(typeof(PlatformPosition),typeof(Input),typeof(Image)))
        {
        }

        public override void Process(Entity entity)
        {
            if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                actionKeysMap[Input.Action.MoveCharacterRight]))
            {
                entity.GetComponent<PlatformPosition>().position = 4;
            }
            else if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                actionKeysMap[Input.Action.MoveCharacterLeft]))
            {
                entity.GetComponent<PlatformPosition>().position = 2;
            }
            else if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                actionKeysMap[Input.Action.MoveCharacterUp]))
            {
                entity.GetComponent<PlatformPosition>().position = 1;
            }
            else if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                actionKeysMap[Input.Action.MoveCharacterDown]))
            {
                entity.GetComponent<PlatformPosition>().position = 3;
            }
            
        }
        

    }
}
