using Kalapácsvetés;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Versenyző> versenyzok = new List<Versenyző>();

          
            //Adatfeltöltés
            File.ReadAllLines("../../../Selejtezo2012.txt").Skip(1).ToList().ForEach(x => versenyzok.Add(new Versenyző(x)));

            //5. Feladat
            Console.WriteLine($"5. feladat: Versenyzők száma a selejtezőben: {versenyzok.Count} fő");

            //6. feladat
            Console.WriteLine($"6. feladat: 78,00 méter feletti eredménnyel továbbjutott: {versenyzok.Count(n=>n.AutomatikusanTovabb)} fő");

            //9. feladat
            Versenyző nyertes = versenyzok.MaxBy(n => n.Eredmény);
            Console.WriteLine($"9.feladat: A selejtező nyertese:\n" +
                $"\tNév: {nyertes.Nev}\n" +
                $"\tCsoport: {nyertes.Csoport}\n" +
                $"\tNemzet: {nyertes.Nemzet}\n" +
                $"\tNemzet kód: {nyertes.Kód}\n" +
                $"\tSorozat: {string.Join(';', nyertes.DobasokErdeti)}\n" +
                $"\tEredmény: {nyertes.Eredmény}");

            //10. feladat
            string fajlString = "Helyezés;Név;Csoport;NemzetÉsKód;D1;D2;D3\n";

            List<Versenyző> versenyzokRendezett = versenyzok.OrderByDescending(x => x.Eredmény).Take(12).ToList();
            int index = 1;
            foreach (Versenyző item in versenyzokRendezett)
            {
                fajlString += index+";" + item.ToString()+"\n";
                index++;
            }


            File.WriteAllText("../../../Dontos2012.txt", fajlString);


            //versenyzok.ForEach(x => Console.WriteLine(x.Nemzet));

        }
    }
}