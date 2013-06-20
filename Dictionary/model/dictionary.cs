using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Dictionary
{
    class Dict
    {
        List<Pair> pairs;

        public string filename;

        public bool IsEnglish;//показывает, какой язык основной

        public Dict()
        {
            pairs = new List<Pair>();
            filename = "words.txt";
            Load();
            IsEnglish = true;           
        }

        public void Load()  //загружаем из файла 
        {
            pairs.Clear();
            StreamReader t = new StreamReader(filename);
            string s;
            while ((s = t.ReadLine()) != null)
            {
                StringBuilder eng = new StringBuilder(), rus = new StringBuilder();
                int i;
                for (i = 0; s[i] != '*'; ++i)
                {
                    eng.Append(s[i]);
                }
                for (int j = i + 1; j < s.Length; ++j)
                {
                    rus.Append(s[j]);
                }
                pairs.Add( new Pair(eng.ToString(), rus.ToString() ) );
            }
            t.Close();
        }

        public void Save()  //сохраняем в файл
        {
            List<string> t = new List<string>();
            foreach (Pair p in pairs)
            {
                string temp = "";
                temp += p.EngWord + "*";
                temp += p.RusWord;
                t.Add(temp);
            }
            //File.Delete("words.txt");
            //File.Create("words.txt");
            File.WriteAllLines(filename, t);
            /*StreamWriter t = new StreamWriter("words.txt");
            foreach (Pair p in pairs)
            {
                t.Write(p.EngWord + " ");
                t.WriteLine(p.RusWord);
            }
            t.Close();*/
        }

        public void Add(string en, string ru) 
        {
            pairs.Add(new Pair(en,ru));
        }

        public void Delete(string en, string ru)
        {
            foreach (Pair t in pairs)
            {
                if (t.EngWord.Equals(en) && t.RusWord.Equals(ru))
                {
                    pairs.Remove(t);
                    break;
                }
            }
        }

        List<string> Translate(string s)
        {
            List<string> t = new List<string>();
            foreach (Pair p in pairs)
            {
                if (p.RusWord.Equals(s))
                {
                    t.Add(p.EngWord);
                }
                else 
                if (p.EngWord.Equals(s))
                {
                    t.Add(p.RusWord);
                }
            }
            return t;
        }

        public List<string> ToEnglish(string rus)
        {
            /*List<string> t = new List<string>();
            foreach (Pair p in pairs)
            {
                if (p.RusWord.Equals(rus))
                {
                    t.Add(p.EngWord);
                }
            }
            return t;*/
            return Translate(rus);
        }

        public List<string> ToRussian(string en)
        {
            return Translate(en);
        }

        public List<string> EngList()  //возвращает список неповторяющихся англ слов
        {
            List<string> t = new List<string>();
            foreach (Pair p in pairs)
            {
                if (!t.Contains(p.EngWord))
                {
                    t.Add(p.EngWord);
                }
            }
            t.Sort();
            return t;
        }

        public List<string> RusList()  //возвращает список неповторяющихся рус слов
        {
            List<string> t = new List<string>();
            foreach (Pair p in pairs)
            {
                if (!t.Contains(p.RusWord))
                {
                    t.Add(p.RusWord);
                }
            }
            t.Sort();
            return t;
        }
    }
}
