using System;
using System.Collections.Generic;
using System.Text;

namespace GameSupply
{
    public abstract class Shell : Weapon, ISupply
    {
        public enum ShellType { Arrow, Bolt }
        public override string Name { get { return $"{((ISupply)this)._name} X{_count}"; } }
        public bool Limited { get { return _limited; } }
        public int Count { get { return _count; } }
        public ShellType TypeOfShell { protected set; get; }
        bool _limited;
        int _count;
        int _damage;
        
        protected Shell(ShellType typeOfShell, int damage, int count = 1,
            bool limited = true)
        {
            this.TypeOfShell = typeOfShell;
            this._count = count;
            this._limited = limited;
            this._damage = damage;
        }

        public override void Active(Unit target)
        {
            _count--;
            //TODO: реализовать стрельбу
        }
    }
    public class Arrows : Shell,ISupply
    {

        int ISupply.Itemid 
        { 
            set { _modifyitemid = value; } 
            get { return _modifyitemid!=-1?_modifyitemid:8; } 
        }
        public Arrows(int damage, int count = 1, bool limited = true)
            : base(ShellType.Arrow, damage, count, limited)
        {

        }
    }
    public class Bolts : Shell,ISupply
    {
        int ISupply.Itemid
        {
            set { _modifyitemid = value; }
            get { return _modifyitemid != -1 ? _modifyitemid : 9; }
        }
        public Bolts(int damage, int count = 1, bool limited = true)
            : base(ShellType.Bolt, damage, count, limited)
        {

        }
    }
}
