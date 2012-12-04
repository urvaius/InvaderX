using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;


namespace InvaderX
{
	class ActionScreen : GameScreen
	{


		GamePadState gamePadState;
		GamePadState oldGamePadState;
		KeyboardState keyboardState;
		KeyboardState oldKeyBoardState;
		Texture2D image;
		Rectangle imageRectangle;
		Texture2D ship1;
		Rectangle shipRectangle;
		Vector2 shipPos;
		GraphicsDeviceManager graphics;



		public ActionScreen(Game game, SpriteBatch spriteBatch, Texture2D image, Texture2D ship1,GraphicsDeviceManager graphics)
			: base(game, spriteBatch)
		{

			this.graphics = graphics;
			this.image = image;
			
			this.ship1 = ship1;


			imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
			//shipPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - ship1.Width / 2, (GraphicsDevice.Viewport.Height / 2) + ship1.Height + 30);
			shipPos = new Vector2((Game.Window.ClientBounds.Width /2) - ship1.Width /2, (Game.Window.ClientBounds.Height / 2) + ship1.Height+30);
			
			
			


			
			//shipRectangle = new Rectangle(Game.Window.ClientBounds.Width / 2, 300, ship1.Width, ship1.Height);
			


		}

		public override void Initialize()
		{

		   

			base.Initialize();
			
			
	

		}

		protected override void LoadContent()
		{


			base.LoadContent();
		}




		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			int maxX = Game.Window.ClientBounds.Width - ship1.Width;


			keyboardState = Keyboard.GetState();
			if (keyboardState.IsKeyDown(Keys.Escape))
				game.Exit();

			if (keyboardState.IsKeyDown(Keys.A))
			{
				shipPos.X -=5;


			}
			else if (keyboardState.IsKeyDown(Keys.D))
			{
				shipPos.X += 5;
			}

			if (shipPos.X > Game.Window.ClientBounds.Width)

				if (shipPos.X > maxX)
				{
					shipPos.X = maxX;
				}
			oldKeyBoardState = keyboardState;
			oldGamePadState = gamePadState;

			





		}


		public override void Draw(GameTime gameTime)
		{
			spriteBatch.Draw(image, imageRectangle, Color.White);


			//spriteBatch.Draw(ship1, shipRectangle, Color.White);
			spriteBatch.Draw(ship1, shipPos, Color.White);
			base.Draw(gameTime);
		}

	}
}
