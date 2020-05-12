using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            //AddSamurai();
            //GetSamurais("After Add:");
            //InsertMultipleSamurais();
            //Console.Write("Press any key...");
            //Console.ReadKey();
            QueryFilters();
        }

        private static void InsertMultipleSamurais()
        {
            var samurai = new Samurai { Name = "Mojo" };
            var samurai2 = new Samurai { Name = "Puppy" };
            var samurai3 = new Samurai { Name = "Mojo2" };
            var samurai4 = new Samurai { Name = "Puppy2" };
            _context.Samurais.AddRange(samurai, samurai2, samurai3, samurai4);
            _context.SaveChanges();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Mojo" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }

        private static void QueryFilters()
        {
            var name = "Mojo";
            //var samurai = _context.Samurais.Where(s => s.Name == name).ToList();
            var samurai = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "M%")).ToList();
        }
    }
}
