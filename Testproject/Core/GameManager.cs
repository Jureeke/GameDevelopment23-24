using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Testproject.Core.GameStates;
using Testproject.Utility.StateMachine;
using Testproject;
using Microsoft.VisualBasic.Logging;

public class GameManager
{
    private IState currentState;
    private readonly Game1 game;


    public GameManager(Game1 game)
    {
        this.game = game;
        ChangeState(new MainMenuState(game, this));
    }

    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Update(GameTime gameTime)
    {
        currentState.Update(gameTime);
    }

    public void Draw(GameTime gameTime)
    {
        currentState.Draw(gameTime);
    }
}
