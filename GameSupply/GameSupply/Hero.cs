using System;
using System.Collections.Generic;
using System.Text;

namespace GameSupply
{
    public class Hero:Unit
    {

        public Hero(int helth, int armor=0, Weapon weapon=null)
            :base(helth,armor,weapon)
        {
        
        }
    }
}
