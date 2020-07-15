using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using UnityEngine;
namespace GameSupply
{
    /// <summary>
    /// Абстрактный класс для любого "разумного" объекта.
    /// </summary>
    public abstract class Unit
    {
        /// <summary>
        /// Длина шага
        /// </summary>
        protected float Step = 1;
        /// <summary>
        /// Возвращает координаты левого верхнего угла.
        /// </summary>
        public Vector3 Position 
        { 
            get { return new Vector3(_hitbox.X,_hitbox.Y); } 
        }
        /// <summary>
        /// Хитбокс для взаимодеуствий с другими объектами
        /// </summary>
        HitBox _hitbox = new HitBox { X = 0,Y=0,Height = 1,Width=1 }; 
        /// <summary>
        /// Направление движения, необходимо для определения анимации и атак.
        /// Только лево и право.
        /// </summary>
        public MoveVect Face { private set; get; }
        /// <summary>
        /// События при смерти персонажа
        /// </summary>
        protected Action OnDie=new Action(()=> { });
        public int Helth { get { return _helth; } }
        /// <summary>
        /// Здоровье
        /// </summary>
        int _helth = 0;
        /// <summary>
        /// Игнорируемое количество урона
        /// </summary>
        int _armor;
        /// <summary>
        /// Для дальнейшей очистки от трупов
        /// </summary>
        public bool isDead { private set; get; } 
        /// <summary>
        /// Используемое оружие
        /// </summary>
        public Weapon Weapon { protected set; get; }
        /// <summary>
        /// Модификатор для силовой атаки
        /// </summary>
        protected double _powerModificator = 1.5;
        public Unit(int helth, int armor = 0, Weapon weapon = null)
        {
            this._helth = helth;
            this.Weapon = weapon;
            this._armor = armor;
        }
        /// <summary>
        /// Взаимодействие с интерактивным объектом местности
        /// </summary>
        /// <param name="target">Объект местности</param>
        public void Interact(object target)
        {
        
        }
        /// <summary>
        /// Обычный удар
        /// </summary>
        /// <param name="target">Цель атаки</param>
        public void Strike(Unit target)
        {
            target.GetDamage(Weapon.Damage);
        }
        /// <summary>
        /// Силовой удар
        /// </summary>
        /// <param name="target">Цель атаки</param>
        public void PowerStrike(Unit target)
        {
            target.GetDamage(
                (int)(Weapon.Damage*_powerModificator));
        }
        /// <summary>
        /// Получить дальнобойный урон
        /// </summary>
        /// <param name="damage">Количество урона</param>
        internal void Hit(int damage)
        {
            this.GetDamage(damage);    
        }
        /// <summary>
        /// Получение урона
        /// </summary>
        /// <param name="value">Количество урона</param>
        private void GetDamage(int value)
        {
            if (_armor > value)
                return;
            if (_helth >= (value - _armor))
                _helth -= (value - _armor);
            else
                _helth = 0;
            if (_helth == 0)
                Die();

        }
        /// <summary>
        /// Просто сдох
        /// </summary>
        private void Die()
        {
            isDead = true;
            OnDie.Invoke();
        }
        /// <summary>
        /// Движение в выбранном направлении
        /// </summary>
        /// <param name="vector">Направление</param>
        /// <param name="floor">Объект, на котором стоит Unit</param>
        public virtual Vector3 Move(MoveVect vector,LocationObject floor)
        {
            switch (vector)
            {
                //TODO: отследить падение, если нет опоры снизу полностью
                case MoveVect.Up:
                    //TODO: прыжок, вверх по деревянной лестнице
                    
                    break;
                case MoveVect.Left:
                    Face = vector;
                    _hitbox.X -= Step;
                    //TODO: влево
                    break;
                case MoveVect.Right:
                    Face = vector;
                    _hitbox.X += Step;
                    //TODO: вправо
                    break;
                case MoveVect.Down:
                    //TODO: пригнуться, вниз по деревянной лестнице
                    break;
            }
            return Position;
        }
        private void Jump()
        {
            
        }
        private void Sit()
        {
        
        }
        private void Fall(LocationObject floor)
        {
            
        }
    }
}
