using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testproject.UI.Elements;

namespace Testproject.UI
{
    public class DeathScreen : IGameObject
    {
        private GameManager _game;
        private SpriteFont _font;

        private Texture2D _plainTexture;

        private Text _titleText;
        private Button _exitButton;

        public DeathScreen(GameManager game)
        {
            _game = game;
            _plainTexture = new Texture2D(_game.RootGame.GraphicsDevice, 1, 1);
            _plainTexture.SetData(new[] { Color.White });

            _font = _game.RootGame.Content.Load<SpriteFont>("font");

            // UI element initialization
            Vector2 titleTextPosition = new Vector2(_game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth / 2,
                _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight / 4);
            _titleText = new Text("You Died!", titleTextPosition, _font, 5);

            Vector2 startButtonPosition = new Vector2(_game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth / 2,
                _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight / 2);
            _exitButton = new Button("Exit", startButtonPosition, _font, _plainTexture, () => 
            {
                System.Environment.Exit(0);
            }, 5);
        }

        public void Update(GameTime time)
        {
            _exitButton.Update(time);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw background
            spriteBatch.Draw(_plainTexture, new Rectangle(0, 0, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight), Color.Black);

            // UI elements
            _titleText.Draw(spriteBatch);
            _exitButton.Draw(spriteBatch);
        }
    }
}
