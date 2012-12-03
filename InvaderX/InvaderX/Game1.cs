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


namespace InvaderX
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //for our menucomponent items and screens
        GamePadState gamePadState;
        GamePadState oldGamePadState;
        KeyboardState keyboardState;
        KeyboardState oldKeyBoardState;
        GameScreen activeScreen;
        StartScreen startScreen;
        ActionScreen actionScreen;
       

        //to use our menucomponent class
        // MenuComponent menuComponent;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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
            //this is code to add a generic menu etc. using our MenuComponent class

            // string[] menuItems = { "Start Game", "High Scores", "End Game" };

            startScreen = new StartScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("menuimage"));
            Components.Add(startScreen);
            startScreen.Hide();

            actionScreen = new ActionScreen(this, spriteBatch, Content.Load<Texture2D>("gameimageback"));
            Components.Add(actionScreen);
            actionScreen.Hide();
            activeScreen = startScreen;
            activeScreen.Show();


            //   menuComponent = new MenuComponent(this, spriteBatch, Content.Load<SpriteFont>("menufont"), menuItems);
            //Components.Add(menuComponent);



            // TODO: use this.Content to load your game content here
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
            // Allows the game to exit


            keyboardState = Keyboard.GetState();
            gamePadState = GamePad.GetState(PlayerIndex.One);


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            if (activeScreen == startScreen)
            {
                if (CheckKey(Keys.Enter) || CheckButton(Buttons.A))
                {
                    if (startScreen.SelectedIndex == 0)
                    {
                        activeScreen.Hide();
                        activeScreen = actionScreen;
                        activeScreen.Show();


                    }
                    if (startScreen.SelectedIndex == 1)
                    {
                        this.Exit();
                    }
                }
            }
            base.Update(gameTime);
            oldKeyBoardState = keyboardState;
            oldGamePadState = gamePadState;
        }
        private bool CheckButton(Buttons button)
        {
            return gamePadState.IsButtonUp(button) &&
                oldGamePadState.IsButtonDown(button);
        }
        private bool CheckKey(Keys theKey)
        {
            return keyboardState.IsKeyUp(theKey) &&
                oldKeyBoardState.IsKeyDown(theKey);

        }

        // TODO: Add your update logic here




        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);



            base.Draw(gameTime);
            spriteBatch.End();
            // TODO: Add your drawing code here

            
        }
    }
}
