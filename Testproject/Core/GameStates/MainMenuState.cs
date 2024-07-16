using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testproject.Utility.StateMachine;
using Testproject.UI.Elements;

namespace Testproject.Core.GameStates
{
    public class MainMenuState : State
    {
        private Button startButton;
        private Texture2D buttonTexture;

        public MainMenuState(Game1 game, GameManager gameManager) : base(game, gameManager)
        {
            buttonTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            buttonTexture.SetData(new[] { Color.White });
            startButton = new Button("Start", new Vector2(game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2), game.Font, buttonTexture, OnStartButtonClick);
        }


        public override void Enter() { }

        public override void Exit() { }

        public override void Update(GameTime gameTime)
        {
            startButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);

            game.SpriteBatch.Begin();
            startButton.Draw(game.SpriteBatch);
            game.SpriteBatch.End();
        }

        private void OnStartButtonClick(object sender, EventArgs e)
        {
            gameManager.ChangeState(new Level1State(game, gameManager));
        }
    }
}
