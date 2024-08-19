using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Testproject.Core.Enemy;
using Testproject.Utility.Collision;

namespace Testproject.Map.Tiles
{
    public class Coin : ICollidable
    {
        private GameManager _game;
        private int _x;
        private int _y;
        private int _width = 64;
        private int _height = 64;
        private Texture2D _texture;
        private Animation _animation;
        private bool _isPickedUp;

        // Backing field for the hitbox
        private Rectangle _hitBox;

        private Texture2D _hitboxTexture;


        // Implement the HitBox property
        public Rectangle HitBox
        {
            get => _hitBox;
            set => _hitBox = value;
        }

        public Coin(int x, int y, GameManager game)
        {
            _x = x;
            _y = y;
            _game = game;

            _texture = game.RootGame.Content.Load<Texture2D>("coin1_64");
            _animation = new Animation();

            // Assuming a 64x64 sprite sheet with 8 frames in a single row
            _animation.GetFramesFromTextureProperties(_texture.Width, _texture.Height, 15, 1, 15, 0);

            _isPickedUp = false;

        }

        // Update the animation state of the coin
        public void Update(GameTime gameTime)
        {
            if (!_isPickedUp)
            {
                _animation.Update(gameTime);
                // Update the hitbox position based on the coin's position
                _hitBox = new Rectangle(_x, _y, _width, _height);
            }
        }

        // Draw the coin using the current animation frame
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!_isPickedUp)
            {
                var currentFrame = _animation.CurrentFrame;
                spriteBatch.Draw(_texture, _hitBox, currentFrame.SourceRectangle, Color.White);
            }
        }

        // Handle coin pickup
        public void PickUp()
        {
            if (!_isPickedUp)
            {
                _isPickedUp = true;
                //implement score updates
                _game.score++;
                OnPickedUp();
            }
        }

        // Logic to be executed when the coin is picked up
        private void OnPickedUp()
        {
        }
    }
}
