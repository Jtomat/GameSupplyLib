using System;
using System.Collections.Generic;
using System.Text;

namespace GameSupply
{
    public abstract class Weapon : ISupply
    {
        public float Range { protected set; get; }
        public bool TwoHanded { protected set; get; }
        protected int _modifyitemid=-1;
        public enum WeaponType { Sword, TwoHandedSword, Spear, Bow, Сrossbow, Shell }
        public WeaponType TypeOfWeapon { protected set; get; }
        public int Damage { get { return _damage; } }
        public virtual float AtackSpeed { protected set; get; }  
        public virtual string Name
        {
            get
            {
                return ((ISupply)(this))._name;
            }
        }
        int ISupply.Itemid { get; set; }

        int _damage;
        protected Weapon() { }
        public Weapon(WeaponType type, int damage, float speed, float range)
        {
            this.TypeOfWeapon = type;
            this._damage = damage;
            this.AtackSpeed = speed;
            this.Range = range;
        }

        public virtual void Active(Unit target)
        {
            //TODO: снарядить
        }
    }
    
}
