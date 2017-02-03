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

    class Character
    {
        private int ID;
        private Placement placement;
        private Dictionary<string, Animation> animations;

        public Character(int ID, Texture2D textureAtlas, int columns, int rows, Placement placement)
        {
            this.ID = ID;
            animations = new Dictionary<string, Animation>();
            animations.Add("stand", new Animation(textureAtlas, columns, rows, new int[] { 0, 1, 2, 3, 4, 5, 6 }));
            animations.Add("jump", new Animation(textureAtlas, columns, rows, new int[] { 12, 13, 14, 15 }));
            animations.Add("shoot", new Animation(textureAtlas, columns, rows, new int[] { 24, 25, 26, 27, 28, 29 }));
            this.placement = placement;
        }

        public void Update()
        {
            animations["stand"].Update();
            animations["jump"].Update();
            animations["shoot"].Update();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            animations["stand"].Draw(spriteBatch, placement.position);

        }
    }
}