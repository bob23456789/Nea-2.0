using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace Nea_2._0
{
    internal class Gameobject: Game1
    {
        public Vector2 Location; //public anyone can see it!
        protected Texture2D Texture;
        public Rectangle Edge;
        public virtual void LoadContent(GraphicsDeviceManager GraphicsDevice)
        {

        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Texture, Location, Color.White);
        }
    }
}
