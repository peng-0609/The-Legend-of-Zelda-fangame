using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public string XmlString1 { get; set; }
        public ILevel Level { get; set; }
        public List<IController> ControllerList { get; set; }
        public AllCollisionHandler collisionDetection { get; set; }
        public IHUD DungeonHUD { get; set; }
        public SpriteFont Font { get; set; }
        public TextSprite TextSprite { get; set; }
        private SpriteFont text;
        public GameStateManager gameStateManager { get; set; }
        private DetailedMap map;
        public Camera MapCamera { get; set; }
        public Camera MenuCamera { get; set; }
        private Texture2D backgroundSprite;

        public IPlayer Link { get; set; }
        public string XmlString2 { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 560;
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
            TextureInitialize();
            XmlString1 = Environment.CurrentDirectory + "/Content/Level1.xml";
            XmlString2 = Environment.CurrentDirectory + "/Content/Unlimited.xml";
            gameStateManager = new GameStateManager(this);
            gameStateManager.textSprite = this.TextSprite;
            Level = LevelLoaderFactory.Instance.LoadContents(this, this.XmlString1, 1);
            Link = new Link(500, 440, this);
            DungeonHUD = new DungeonHUD(this);
            ControllerList = new List<IController>();
            ControllerList.Add(new KeyboardController(this));
            foreach (IController controller in ControllerList)
            {
                controller.RegisterCommand();
            }
            collisionDetection = new AllCollisionHandler(gameStateManager);
            MapCamera = new Camera(640, 440, new Vector2(640, 2200));
            MenuCamera = new Camera(640, 440, new Vector2(0, 440));
            this.IsMouseVisible = true;

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

            // TODO: use this.Content to load your game content here   
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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

            // TODO: Add your update logic here
            
                foreach (IController controller in ControllerList)
                    controller.Update(this);
           
                collisionDetection.CheckAllCollisions();
            if (!gameStateManager.state.isPause)
            {
                Level.Update(gameTime);
            }
                Link.Update(gameTime);
                DungeonHUD.Update();
                gameStateManager.Update(gameTime);
                MapCamera.Update();
                MenuCamera.Update();
                base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here

            //Draw room background
            if (gameStateManager.Unlimited)
            {
                backgroundSprite = Content.Load<Texture2D>("RoomSprites/Unlimited");
                spriteBatch.Begin();
                spriteBatch.Draw(backgroundSprite, new Vector2(0, 120), Color.White);
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, MapCamera.ViewMatrix);
                spriteBatch.Draw(backgroundSprite, new Vector2(0, 120), Color.White);
                //Level.Draw(spriteBatch);
                spriteBatch.End();
            }

            //Draw Link
            //Link.Draw(spriteBatch);
            //Draw HUD
            spriteBatch.Begin(SpriteSortMode.FrontToBack, null, null, null, null, null, MenuCamera.ViewMatrix);
            //DungeonHUD.Draw(spriteBatch);
            
            spriteBatch.End();

            gameStateManager.Draw(spriteBatch);

            base.Draw(gameTime);
        }

        public void TextureInitialize()
        {
            SoundEffectFactory.Instance.LoadAllContents(Content);
            MusicFactory.Instance.LoadAllContents(Content);
            ArtifactSpriteFactory.Instance.LoadAllTextures(Content);
            CharacterSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            ProjectileSpriteFactory.Instance.LoadAllTextures(Content);
            RoomSpriteFactory.Instance.LoadAllTextures(Content);
            HUDSpriteFactory.Instance.LoadAllTextures(Content);
            MenuSpriteFactory.Instance.LoadAllTextures(Content);
            text = Content.Load<SpriteFont>("TextSprite/Text");
            TextSprite = new TextSprite(text);
            Font = Content.Load<SpriteFont>("HUDSprites/Font");
            Font = MenuSpriteFactory.Instance.CreateSpriteFont();
            backgroundSprite = Content.Load<Texture2D>("RoomSprites/Map");
            map = new DetailedMap(0, 0);
        }

        public void Reset()
        {
            // TODO: Add your initialization logic here
            TextureInitialize();
            XmlString1 = Environment.CurrentDirectory + "/Content/Level1.xml";
            XmlString2 = Environment.CurrentDirectory + "/Content/Unlimited.xml";
            Level = LevelLoaderFactory.Instance.LoadContents(this, this.XmlString1, 1);
            Link = new Link(500, 440, this);
            MapCamera = new Camera(640, 440, new Vector2(640, 2200));
            MenuCamera = new Camera(640, 440, new Vector2(0, 440));
            collisionDetection = new AllCollisionHandler(gameStateManager);
            DungeonHUD = new DungeonHUD(this);
            this.IsMouseVisible = true;
            base.Initialize();
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
    }
}
