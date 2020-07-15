using System;
using System.Collections.Generic;
using System.Text;

namespace GameSupply
{
    //здесь будут вспомогательные структуры и enum не привязанные к классам
    /// <summary>
    /// Структура для указания направления
    /// </summary>
    public enum MoveVect {Up,Left,Right,Down,UpLeft,UpRight,DownLeft,DownRight }
    /// <summary>
    /// Структура для хитбокса (все должно быть в float)
    /// </summary>
    public struct HitBox
    {
        public float X;
        public float Y;
        public float Height;
        public float Width;
        public float Top { get { return Y; } }
        public float Left { get { return X; } }
        public float Right { get { return X + Width; } }
        public float Bottom { get { return Y + Height; } }
    }

}
