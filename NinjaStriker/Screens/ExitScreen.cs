﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NinjaStriker;

namespace NinjaStriker
{
    public class ExitScreen : GameScreen
    {

        public override void LoadContent()
        {
            base.LoadContent();
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            NinjaStriker.Instance.Exit();

        }
                
        public override void Draw()
        {
            base.Draw();
        }
    }
}
