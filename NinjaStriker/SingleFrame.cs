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
    public class SingleFrame : Appearance
    {
        private Texture2D texture { get; set; }
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int frameNumber;

        public SingleFrame(Texture2D texture, int rows, int columns, int frameNumber)
        {
            this.texture = texture;
            this.Rows = rows;
            this.Columns = columns;
            this.frameNumber = frameNumber;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = texture.Width / Columns;
            int height = texture.Height / Rows;
            int row = frameNumber % Rows;
            int column = (frameNumber - row) / Rows;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

    }
}
