using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml.Serialization;

namespace NinjaStriker
{
    public class Player
    {

        public Image image;
        public Vector2 Velocity;
        public float MoveSpeed;

        public Player()
        {
            Velocity = Vector2.Zero;
        }
        public void LoadContent()
        {
            image.LoadContent();
        }
        public void UnloadContent()
        {
            image.UnloadContent();
        }
        public void Update(GameTime gameTime)
        {
            image.IsActive = true;
            if (InputManager.Instance.KeyPressed(Keys.Tab))
                image.SpriteSheetEffect.CurrentFrame.Y++;

            

            if (Velocity.X == 0)
            {
                if (InputManager.Instance.KeyDown(Keys.S))
                {
                    image.SpriteSheetEffect.CurrentFrame.Y = 10;
                    Velocity.Y = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else if (InputManager.Instance.KeyDown(Keys.W))
                {
                    image.SpriteSheetEffect.CurrentFrame.Y = 8;
                    Velocity.Y = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                    Velocity.Y = 0;
            }
            if (Velocity.Y == 0)
            {
                if (InputManager.Instance.KeyDown(Keys.A))
                {
                    image.SpriteSheetEffect.CurrentFrame.Y = 9;
                    Velocity.X = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                else if (InputManager.Instance.KeyDown(Keys.D))
                {
                    image.SpriteSheetEffect.CurrentFrame.Y = 11;
                    Velocity.X = +MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                    Velocity.X = 0;
            }

            if (Velocity.X == 0 && Velocity.Y == 0 && !InputManager.Instance.KeyDown(Keys.Space) && !InputManager.Instance.ButtonDown(Buttons.A))
                image.IsActive = false;

            image.Update(gameTime);
            image.Position += Velocity;
        }
        public void Draw()
        {
            image.Draw();
        }
    }
}
