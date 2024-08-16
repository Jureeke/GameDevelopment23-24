using GameDevProject.Utility.Animation;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

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
            counter = 0;
        }

        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);

            // Set CurrentFrame to the first frame if it hasn't been set yet
            if (CurrentFrame == null && frames.Count > 0)
            {
                CurrentFrame = frames[0];
            }
        }

        public void Update(GameTime gameTime)
        {
            if (frames.Count == 0)
            {
                throw new InvalidOperationException("No frames have been added to the animation.");
            }

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

            CurrentFrame = frames[counter];
        }

        public void GetFramesFromTextureProperties(int widthSpriteSheet, int heightSpriteSheet, int numberOfWidthSprites, int numberOfHeightSprites, int length, int height)
        {
            int widthOfFrame = widthSpriteSheet / numberOfWidthSprites;
            int heightOfFrame = heightSpriteSheet / numberOfHeightSprites;

            int useHeight = heightOfFrame * height; // Calculate starting height

            for (int i = 0; i < length; i++)
            {
                for (int x = 0; x < widthSpriteSheet; x += widthOfFrame)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x, useHeight, widthOfFrame, heightOfFrame)));
                }
            }

            // Set the CurrentFrame to the first frame if frames were added
            if (frames.Count > 0)
            {
                CurrentFrame = frames[0];
            }
        }
    }
}
