namespace GameSupply
{
    /// <summary>
    /// Интерфейс для снаряжения
    /// </summary>
    public interface ISupply
    {
        /// <summary>
        /// Номер используемый для получения названия и информации
        /// </summary>
        protected abstract int Itemid { get; set; }
        /// <summary>
        /// Кастомизированный, если требуется, текст названия
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Название снаряжения по его номеру
        /// </summary>
        internal string _name
        {
            get
            {
                return LanguageController.DefaultItemsText[Itemid];
            }
        }
        /// <summary>
        /// Информация о снаряжении по его номеру
        /// </summary>
        public string Info
        {
            get
            {
                return LanguageController.DefaultItemsText[Itemid + 1];
            }
        }

        /// <summary>
        /// Предполагается, как метод для смены оружия при подборе
        /// </summary>
        /// <param name="target">Тот, кто активировал</param>
        public abstract void Active(Unit target);
    }
}
