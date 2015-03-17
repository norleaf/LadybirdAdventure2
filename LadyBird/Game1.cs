#region Using Statements

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LadyBird.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

#endregion

namespace LadyBird
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        private Screen screen = Screen.AllScreens.First(e => e.Primary);
        private static Game1 _instance;
        SpriteBatch spriteBatch;
        //public List<Sprite> SolidSprites { get; set; }
        //public List<Sprite> BackgroundSprites { get; set; }
        public Player Player { get; set; }
        public Level Level { get; set; }
        public LevelBuilder LevelBuilder { get; set; }
        public CollisionHandler CollisionHandler { get; set; }

        public static Game1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Game1();
                }
                return _instance;
            }
        }

        private Game1()
            : base()
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
            Window.IsBorderless = true;
            Window.Position = new Point(screen.Bounds.X,screen.Bounds.Y);
            graphics.PreferredBackBufferWidth = screen.Bounds.Width;
            graphics.PreferredBackBufferHeight = screen.Bounds.Height;
            graphics.ApplyChanges();
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
            CollisionHandler = new CollisionHandler();
            // TODO: use this.Content to load your game content here
            Texture2D lb = Content.Load<Texture2D>("lb");
            Texture2D lb_all = Content.Load<Texture2D>("lb_all");
            Texture2D dummyground = Content.Load<Texture2D>("dummy_ground");
            Texture2D aphis = Content.Load<Texture2D>("foodbug");

            Player = new Player(lb_all, new Vector2(200,200));
            LevelBuilder = new LevelBuilder();
            LevelBuilder.Dummy = new SolidSprite(dummyground, new Vector2(-700, 700));
            LevelBuilder.Aphis = new Aphis(aphis, new Vector2(-700, 700));
            Level = LevelBuilder.LoadLevel1();

            
            CollisionHandler.ListenerList.Add(Player);


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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Player.Update(gameTime);
            CollisionHandler.Update(gameTime);
            Level.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            Level.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
