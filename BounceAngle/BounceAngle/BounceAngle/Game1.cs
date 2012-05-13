using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BounceAngle
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameEngine dayGame;
        GameEngine nightGame;
        SpriteFont menuFont;
        MenuScreen menuScreen;
        Texture2D startMenu;
        private KeyboardState preKeyState;
        MouseState preMouseState;
        GameState gameState;
        public enum GameState
        {
            mainMenu,
            playing,
            instructions,
            gameOver,
            quit
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            Content.RootDirectory = "Content";
            //graphics.ToggleFullScreen();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            gameState = GameState.mainMenu;
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;

            //menu
            string[] menuItems = { "Play", "Instructions", "Restart", "Quit" };
            menuFont = Content.Load<SpriteFont>("MenuItems\\menuFont");
            menuScreen = new MenuScreen(graphics, menuFont, menuItems);
            startMenu = Content.Load<Texture2D>("Images\\gameScreen");


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            nightGame = NightGameEngineImp.getGameEngine();
            dayGame = DayGameEngineImp.getGameEngine();
            dayGame.Init(Content);
            nightGame.Init(Content);

            restartGame();
        }

        public void restartGame()
        {
            DayGameEngineImp.getGameEngine().getSimMgr().init();

            // start the day game
            nightGame.stop();
            dayGame.start();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            MouseState mstate = Mouse.GetState();
            //Volume Control
            if (keyState.IsKeyDown(Keys.Subtract) && preKeyState.IsKeyUp(Keys.Subtract))
            {
                DayGameEngineImp.getGameEngine().getSoundManager().volumeDown();
                //NightGameEngineImp.getGameEngine().getSoundManager().volumeDown();
            }
            if (keyState.IsKeyDown(Keys.Add) && preKeyState.IsKeyUp(Keys.Add))
            {
                DayGameEngineImp.getGameEngine().getSoundManager().volumeUp();
                //NightGameEngineImp.getGameEngine().getSoundManager().volumeUp();
            }
            if (gameState == GameState.instructions)
            {
                if ((keyState.IsKeyUp(Keys.Escape) && preKeyState.IsKeyDown(Keys.Escape))
                    || (mstate.LeftButton == ButtonState.Pressed))
                {
                    gameState = GameState.mainMenu;
                }
                preKeyState = keyState;
            }
            if (gameState == GameState.mainMenu)
            {
                UpdateInput(gameTime);
            }

            

            if (gameState == GameState.playing)
            {
                dayGame.Update(gameTime);
                nightGame.Update(gameTime);
                

                if (keyState.IsKeyUp(Keys.Escape) && preKeyState.IsKeyDown(Keys.Escape))
                {
                    //TODO: exit the game on escape
                    gameState = GameState.mainMenu;
                }
                
                preKeyState = keyState;
            }
            base.Update(gameTime);
        }

        public void UpdateInput(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            
            
            if (gameState == GameState.mainMenu)
            {
                menuScreen.Update();
                
                Rectangle start = new Rectangle(199, 305, 100, 35);
                Rectangle instr = new Rectangle(199, 340, 150, 35);
                Rectangle restart = new Rectangle(199, 375, 100, 35);
                Rectangle exit = new Rectangle(199, 415, 100, 35);

                if (start.Contains(mouseState.X, mouseState.Y))
                {
                    menuScreen.SelectedIndex = 0;
                }
                if (instr.Contains(mouseState.X, mouseState.Y))
                {
                    menuScreen.SelectedIndex = 1;
                }
                if (restart.Contains(mouseState.X, mouseState.Y))
                {
                    menuScreen.SelectedIndex = 2;
                }
                if (exit.Contains(mouseState.X, mouseState.Y))
                {
                    menuScreen.SelectedIndex = 3;
                }


                if ((exit.Contains(new Point(mouseState.X, mouseState.Y)) && preMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released))
                {
                    this.Exit();
                }
                if ((instr.Contains(new Point(mouseState.X, mouseState.Y)) && preMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released))
                {
                    gameState = GameState.instructions;
                }
                if ((start.Contains(new Point(mouseState.X, mouseState.Y)) && preMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released))
                {
                    gameState = GameState.playing;
                }
                if ((restart.Contains(new Point(mouseState.X, mouseState.Y)) && preMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released))
                {
                    restartGame();
                    gameState = GameState.playing;
                }
                if (keyState.IsKeyUp(Keys.Escape) && preKeyState.IsKeyDown(Keys.Escape))
                {
                    //TODO: exit the game on escape
                    this.Exit();
                }
            }
            preMouseState = mouseState;
            preKeyState = keyState;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>bbh
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);
            spriteBatch.Begin();
            if (gameState == GameState.mainMenu)
            {
                spriteBatch.Draw(startMenu, Vector2.Zero, Color.White);
                menuScreen.Draw(spriteBatch);
            }
            if (gameState == GameState.playing)
            {
                dayGame.Draw(spriteBatch);
                nightGame.Draw(spriteBatch);
                if (DayGameEngineImp.getGameEngine().getSimMgr().getAliveSurvivors() <= 0)
                {
                    gameState = GameState.gameOver;
                }
            }
            if (gameState == GameState.gameOver)
            {
                spriteBatch.Draw(Content.Load<Texture2D>("Images//gameOver"), Vector2.Zero, Color.White);
                spriteBatch.DrawString(Content.Load<SpriteFont>("MenuItems//UIFont"), "You survived " + DayGameEngineImp.getGameEngine().getMenuManager().SetUITime + " days.", new Vector2(400, 400), Color.Black);
            }

            if (gameState == GameState.instructions)
            {
                spriteBatch.Draw(Content.Load<Texture2D>("Images//instructionsScreen"), Vector2.Zero, Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
