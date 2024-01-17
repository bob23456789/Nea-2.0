
using var game = new Nea_2._0.Game1();
game.Run();
class tank
{
    private int _x; // cords
    public int X { get { return _x; } }
    private int _y;// y postion 
    public int Y { get { return _y; } }
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
    private int _movementactionpoints;// how many movement action it can do 
    public int Movactpoints { get { return _movementactionpoints; } }
    private bool _havefired;// how many movement action it can do 
    public bool Havefired { get { return _havefired; } }
    public bool[] Components = new bool[5];  // components 1= engine  2= tracks 3=gun 4=turret ring if all destroyed tank is destroyed  tracks can be repaired 
    public bool[] Crewmembers = new bool[5]; // crew 1= driver 2= gunner 3= loader 4= commander commander can switch wiht any loader can switch with gunner
    public tank(int x, int y, int armour, int acc, int speed, int penpower, bool apshell, int range, int movepoints, bool havefired)
    {

        _x = x;
        _y = y;
        _armour = armour;
        _acc = acc;
        _speed = speed;
        _penpower = penpower;
        _apshell = apshell;
        _range = range;
        _movementactionpoints = movepoints;
        _havefired = havefired;
    }

}


