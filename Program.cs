using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq_EF
{
    internal class Program
    {
        class Empolyee
        {
            public int Id {set;get;}
            public string Name { set; get; }
            public int Salary { set; get; }
            public int Dept { set; get; }
            public string Jobtitle { set; get; }
        }
        static void Main(string[] args)
        {
            //List<Empolyee> empolyee = new List<Empolyee>
            //{
            //    new Empolyee{Id=1,Name="Ahmed",Salary=3000,Dept=10,Jobtitle="HW"},
            //    new Empolyee{Id=2,Name="Zaki",Salary=4000,Dept=20,Jobtitle="SW"},
            //    new Empolyee{Id=3,Name="Mona",Salary=5000,Dept=30,Jobtitle="C#"},
            //    new Empolyee{Id=4,Name="Samir",Salary=6000,Dept=40,Jobtitle="IT"},
            //    new Empolyee{Id=5,Name="Ramy",Salary=7000,Dept=50,Jobtitle="C++"}
            //};

            //var query = from e in empolyee
            //            where e.Dept == 30
            //            select e;

            //foreach (var e in query)
            //{
            //    Console.WriteLine("ID : " + e.Id + " /Dept : " + e.Dept + " /Name : " + e.Name);
            //}

            //var query1 = from e in empolyee
            //             where e.Jobtitle == "C++"
            //             select e;

            //foreach (var e in query1)
            //{
            //    Console.WriteLine("ID : " + e.Id + " /Dept : " + e.Dept + " /Name : " + e.Name);
            //}

            //-------------------------------------------------arraylist----------------------------------------------//
            //ArrayList empo = new ArrayList();
            //empo.Add(new Empolyee { Id = 1, Name = "Ahmed", Salary = 3000, Dept = 10, Jobtitle = "HW" });
            //empo.Add(new Empolyee { Id = 2, Name = "Zaki", Salary = 4000, Dept = 20, Jobtitle = "SW" });
            //empo.Add(new Empolyee { Id = 3, Name = "Mona", Salary = 5000, Dept = 30, Jobtitle = "C#" });
            //empo.Add(new Empolyee { Id = 4, Name = "Samir", Salary = 6000, Dept = 40, Jobtitle = "IT" });
            //empo.Add(new Empolyee { Id = 5, Name = "Ramy", Salary = 7000, Dept = 50, Jobtitle = "C++" });

            //var query = from Empolyee empolyee in empo
            //            where empolyee.Dept == 10
            //            select empolyee;

            //foreach (Empolyee e in query)
            //{
            //    Console.WriteLine("(Name) : " + e.Name + "/ (Salary) : " + e.Salary + "/ (ID) : " + e.Id);
            //}

            //var query1 = from Empolyee empolyee in empo
            //             where empolyee.Jobtitle == "SW"
            //             select empolyee;

            //foreach (Empolyee e in query1)
            //{
            //    Console.WriteLine(" (Name) : " + e.Name + "/ (Salary) : " + e.Salary + "/ (ID) : " + e.Id);
            //}

            //-----------------------------------------------array--------------------------------------------------------//

            //var empolyee = new Empolyee[5];

            //empolyee[0] = new Empolyee { Dept = 10, Id = 1, Salary = 1000, Name = "Ahmed", Jobtitle = "HW" };

            //empolyee[1] = new Empolyee { Dept = 20, Id = 2, Salary = 2000, Name = "Zaki", Jobtitle = "SW" };

            //empolyee[2] = new Empolyee { Dept = 30, Id = 3, Salary = 3000, Name = "Mona", Jobtitle = "C#" };

            //empolyee[3] = new Empolyee { Dept = 40, Id = 4, Salary = 4000, Name = "Samir", Jobtitle = "IT" };

            //empolyee[4] = new Empolyee();
            //empolyee[4].Name = "Ramy";
            //empolyee[4].Id = 5;
            //empolyee[4].Salary = 4000;
            //empolyee[4].Dept = 50;
            //empolyee[4].Jobtitle = "C++";

            //var query1 = from e in empolyee
            //             where e.Dept == 30
            //             select e;
            //foreach (var e in query1)
            //{
            //    Console.WriteLine("(Name) : " + e.Name + "/ (Salary) : " + e.Salary + "/ (ID) : " + e.Id);
            //}

            //var query2 = from e in empolyee
            //             where e.Jobtitle == "C++"
            //             select e;
            //foreach (var e in query2)
            //{
            //    Console.WriteLine("(Name) : " + e.Name + "/ (Salary) : " + e.Salary + "/ (ID) : " + e.Id);
            //}

            //------------------------------------------------another_solution---------------------------------------------//

            //Empolyee[] empolyees =
            //{
            //    new Empolyee {Id=1,Name="Ahmed",Salary=3000,Dept=10,Jobtitle="HW"},
            //    new Empolyee { Id = 2, Name = "Zaki", Salary = 4000, Dept = 20, Jobtitle = "SW" },
            //    new Empolyee { Id = 3, Name = "Mona", Salary = 5000, Dept = 30, Jobtitle = "C#" },
            //    new Empolyee { Id = 4, Name = "Samir", Salary = 6000, Dept = 40, Jobtitle = "IT" },
            //    new Empolyee { Id = 5, Name = "Ramy", Salary = 7000, Dept = 50, Jobtitle = "C++" }
            //};
            //var query1 = from Empolyee empolyee in empolyees
            //             where empolyee.Dept == 10
            //             select empolyee;
            //foreach (Empolyee e in query1)
            //{
            //    Console.WriteLine("(Name) : " + e.Name + "/ (Salary) : " + e.Salary + "/ (ID) : " + e.Id);
            //}

            //var query2 = from Empolyee empolyee in empolyees
            //             where empolyee.Jobtitle == "SW"
            //             select empolyee;
            //foreach (Empolyee e in query2)
            //{
            //    Console.WriteLine("(Name) : " + e.Name + "/ (Salary) : " + e.Salary + "/ (ID) : " + e.Id);
            //}
        }
    }
}
