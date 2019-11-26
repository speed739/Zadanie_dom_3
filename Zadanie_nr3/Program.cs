using System;
using System.Collections.Generic;
using System.Linq;
namespace Zadanie_nr3
{
    class Uczen
    {
        public string Name;
        public string LastName;
        public double AvarageSem, x, y, z;
        public List<double> gradeMath = new List<double>();
        public List<double> gradePol = new List<double>();
        public List<double> gradeCode = new List<double>();

        public Uczen(string Name, string LastName, List<double> gradeMath, List<double> gradePol, List<double> gradeCode)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.gradeMath = gradeMath;
            this.gradePol = gradePol;
            this.gradeCode = gradeCode;

        }
        public void Display(Uczen a)
        {
            Console.WriteLine("Podane oceny Ucznia {0} {1}", a.Name, a.LastName);
            Console.WriteLine();

            Console.WriteLine("Matematyka");
            foreach (var item in a.gradeMath)
            {
                Console.Write("[" + item + "] ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Polski");
            foreach (var item in a.gradePol)
            {
                Console.Write("[" + item + "] ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Programovanie");
            foreach (var item in a.gradeCode)
            {
                Console.Write("[" + item + "] ");
            }
            Console.WriteLine();
            Console.WriteLine();

        }

    }
    class Grade
    {
        public string Subject;
        public string[] Subjectname = { "Matematyka", "Polski", "Programovanie" };
        public double[] weight = { 3, 1, 4 };
        public double Avarage(Grade a, Uczen b)
        {
            if (a.Subjectname[0] == Subject)
            {
                b.x = b.gradeMath.Average();
                return b.x;
            }

            if (a.Subjectname[1] == Subject)
            {
                b.y = b.gradePol.Average(); 
                return b.y;
            }

            if (a.Subjectname[2] == Subject)
            {
                b.z = b.gradeCode.Average();
                return b.z;
            }
            
            return 0;
        }
        public double SredniaSem(Uczen a)
        {
            Console.WriteLine("Srednie ocena z Matematyki - " + String.Format("{0:N2}", a.x));
            Console.WriteLine("Srednia ocena z Polskiego - " + String.Format("{0:N2}", a.y));
            Console.WriteLine("Srednia ocena z Programovania - " + String.Format("{0:N2}", a.z));
            Console.WriteLine();
            a.AvarageSem = ((a.x * weight[0]) + (a.y * weight[1]) + (a.z * weight[2])) / (weight[0] + weight[1] + weight[2]);
            return a.AvarageSem;
        }
        class Program
        {
            static void Main(string[] args)
            {
                List<double> ocenyMat = new List<double>();
                ocenyMat.Add(5); ocenyMat.Add(4); ocenyMat.Add(3.5);
                List<double> ocenyPol = new List<double>();
                ocenyPol.Add(4.5); ocenyPol.Add(4); ocenyPol.Add(3.75);
                List<double> ocenyCode = new List<double>();
                ocenyCode.Add(4); ocenyCode.Add(4.75); ocenyCode.Add(5);
                
                Uczen a = new Uczen("Jan", "Novak", ocenyMat, ocenyPol, ocenyCode);
                Grade ag = new Grade();

                List<double> ocenyMat1 = new List<double>();
                ocenyMat1.Add(3); ocenyMat1.Add(4); ocenyMat1.Add(3.5);
                List<double> ocenyPol1 = new List<double>();
                ocenyPol1.Add(3.5); ocenyPol1.Add(3); ocenyPol1.Add(4);
                List<double> ocenyCode1 = new List<double>();
                ocenyCode1.Add(3); ocenyCode1.Add(5); ocenyCode1.Add(5);

                Uczen b = new Uczen("Piotr", "Plesniar", ocenyMat1, ocenyPol1, ocenyCode1);
                Grade bg = new Grade();
               
                List<Uczen> ListaUczniov = new List<Uczen>();
                ListaUczniov.Add(a); ListaUczniov.Add(b);

                a.Display(a);
                b.Display(b);
                bg.Subject = "Matematyka"; bg.Avarage(bg, b);
                bg.Subject = "Polski"; bg.Avarage(bg, b);
                bg.Subject = "Programovanie"; bg.Avarage(bg, b);
                string text;
                
                do
                {
                    Console.WriteLine("Z ktorego przedmiotu chcesz obl srednia uczen Jan Novak vpisz:\n" +
                        "Matematyka, Polski, Programovanie");

                    ag.Subject = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Srednia Ocena z przedmiotu {0} = {1} ", ag.Subject,
                                       String.Format("{0:N2}", ag.Avarage(ag, a)));

                    Console.WriteLine("Chcesz obl pozostałe przedmioty ? y/n ");
                    text = Console.ReadLine();
                    Console.WriteLine();

                } while (text == "y");

                Console.WriteLine();
                Console.WriteLine("Srednia Sem Ucznia {0} {1} = {2}" ,a.Name,a.LastName, 
                    String.Format("{0:N2}",ag.SredniaSem(a)));
                Console.WriteLine();
                Console.WriteLine("Srednia Sem Ucznia {0} {1} = {2}" ,b.Name,b.LastName,
                    String.Format("{0:N2}", bg.SredniaSem(b)));
                Console.WriteLine();
                Console.WriteLine("Najlepsza srednia to : " + ListaUczniov.Max(x =>
                                   String.Format("{0:N2}",x.AvarageSem)+" Uczen : "+x.Name));

            }
        }
    }
}