using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GameSupply
{
    /// <summary>
    /// Статический класс для установки языка
    /// </summary>
    public static class LanguageController
    {
        // с 0 до 63 - дефолтные предметы экипировки
        // с 64 до 127 - обычные и именные враги
        // c 128 до 255 - объекты окружения

        /// <summary>
        ///Массив названий и информации по предметам экипировки 
        /// </summary>
        public static string[] DefaultItemsText
        {
            get
            {
                var result = new string[64];
                Array.Copy(_textData, 0, result, 0, Math.Min(result.Length, _textData.Length));
                return result;
            }
        }
        /// <summary>
        ///Дефолтная папка для хранения языков 
        /// </summary>
        static readonly string _defaultDir = @"\Languages";
        /// <summary>
        /// Путь к исполняемой папке
        /// </summary>
        public static string ExecutablePath;
        /// <summary>
        /// Имена папок с языками
        /// </summary>
        static readonly string[] _languagesDirs = new string[]
            {@"\EN\",@"\RU\" };
        /// <summary>
        /// Индекс выбраной папки с языками == выбраный язык
        /// </summary>
        static int _languageIndex = -1;
        /// <summary>
        /// Папка с выбранным языком
        /// </summary>
        static string _selectedDir
        {
            get
            {
                try
                {
                    var location = Path.GetDirectoryName(ExecutablePath + @"\").Replace("/",@"\");
                    return location+
                        _defaultDir + _languagesDirs[_languageIndex];
                }
                catch { throw new Exception("Не верно указан путь к файлу."); }
            }
        }
        /// <summary>
        /// Полное хранилище строк с текстами
        /// </summary>
        static string[] _textData;
        /// <summary>
        /// Метод для установки языка
        /// </summary>
        /// <param name="index">Индекс выбраного языка</param>
        public static void ChangeLanguage(int index)
        {
            if (_languageIndex != index)
            {
                _languageIndex = index;
                var languageFiles = Directory.GetFiles(_selectedDir);
                var allText = new List<string>(1024);
                foreach (var file in languageFiles)
                    if(!file.Contains(".meta"))
                        InsertInfo(file, ref allText);
                _textData = allText.ToArray();
            }
        }
        /// <summary>
        /// Метод, помещающий все данные из файла в лист строк по индексам
        /// </summary>
        /// <param name="fileName">Полное имя считываемого файла</param>
        /// <param name="result">Лист, в который будет производиться дозапись</param>
        private static void InsertInfo(string fileName, ref List<string> result)
        {
            var text = File.ReadAllText(fileName).
                Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < text.Length - 1; i += 2)
            {
                var range = text[i].Trim(new[] { '[', ']' });
                range= range.TrimStart(new[] { '0' });
                result.Insert(int.Parse(range.ToString()) - 1, text[i + 1]);

            }
        }
    }
}
