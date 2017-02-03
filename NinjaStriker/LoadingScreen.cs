using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NinjaStriker
{
    class LoadingScreen : GameScreen
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

            if (InputManager.Instance.KeyPressed(Keys.D))
            {
                ScreenManager.Instance.ChangeScreens("TitleScreen");
                System.Diagnostics.Debug.WriteLine("Changing to TitleScreen");
            }
        }
                
        

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
