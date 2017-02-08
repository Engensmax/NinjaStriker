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
using Artemis.Attributes;
using Artemis.Interface;
using Artemis.Manager;
using Artemis.System;
using Artemis.Utils;

using NinjaStriker.Components;
using NinjaStriker.Templates;
using NinjaStriker.Systems;

namespace NinjaStriker
{
    class GameplayScreen : GameScreen
    {
        private EntityWorld world;

        // private TimeSpan elapsedTime;


        Player player;


        public GameplayScreen()
        {

            this.world = new EntityWorld();

            this.world.InitializeAll(true);

            //var shuriken = world.CreateEntityFromTemplate(ShurikenTemplate.Name);
            //System.Diagnostics.Debug.WriteLine(shuriken.GetComponent<Damage>().damage);
            //shuriken.AddComponentFromPool<Velocity>();

            var entity1 = world.CreateEntityFromTemplate(PlayerTemplate.Name);
        }

        public override void LoadContent()
        {
            base.LoadContent();
            //XmlManager<Player> playerLoader = new XmlManager<Player>();
            //player = playerLoader.Load("Load/Player.xml");
            //player.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            //player.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            EntitySystem.BlackBoard.SetEntry<GameTime>("GameTime", gameTime);
            world.Update();
            //player.Update(gameTime);
            if (InputManager.Instance.KeyPressed(Keys.Escape))
                NinjaStriker.Instance.Exit();
        }

        public override void Draw()
        {

            base.Draw();
            world.Draw();
            ///player.Draw();
        }
    }
}
