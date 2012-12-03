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



		public ActionScreen(Game game, SpriteBatch spriteBatch, Texture2D image, Texture2D ship1)
			: base(game, spriteBatch)
		{
			this.image = image;
            
			imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
            shipPos = new Vector2((Game.Window.ClientBounds.Width /2) - ship1.Width /2, (Game.Window.ClientBounds.Height / 2) + ship1.Height+30);
			this.ship1 = ship1;


            
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
			keyboardState = Keyboard.GetState();
			if (keyboardState.IsKeyDown(Keys.Escape))
				game.Exit();





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
