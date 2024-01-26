using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Numerics;
using System.Windows.Forms;

namespace Nea_2._0
{
    class tank : Gameobject
    {
        public enum Direction
        {
            down,
            left,
            right,
            up,
        }
        private bool _player; // true = p1 false = p2
        public bool Player { get { return _player; } }
        private int _type; // 1 = light 2 = medium 3 = heavy 0 = dead
        public int Type { get { return _type; } }
        private int _armour;// armour value of tank  
        public int Armour { get { return _armour; } }
        private int _acc;// accuracy of tank 
        public int Acc { get { return _acc; } }
        private int _speed;// accuracy of tank 
        public int Speed { get { return _speed; } }
        private int _penpower;
        public int Penpower { get { return _penpower; } }
        private bool _apshell;
        public bool Apshell { get { return _apshell; } }
        private int _range;// hwo far the gun can shoot
        public int Range { get { return _range; } }
        private int _x;
        public int X { get { return _x; } }
        private int _y;
        public int Y { get { return _y; } }
        private int _movementactionpoints;// how many movement action it can do 
        public int Movactpoints { get { return _movementactionpoints; } }
        private bool _havefired;// how many movement action it can do 
        public bool Havefired { get { return _havefired; } }
        public bool[] Components = new bool[5];  // components 1= engine  2= tracks 3=gun 4=turret ring if all destroyed tank is destroyed  tracks can be repaired 
        public bool[] Crewmembers = new bool[5]; // crew 1= driver 2= gunner 3= loader 4= commander commander can switch wiht any loader can switch with gunner
        public tank(int x, int y ,int armour, int acc, int speed, int penpower, bool apshell, int range, int movepoints, bool havefired, int type, bool player)
        {
            _x = x;
            _y = y;
            _player = player;
            _type = type;
            Location = new Vector2(0, 0);
            _armour = armour;
            _acc = acc;
            _speed = speed;
            _penpower = penpower;
            _apshell = apshell;
            _range = range;
            _movementactionpoints = movepoints;
            _havefired = havefired;
        }
        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            if (Type == 1)
            {
                if (Player == true)
                {
                    Texture = Content.Load<Texture2D>(@"Light_blue_RF");
                }
                else if (Player == false)
                {
                    Texture = Content.Load<Texture2D>(@"Light_red_LF");
                }

            }
            if (Type == 2 && Player == true)
            {
                if (Player == true)
                {
                    Texture = Content.Load<Texture2D>(@"blue_medium_RF");
                }
                else if (Player == false)
                {
                    Texture = Content.Load<Texture2D>(@"red_medium_LF");
                }

            }
            if (Type == 3 && Player == true)
            {
                if (Player == true)
                {
                    Texture = Content.Load<Texture2D>(@"blueheavy_RF");
                }
                else if (Player == false)
                {
                    Texture = Content.Load<Texture2D>(@"red_heavy_LF");
                }

            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            int _X = 0;
            int _Y = 0;
            if(Player == true && Type == 3) 
            { 
                
                spriteBatch = spriteBatch.Draw(Texture, new Vector2(_X, _Y),Microsoft.Xna.Framework.Color.White); 
            }
            
        }
    }
}
