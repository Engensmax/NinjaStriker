using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace NinjaStriker
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        public Vector2 Dimensions { private set; get; }
        public ContentManager Content { private set; get; }
        XmlManager<GameScreen> xmlGameScreenManager;

        GameScreen currentScreen, newScreen;
        public GraphicsDevice GraphicsDevice;
        public SpriteBatch SpriteBatch;


        public bool IsTransitioning { get; private set; }

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();

                return instance;
            }
        }

        public void ChangeScreens(string screenName)
        {
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("NinjaStriker." + screenName));

            IsTransitioning = true;
        }
        void Transition(GameTime gameTime)
        {
            if (IsTransitioning)
            {
                /// MAX: potentially implement fade 
                currentScreen.UnloadContent();
                currentScreen = newScreen;
                currentScreen.LoadContent();
                IsTransitioning = false;
            }
        }

        public ScreenManager()
        {
            Dimensions = new Vector2(640, 480);
            currentScreen = new TitleScreen();
            xmlGameScreenManager = new XmlManager<GameScreen>();
            xmlGameScreenManager.Type = currentScreen.Type;
            System.Diagnostics.Debug.WriteLine((currentScreen.Type));
            currentScreen = xmlGameScreenManager.Load("TitleScreen.xml");
            
        }
        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(
                Content.ServiceProvider, "Content");
            currentScreen.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
            Transition(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }

}
