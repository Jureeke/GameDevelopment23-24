using GameDevProject.Core.Input;
using GameDevProject.Core.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Testproject;
using Testproject.Utility;

namespace GameDevProject.Core
{
    public class Hero : IGameObject, IMovable
    {
        public Texture2D texture;
        private AnimationManager animationManager;

        public Vector2 spawnPosition = new Vector2(0, 0);
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
            Game = manager;
            texture = Game.RootGame.Content.Load<Texture2D>("Gladiator-SpriteSheet");
            movementManager = new MovementManager();
            animationManager = new AnimationManager();

            // Voeg animaties toe
            var idleAnimation = new Animation();
            idleAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 2, 0);
            animationManager.AddAnimation("Idle", idleAnimation);

            var walkAnimation = new Animation();
            walkAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 1);
            animationManager.AddAnimation("Walk", walkAnimation);

            var attackAnimation = new Animation();
            attackAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 5, 8, 2);
            animationManager.AddAnimation("Attack", attackAnimation);

            // Stel standaard animatie in
            animationManager.SetAnimation("Idle");

            // Calculate the spawn position to be in the bottom-left corner
            spawnPosition = new Vector2(0, Game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight - (64*6) - 27 );


            // Set the hero's initial position to the calculated spawn position
            Position = spawnPosition;

            // Set other properties
            Speed = new Vector2(4, 2); // doubled the speed
            ((IMovable)this).inputReader = new KeyboardReader();

            gravity = 1000f;
            isJumping = false;
            jumpStrength = 700f; // if changed to half can jump 2 blocks
            groundLevel = Position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animationManager.Draw(spriteBatch, texture, Position, Direction);
        }

        public void Update(GameTime gameTime)
        {
            var direction = ((IMovable)this).inputReader.Readinput();
            UpdateAnimation(gameTime, direction);
            Move();
            UpdateJump(gameTime);
        }

        // Method to reset the hero's position when starting a level
        public void ResetPosition()
        {
            Position = spawnPosition;
            groundLevel = Position.Y;
        }

        private void UpdateAnimation(GameTime gameTime, Vector2 direction)
        {
            bool isMoving = direction.X != 0;
            bool isSpecialAction = ((KeyboardReader)((IMovable)this).inputReader).IsSpecialActionTriggered();

            if (isSpecialAction)
            {
                animationManager.SetAnimation("Attack");
            }
            else if (isMoving)
            {
                animationManager.SetAnimation("Walk");
            }
            else
            {
                animationManager.SetAnimation("Idle");
            }

            animationManager.Update(gameTime);
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
