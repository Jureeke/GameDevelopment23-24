﻿using GameDevProject.Core.Input;
using GameDevProject.Core.Movement;
using GameDevProject.Utility.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testproject;

namespace GameDevProject.Core
{
    internal class Hero : IGameObject, IMovable
    {
        private Texture2D texture;
        private Animation animation;

        private MovementManager movementManager;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Direction { get; set; }
        IInputReader IMovable.inputReader { get; set; }

        private float gravity;
        private bool isJumping;
        private float jumpStrength;
        private float groundLevel;

        public Hero(Texture2D texture, IInputReader inputReader, Vector2 postiiton, Vector2 speed)
        {
            this.texture = texture;
            animation = new Animation();
            movementManager = new MovementManager();

            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 1);

            ((IMovable)this).Position = postiiton;
            ((IMovable)this).Speed = speed;
            ((IMovable)this).inputReader = inputReader;

            gravity = 1000f;
            isJumping = false;
            jumpStrength = 450f;
            groundLevel = postiiton.Y;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects spriteeffect = ((IMovable)this).Direction.X >= 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, ((IMovable)this).Position, animation.CurrentFrame.SourceRectangle, Color.White, 0, Vector2.Zero, 1f, spriteeffect, 0f);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            Move();
            UpdateJump(gameTime);
        }

        private void Move()
        {
            movementManager.Move(this);
        }

        public void Jump()
        {
            if (!isJumping)
            {
                Speed = new Vector2(Speed.X, -jumpStrength);
                isJumping = true;
            }
        }

        private void UpdateJump(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (isJumping)
            {
                Speed = new Vector2(Speed.X, Speed.Y + gravity * deltaTime);
            }

            Position += Speed * deltaTime;

            if (Position.Y >= groundLevel)
            {
                Position = new Vector2(Position.X, groundLevel);
                Speed = new Vector2(Speed.X, 0);
                isJumping = false;
            }
        }
    }
}
