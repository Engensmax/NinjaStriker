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
        private Image background;

        private void CreatePlayer(int playerNumber, string xmlPath)
        {
            var entity = this.world.CreateEntityFromTemplate(PlayerTemplate.Name);
            entity.GetComponent<PlayerNumber>().playerNumber = playerNumber;

            XmlManager<Image> imageLoader = new XmlManager<Image>();
            Image image = imageLoader.Load(xmlPath);
            entity.AddComponent(image);
            entity.GetComponent<Image>().LoadContent();
            entity.GetComponent<Input>().Initialize(playerNumber);

            if (playerNumber == 1)
            {
                entity.GetComponent<Health>().healthBar.Position =
                    new Vector2(0,
                    ScreenManager.Instance.Dimensions.Y / 2 - entity.GetComponent<Health>().healthBar.SourceRect.Height / 2);
            }
            else if (playerNumber == 2)
            {
                entity.GetComponent<Health>().healthBar.Position =
                    new Vector2(ScreenManager.Instance.Dimensions.X - entity.GetComponent<Health>().healthBar.SourceRect.Width,
                    ScreenManager.Instance.Dimensions.Y / 2 - entity.GetComponent<Health>().healthBar.SourceRect.Height / 2);
            }
            entity.GetComponent<Health>().healthBarFilling.Position = entity.GetComponent<Health>().healthBar.Position + new Vector2(5, 5);


            entity.Refresh();
        }

        public GameplayScreen()
        {
            this.background = new XmlManager<Image>().Load("Load/background.xml");
            
            this.world = new EntityWorld();

            this.world.InitializeAll(true);

            //var shuriken = world.CreateEntityFromTemplate(ShurikenTemplate.Name);
            //System.Diagnostics.Debug.WriteLine(shuriken.GetComponent<Damage>().damage);
            //shuriken.AddComponentFromPool<Velocity>();

            CreatePlayer(1, "Load/ninja2.xml");
            CreatePlayer(2, "Load/ninja3.xml");
        }

        public override void LoadContent()
        {
            background.LoadContent();
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            background.UnloadContent();
            world.UnloadContent();
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            background.Update(gameTime);
            EntitySystem.BlackBoard.SetEntry<GameTime>("GameTime", gameTime);
            world.Update();
            if (InputManager.Instance.KeyPressed(Keys.Escape))
                NinjaStriker.Instance.Exit();
        }

        public override void Draw()
        {
            background.Draw();
            base.Draw();
            world.Draw();
        }
    }
}
