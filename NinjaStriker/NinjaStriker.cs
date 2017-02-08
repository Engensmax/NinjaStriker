using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using Artemis;
using Artemis.System;

namespace NinjaStriker
{
    public class NinjaStriker : Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private static NinjaStriker instance;
        
        public static NinjaStriker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NinjaStriker();
                }
                return instance;
            }
        }

        public NinjaStriker()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;
            graphics.ApplyChanges();

            base.Initialize();
            // IsMouseVisible = true;
            System.Diagnostics.Debug.WriteLine("Initialization");

            EntitySystem.BlackBoard.SetEntry("ContentManager", this.Content);
            EntitySystem.BlackBoard.SetEntry("GraphicsDevice", this.GraphicsDevice);
            EntitySystem.BlackBoard.SetEntry("SpriteBatch", this.spriteBatch);

            // EntitySystem.BlackBoard.SetEntry("SpriteFont", this.font);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ScreenManager.Instance.graphicsDevice = GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = spriteBatch;
            ScreenManager.Instance.LoadContent(this.Content);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            ScreenManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            ScreenManager.Instance.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
