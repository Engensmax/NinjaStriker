using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Artemis;
using Artemis.System;
using NinjaStriker.Components;
using NinjaStriker.Templates;

namespace NinjaStriker
{
    class GameplayScreen : GameScreen
    {
        EntityWorld world;
        Player player;

        
        public GameplayScreen()
        {
            this.world = new EntityWorld();
            var ninja = world.CreateEntityFromTemplate("ShurikenTemplate");
        }

        public override void LoadContent()
        {
            base.LoadContent();
            XmlManager<Player> playerLoader = new XmlManager<Player>();
            player = playerLoader.Load("Load/Player.xml");
            player.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            world.Update();
            player.Update(gameTime);
            if (InputManager.Instance.KeyPressed(Keys.Escape))
                NinjaStriker.Instance.Exit();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            world.Draw();
            player.Draw(spriteBatch);
        }
    }
}
