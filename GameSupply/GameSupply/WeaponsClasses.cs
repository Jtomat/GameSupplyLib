using System;
using System.Collections.Generic;
using System.Text;

namespace GameSupply
{
    //здесь размещаются классы готового оружия
    public class Sword : Weapon, ISupply
    {
        int ISupply.Itemid
        {
            set { _modifyitemid = value; }
            get { return _modifyitemid != -1 ? _modifyitemid : 0; }
        }
        public Sword(int damage,float speed,float range) :
            base(WeaponType.Sword, damage, speed,range)
        {
            TwoHanded = false;
        }

    }
    public class TwoHandedSword : Weapon, ISupply
    {
        int ISupply.Itemid
        {
            set { _modifyitemid = value; }
            get { return _modifyitemid != -1 ? _modifyitemid : 2; }
        }
        public TwoHandedSword(int damage, float speed,float range) :
                base(WeaponType.TwoHandedSword, damage,speed,range)
        {
            TwoHanded = true;
            
        }

    }
    public class Spear : Weapon, ISupply
    {
        int ISupply.Itemid
        {
            set { _modifyitemid = value; }
            get { return _modifyitemid != -1 ? _modifyitemid : 12; }
        }
        public Spear(int damage, float speed,float range) :
                base(WeaponType.Spear, damage, speed,range)
        {
            TwoHanded = false;
        }

    }
    public class Bow : Weapon, ISupply
    {
        int ISupply.Itemid
        {
            set { _modifyitemid = value; }
            get { return _modifyitemid != -1 ? _modifyitemid : 4; }
        }
        public Bow(int damage, float speed,float range) :
                base(WeaponType.Bow, damage, speed,range)
        {
            TwoHanded = true;
        }

    }
    public class CrossBow : Weapon, ISupply
    {
        int ISupply.Itemid
        {
            set { _modifyitemid = value; }
            get { return _modifyitemid != -1 ? _modifyitemid : 6; }
        }
        public CrossBow(int damage, float speed,float range) :
                base(WeaponType.Сrossbow, damage, speed,range)
        {
            TwoHanded = true;
        }

    }
}
