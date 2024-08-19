using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Testproject.Map.Tiles
{
    public class Coin
    {
        private GameManager _game;
        private int _x;
        private int _y;
        private int _width = 64;
        private int _height = 64;
        private Texture2D _texture;
        private Animation _animation;
        private bool _isPickedUp;

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
            }
        }

        // Draw the coin using the current animation frame
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!_isPickedUp)
            {
                var currentFrame = _animation.CurrentFrame;
                spriteBatch.Draw(_texture, new Rectangle(_x, _y, _width, _height), currentFrame.SourceRectangle, Color.White);
            }
        }

        // Handle coin pickup
        public void PickUp()
        {
            if (!_isPickedUp)
            {
                _isPickedUp = true;
                OnPickedUp();
            }
        }

        // Logic to be executed when the coin is picked up
        private void OnPickedUp()
        {
            // Add any additional logic here, like playing a sound or updating the score
        }
    }
}
