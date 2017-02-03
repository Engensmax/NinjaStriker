using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaStriker
{
    public class MenuManager
    {
        Menu menu;

        public MenuManager()
        {
            menu = new Menu();
            menu.OnMenuChange += menu_OnMenuChange;
        }

        void menu_OnMenuChange(object sender, EventArgs e)
        {
            XmlManager<Menu> xmlMenuManager = new XmlManager<Menu>();
            xmlMenuManager.Type = menu.type;
            menu.UnloadContent();
            menu = xmlMenuManager.Load(menu.ID);
            
            /// Transition
            menu.LoadContent();
        }
        public void LoadContent(string menuPath)
        {
            if (menuPath != String.Empty)
                menu.ID = menuPath;
        }
        public void UnloadContent()
        {
            menu.UnloadContent();
        }
        public void Update(GameTime gameTime)
        {
            menu.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }
    }
}
