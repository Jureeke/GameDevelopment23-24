using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Testproject.Core.GameStates;
using Testproject.UI.Elements;

namespace Testproject.UI
{
    public class StartScreen : IGameObject
    {
        private GameManager _game;
        private SpriteFont _font;
        private Texture2D _backgroundTexture;
        private Texture2D _buttonTexture;

        private Text _titleText;
        private Text _objectiveText;
        private Button _startButton;

        public StartScreen(GameManager game)
        {
            _game = game;
            _font = _game.RootGame.Content.Load<SpriteFont>("font");
            _backgroundTexture = _game.RootGame.Content.Load<Texture2D>("StartscreenBackground");
            _buttonTexture = new Texture2D(_game.RootGame.GraphicsDevice, 1, 1);
            _buttonTexture.SetData(new[] { Color.CornflowerBlue });

            int width = _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth;
            int height = _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight;

            // Base Y position for the first element
            float baseYPosition = height / 6f;
            float padding = 100f; // Space between elements
            float scaleFactor = 5f;
            float fontHeight = 12f * scaleFactor; // Font height with scaling

            // Title Text
            Vector2 titleTextPosition = new Vector2(width / 2f, baseYPosition);
            _titleText = new Text("Coin Quest", titleTextPosition, _font, scaleFactor, Color.Black);

            // Update base Y position for the next element
            baseYPosition += fontHeight + padding;

            // Objective Text
            Vector2 objectiveTextPosition = new Vector2(width / 2f, baseYPosition);
            _objectiveText = new Text("Collect all coins to win and don't die", objectiveTextPosition, _font, scaleFactor, Color.Black);

            // Update base Y position for the next element
            baseYPosition += fontHeight + padding;

            // Start Button
            Vector2 startButtonPosition = new Vector2(width / 2f, baseYPosition);
            _startButton = new Button("Start", startButtonPosition, _font, _buttonTexture, () =>
            {
                _game.GoToState<PlayingState>();
            }, scaleFactor);
        }

        public void Update(GameTime time)
        {
            _startButton.Update(time);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw background
            spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight), Color.White);

            // Draw UI elements
            _titleText.Draw(spriteBatch);
            _objectiveText.Draw(spriteBatch);
            _startButton.Draw(spriteBatch);
        }
    }
}
