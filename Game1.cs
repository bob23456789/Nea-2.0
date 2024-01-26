using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Configuration;
using static Nea_2._0.Game1;
namespace Nea_2._0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        const int tilesize = 55;
        Texture2D squareTexture;
        Texture2D grassTexture;
        Texture2D treesquaretexture;
        Texture2D menuTexture;
        private Texture2D buttonTexture;
        private Rectangle buttonRectangle; // square which teh tecture will be put in 
        double gamestate = 1;
        string menuTitle = "War On Perliculum\n             Prime";
        string Line = "";
        Camera camera;
        float initialZoom = 0.7f;//sets inital zoom
        Vector2 initialPosition = new Vector2(-55, 0); // sets inital potion of camera
        private SpriteFont myfontyfont;
        public int[,] tilemap =
        {
              {0, 0, 0, 0, 0,0, 0, 0, 0, 0,0,0,0,0,0},
              {0, 0, 0, 1, 1,0, 0, 0, 0, 0,0,0,0,0,0},
              {0, 0, 0, 0, 1,1, 0, 0, 0, 0,0,0,0,0,0},
              {0, 0, 0, 1, 1,1, 1, 0, 0, 0,0,0,0,0,0},
              {0, 0, 0, 0, 0,0, 1, 0, 0, 0,0,0,0,0,0},
              {0, 0, 0, 0, 0,0, 0, 0, 0, 0,0,0,0,0,0},
              {0, 0, 0, 0, 0,0, 0, 0, 0, 0,0,0,0,0,0},
              {0, 0, 0, 0, 0,0, 0, 0, 0, 0,0,0,0,0,0},
              {0, 0, 0, 0, 0,0, 0, 0, 0, 0,0,0,0,0,0},
              {0, 0, 0, 0, 0,0, 0, 0, 0, 0,0,0,0,0,0},
              {0, 0, 0, 0, 0,0, 0, 0, 0, 0,0,0,0,0,0},
         };

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            camera = new Camera(GraphicsDevice.Viewport, initialZoom, initialPosition);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            if (gamestate == 1.5)
            {
                grassTexture = Content.Load<Texture2D>("grass");//loads grass 
                treesquaretexture = Content.Load<Texture2D>("tree");// loads tree tile
            }
            if (gamestate == 1)
            {
                squareTexture = Content.Load<Texture2D>("menuscreen");
                myfontyfont = Content.Load<SpriteFont>("File");
                buttonTexture = Content.Load<Texture2D>("playbutton");
                // Set the initial position and size of the button
                Vector2 position = new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 2 + 20);

                buttonRectangle = new Rectangle((int)position.X, (int)position.Y, buttonTexture.Width, buttonTexture.Height);
            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && buttonRectangle.Contains(mouseState.Position))
            {
                gamestate = 1.5;
                LoadContent();
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);//creats bit where grpahics goes
            int col = 0;
            int row = 0;
            if (gamestate == 1)// menu screen  // y = 550 x = 825 area = 453750 pixles 
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(squareTexture, new Vector2(row, col), Color.White);
                Vector2 textMiddlePoint = myfontyfont.MeasureString(menuTitle) / 2;
                // Places text in center of the screen
                Vector2 position = new Vector2(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2 - 50);
                _spriteBatch.DrawString(myfontyfont, menuTitle, position, Color.AntiqueWhite, 0, textMiddlePoint, 1.5f, SpriteEffects.None, 1.0f);
                _spriteBatch.Draw(buttonTexture, buttonRectangle, Color.White);
                _spriteBatch.End();
            }
            
            if (gamestate == 1.5)
            {
                _spriteBatch.Begin(transformMatrix: camera.GetViewMatrix());// begins draws  in the srpites + sets the zoom
                for (int y = 0; y < tilemap.GetLength(0); y++)
                {

                    row = 0;
                    for (int x = 0; x < tilemap.GetLength(1); x++)
                    {
                        if (tilemap[y,x] == 0 )
                        {
                            _spriteBatch.Draw(grassTexture, new Vector2(row, col), Color.White);
                        }
                        if (tilemap[y,x] == 1)
                        {
                            _spriteBatch.Draw(treesquaretexture, new Vector2(row, col), Color.White);
                        }
                        
                       
                        row += 55;
                    }
                    col += 55;
                }
                _spriteBatch.End();


                base.Draw(gameTime);
            }
        }
        public class Camera
        {
            public Matrix Transform { get; private set; }
            private Viewport viewport;
            private float initialZoom;
            private Vector2 initialPosition;

            public Camera(Viewport viewport, float initialZoom, Vector2 initialPosition)
            {
                this.viewport = viewport;
                this.initialZoom = initialZoom;
                this.initialPosition = initialPosition;
                // Initialize the camera transformation with the initial zoom
                Transform = Matrix.CreateScale(initialZoom) * Matrix.CreateTranslation(new Vector3(-initialPosition, 0));
            }

            public Matrix GetViewMatrix()
            {
                return Transform;
            }
        }


    }
}
