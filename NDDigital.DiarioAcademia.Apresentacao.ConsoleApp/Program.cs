using Infrasctructure.DAO.ORM.Contexts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using System;

namespace NDDigital.DiarioAcademia.Apresentacao.ConsoleApp
{
    internal class Program
    {
        //   private static void Main(string[] args)
        //   {
        //       EntityFrameworkContext context = new EntityFrameworkContext();
        //
        //       context.Turmas.Add(new Turma(2100));
        //
        //       context.SaveChanges();
        //   }
      //                          ______  __ __           _   __          __ 
      //                         / ____/_/ // /   _   __/ | / /__  _  __/ /_
      //                        / /   /_ _  __/  | | / /  |/ / _ \| |/_/ __/
      //                       / /___/_ _  __/   | |/ / /|  /  __/>  </ /_  
      //                       \____/ /_//_/     |___/_/ |_/\___/_/|_|\__/  
                               
        public static void Main()
        {
            //Person p = null;
            //Console.WriteLine("Person name: " + p?.Name);

            //p = new Person();
            //Console.WriteLine("Person Name: " + p?.Name);

            //p.Name = "Namison";
            //Console.WriteLine($"Person Name: {p.Name} \n Age{{s}}:{p.Age}");

            //Console.WriteLine(p);

            //Console.ReadLine();
        }
        public class Person
        {
            public Person()
            {
                Name = "New Person";

            }
            public string Name { get; set; }
          //  public int Age { get; set; } = 14;

            //public override string ToString() => Name;

        }

        class Base
        {
            protected static void F() { }
        }
        class Derived : Base
        {
            new private static void F() { }   // Hides Base.F in Derived only
        }
        class MoreDerived : Derived
        {
            static void G() { F(); }         // Invokes Base.F
        }

    }
}