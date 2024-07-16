using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Testproject.UI.Elements;
using System;
using Testproject.Core.GameStates;
using Testproject;
using Testproject.Utility.StateMachine;

public class WinState : State
{
    private Button mainMenuButton;
    private Texture2D buttonTexture;

    public WinState(Game1 game, GameManager gameManager) : base(game, gameManager)
    {
        buttonTexture = new Texture2D(game.GraphicsDevice, 1, 1);
        buttonTexture.SetData(new[] { Color.White });
        mainMenuButton = new Button("Main Menu", new Vector2(game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2), game.Font, buttonTexture, OnMainMenuButtonClick);
    }

    public override void Enter() { }

    public override void Exit() { }

    public override void Update(GameTime gameTime)
    {
        mainMenuButton.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        game.GraphicsDevice.Clear(Color.Gold);

        game.SpriteBatch.Begin();
        mainMenuButton.Draw(game.SpriteBatch);
        game.SpriteBatch.End();
    }

    private void OnMainMenuButtonClick(object sender, EventArgs e)
    {
        gameManager.ChangeState(new MainMenuState(game, gameManager));
    }
}
