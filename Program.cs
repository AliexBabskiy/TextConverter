using System;
using System.IO;
using Newtonsoft.Json;
using Cl1;
using System.Xml.Serialization;
using Tovn;
using static System.Net.WebRequestMethods;

class Converter
{
    //static string fille;
    static List<Citi> citis = new List<Citi>();
    static string fille;
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Вставьте путь до файла (с названием), который вы хотите открыть");
        Console.WriteLine("---------------------------------------------------------------");
        fille = Console.ReadLine();                                       //File.ReadAllText(Console.ReadLine());
        //string fillestr = Convert.ToString(fille);

        if (fille.EndsWith(".txt"))
        {
            var L = System.IO.File.ReadAllLines(fille);
            
            for (int i = 0; i < L.Length; i += 3)
            {
                string name = L[i];
                int piple = Convert.ToInt32(L[i + 1]);
                double razmer = Convert.ToDouble(L[i + 2]);
                citis.Add(new Citi(name, piple, razmer));
            }
        }
        else if (fille.EndsWith(".xml"))
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Citi>));
            using (FileStream fs = new FileStream(fille, FileMode.Open))
            {
                //string fille = File.ReadAllText(fille);
                citis = (List<Citi>)xml.Deserialize(fs);
                Console.WriteLine("fjfdkf");
            }
        }
        else if (fille.EndsWith(".json"))
        {

        }

        while(true)
        {
            //Console.Clear();
            //Console.WriteLine($"Открыт файл: {fille}");
            Console.WriteLine("Сохранить файл в формате: txt, json, xml - F1. Закрыть программу - Escape");
            Console.WriteLine("-------------------------------------------------------------------------");
            
            Console.WriteLine(fille);

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.F1)
            {
                SaveVar();
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }
    static void SaveVar()
    {
        while(true)
        {
            Console.WriteLine("Выбирете вариант сохранения: txt - 1, json - 2, xml - 3");

            string varn = Console.ReadLine();

            while (true)
            {
                if ( Convert.ToUInt32(varn) == 1)
                {
                    List<string> l = new List<string>();
                    foreach (var cit in citis)
                    {
                        l.Add(cit.Name);
                        l.Add(cit.Piple.ToString());
                        l.Add(cit.Razmer.ToString());
                    }
                    System.IO.File.WriteAllLines(fille, l);
                    Console.WriteLine("cjjf");
                    break;
                }
                else if ( Convert.ToUInt32(varn) == 2)
                {
                    Console.WriteLine("Fgtth");
                    break;
                }
                else if ( Convert.ToUInt32(varn) == 3)
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Citi>));
                    using (FileStream fs = new FileStream(fille, FileMode.Create))
                    {
                        xml.Serialize(fs, citis);
                    }
                    Save();
                }
                else
                {
                    Console.WriteLine("Неверное значение");
                    break;
                }
            }
        }
    }
    static void Save()
    {
        Console.WriteLine("Введите путь до файла с названием, заменив формат файла на тот который был выбран:");
        Console.WriteLine("----------------------------------------------------------------------------------");
        string filleS = System.IO.File.ReadAllText(Console.ReadLine());

        while(true)
        {
            if (string.IsNullOrEmpty(fille))
            {
                Console.WriteLine("Название файла не может быть пустым. Файл не будет сохранен.");
                return;
            }
            else
            {
                System.IO.File.WriteAllText(filleS, fille);
                Console.WriteLine("Файл Сохранён");
            }
        }
        Main();
    }
}