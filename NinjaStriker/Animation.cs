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
    public class Animation : Appearance
    {
        private Texture2D texture { get; set; }
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int totalFrames;
        private int currentFrame;
        private int[] frames;

        public Animation() { }
        public Animation(Texture2D texture, int rows, int columns, int[] frames)
        {
            this.texture = texture;
            this.Rows = rows;
            this.Columns = columns;
            this.currentFrame = 0;
            this.frames = frames;
            this.totalFrames = frames.Length;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = texture.Width / Columns;
            int height = texture.Height / Rows;
            int row = frames[currentFrame] % Rows;
            int column = (frames[currentFrame] - row) / Rows;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        
    }
}
