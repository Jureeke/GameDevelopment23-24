﻿using GameDevProject.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Testproject;
using Testproject.Audio;
using Testproject.Core.Enemy;
using Testproject.Core.GameStates;
using Testproject.Map;
using Testproject.Map.Levels;
using Testproject.Utility.StateMachine;

public class GameManager : StateMachine, IGameObject
{
    public Game1 RootGame;
    public MapManager MapManager;
    public Hero hero;
    public int height; 
    public int width;

    public SoundManager SoundManager { get; private set; }

    public GameManager(Game1 game)
    {

        RootGame = game;
        MapManager = new MapManager(this);
        height = game.GraphicsDevice.Viewport.Height;
        width = game.GraphicsDevice.Viewport.Width;
        hero = new Hero(this);
        MapManager.Setup();

        SoundManager = new SoundManager(game.Content);

        AddState(new MainMenuState(this));
        AddState(new PlayingState(this));
        AddState(new WinningState(this));
        AddState(new DeathState(this));
    }


    protected override void OnActivate()
    {

        // Go to the main menu
        GoToState<MainMenuState>();

        // Load in the maps
        MapManager.CreateLevelMap();
        // Other misc map stuff
        MapManager.LoadMapParameters();
    }

    protected override void OnDeactivate()
    {
        GotoNoState(true);
    }

    protected override void OnNoState()
    {
        GoToState<MainMenuState>();
    }

    public void Update(GameTime time)
    {
        ActiveState?.OnUpdate(time);
        
        if (Keyboard.GetState().IsKeyDown(Keys.M))
        {
            GoToState<WinningState>();
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.N))
        {
            GoToState<DeathState>();
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Enter) && ActiveState is PlayingState playingState)
        {
            MapManager.GoToNextLevel();
        }

    }

    public void Draw(SpriteBatch batch)
    {
        if (ActiveState is GameState state) state.OnDraw(batch);
    }
}
