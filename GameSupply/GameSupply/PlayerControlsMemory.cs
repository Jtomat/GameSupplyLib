using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSupply
{
    public static class PlayerControlsMemory
    {
        static Dictionary<string,UnityEngine.KeyCode> PlayersControls;
        public static string ExecutablePath;
        public static KeysMemoryProxy KeysMemory = new KeysMemoryProxy();
        
        public static void Download()
        {
            var controls_memory = new Dictionary<string, UnityEngine.KeyCode>();
            var text = System.IO.File.ReadAllText(_selectedDir).
                Split(new char[] {'&'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < text.Length - 1; i += 2)
            {
                var data_n = Keeper.Decrypt(text[i]).Split(new[] {'|'},StringSplitOptions.RemoveEmptyEntries);
                controls_memory.Add(data_n[0],
                    (UnityEngine.KeyCode)int.Parse(data_n[1]));
            }
            PlayersControls = controls_memory;
        }
        public static void ChangeControls(UnityEngine.KeyCode[] new_keys)
        {
            for (int i = 0; i < PlayersControls.Count; i++)
            {
                PlayersControls[PlayersControls.Keys.ToList()[i]] = new_keys[i];
                i++;
            }
            Upload();
        }

        static void Upload()
        {
            var controls_memory_text = "";
            foreach (var con in PlayersControls)
            {
                controls_memory_text +=$"{Keeper.Encrypt($"{con.Key}|{(int)con.Value}")}&";
            }
            System.IO.File.WriteAllText(_selectedDir,controls_memory_text);
        }
        static string _selectedDir
        {
            get
            {
                try
                {
                    var location = System.IO.Path.GetDirectoryName(ExecutablePath + @"\").Replace("/", @"\");
                    return location +
                        @"\Settings\Controls.st";
                }
                catch { throw new Exception("Не верно указан путь к файлу."); }
            }
        }

        public class KeysMemoryProxy
        {
            public UnityEngine.KeyCode this[string key]
            {
                get
                {
                    if (!PlayersControls.ContainsKey(key))
                        throw new Exception("This key does not existe.");
                    return PlayersControls[key];
                }
            }
        }
    }
}
