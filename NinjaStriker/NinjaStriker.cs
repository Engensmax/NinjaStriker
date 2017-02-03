using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using Artemis;

namespace NinjaStriker
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class NinjaStriker : Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 texturePos;
        private Character ninja;

        public NinjaStriker()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            texturePos = new Vector2(50, 50);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            var world = new EntityWorld();
            var entity = world.CreateEntity();
            entity.AddComponent(new Velocity(5, 30));
            entity.AddComponent(new Animation());


            graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;

            base.Initialize();
            /// IsMouseVisible = true;
            System.Diagnostics.Debug.WriteLine("Initialization");
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ScreenManager.Instance.GraphicsDevice = GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = spriteBatch;
            ScreenManager.Instance.LoadContent(this.Content);
            texture = this.Content.Load<Texture2D>("Ninja");

            ninja = new Character(1, texture, 6, 6, new Placement(texturePos));
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ScreenManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            ScreenManager.Instance.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
