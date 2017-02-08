using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Microsoft.Xna.Framework.Input;

namespace NinjaStriker.Components
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Input : ComponentPoolable
    {

        public enum Action
        {
            MoveCharacterUp,
            MoveCharacterDown,
            MoveCharacterLeft,
            MoveCharacterRight,
            
        }

        public Dictionary<Action, Keys> actionKeysMap;

        public Input()
        {
            this.actionKeysMap = new Dictionary<Action, Keys>();
            this.actionKeysMap.Add(Action.MoveCharacterUp, Keys.W);
            this.actionKeysMap.Add(Action.MoveCharacterLeft, Keys.A);
            this.actionKeysMap.Add(Action.MoveCharacterDown, Keys.S);
            this.actionKeysMap.Add(Action.MoveCharacterRight, Keys.D);

        }
    }
}