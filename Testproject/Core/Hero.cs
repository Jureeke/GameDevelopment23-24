using GameDevProject.Core.Input;
using GameDevProject.Core.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Testproject;

namespace GameDevProject.Core
{
    public class Hero : IGameObject, IMovable
    {
        public Texture2D texture;
        private Animation animation;
        public Vector2 spawnPosition = new Vector2(0,0);

        private GameManager Game;

        private MovementManager movementManager;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Direction { get; set; }
        IInputReader IMovable.inputReader { get; set; }

        private float gravity;
        private bool isJumping;
        private float jumpStrength;
        private float groundLevel;

        public Hero(GameManager manager)
        {
            this.Game = manager;
            this.texture = Game.RootGame.Content.Load<Texture2D>("Gladiator-SpriteSheet");
            animation = new Animation();
            movementManager = new MovementManager();

            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 1);

            // Calculate the spawn position to be in the bottom-left corner
            spawnPosition = new Vector2(0, Game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight - 192 -27  - 192);


            // Set the hero's initial position to the calculated spawn position
            Position = spawnPosition;

            // Set other properties
            Speed = new Vector2(4, 2); // doubled the speed
            ((IMovable)this).inputReader = new KeyboardReader();

            gravity = 1000f; // if changed to half can jump 2 blocks
            isJumping = false;
            jumpStrength = 450f;
            groundLevel = Position.Y;
        }

        // Method to reset the hero's position when starting a level
        public void ResetPosition()
        {
            Position = spawnPosition;
            groundLevel = Position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (animation.CurrentFrame == null)
            {
                throw new InvalidOperationException("CurrentFrame is null. Ensure that the animation is initialized properly.");
            }

            SpriteEffects spriteEffect = Direction.X >= 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0, Vector2.Zero, 1.5f, spriteEffect, 0f);
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
