using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testproject
{
    internal class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;

        private double secondCounter = 0;
        public Animation()
        {
            frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 15;
            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

        public void GetFramesFromTextureProperties(int widthSpriteSheet, int heightSpriteSsheet, int numberOfWidthSprites, int numberOfHeigtSprites, int length, int height)
        {
            int widthOffFrame = widthSpriteSheet / numberOfWidthSprites;
            int heightOffFrame = heightSpriteSsheet / numberOfHeigtSprites;

            int useHeight = heightOffFrame * height; //Array index denken

            for (int i = 0; i < length; i++)
            {
                for (int x = 0; x < widthOffFrame * length; x += widthOffFrame)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x, useHeight, widthOffFrame, heightOffFrame)));
                }
            }
        }
    }
}
