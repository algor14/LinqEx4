using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEx4
{
    class Actor
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    abstract class ArtObject
    {

        public string Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
    class Film : ArtObject
    {

        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
    class Book : ArtObject
    {

        public int Pages { get; set; }
    }

    static class IntExtension
    {
        public static long Factorial(this int val)
        {
            return Enumerable.Range(1, val).Aggregate((fact, element) => fact * element);
        }
    }




    class Film2
    {
        public string Name { get; set; }
        public string Director { get; set; }
    }
    class Director
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    class Movie
    {
        Film2 film;
        Director dir;
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(String.Join(",", Enumerable.Range(1,50).ToArray()));
            //Console.WriteLine(String.Join(",", Enumerable.Range(10, 40).Where(f=> f%3 ==0).ToArray()));
            //Console.WriteLine(String.Join(",", Enumerable.Repeat("Linq", 10).ToArray()));

            var data = new List<object>() {
                        "Hello",
                        new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
                        new List<int>() {4, 6, 8, 2},
                        new string[] {"Hello inside array"},
                        new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                            new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 11, 4)},
                            new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                            new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                        }},
                        new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                            new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                            new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                        }},
                        new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
                        "Leonardo DiCaprio"
                    };
            //data.Except<ArtObject>();
            foreach (var item in data.Except(data.OfType<ArtObject>()))
            {
                //Console.WriteLine(item);
            }
            //data.Where(f => f is Film)
            foreach (var item in data.OfType<Film>().SelectMany(f => f.Actors).Select(f => f.Name).Distinct().ToArray())
            {
                //Console.WriteLine(item);
            }
            //Console.WriteLine(data.OfType<Film>().SelectMany(f => f.Actors).Where(f=> f.Birthdate.Month == 8).Select(f => f.Name).Distinct().Count());
           // Console.WriteLine(data.OfType<Film>().SelectMany(f => f.Actors).Order);

            long t = 3.Factorial();
            Console.WriteLine(t);

            string[] strs = new string[]
            {
                "Hello",
                "World",
                "!"
            };

            
            Console.WriteLine( strs.Aggregate((totalString, newString) => totalString + " " + newString));


            List<Film2> teams = new List<Film2>()
                        {
                            new Film2 { Name = "The Silence of the Lambs", Director ="Jonathan Demme" },
                            new Film2 { Name = "The World's Fastest Indian", Director ="Roger Donaldson" }
                            new Film2 { Name = "The Recruit", Director ="Roger Donaldson" }
                        };
            List<Director> players = new List<Director>()
                        {
                            new Director {Name="Jonathan Demme", Country="USA"},
                            new Director {Name="Roger Donaldson", Country="New Zealand"},
                        };

            //teams.Join(players, a => a.Director, b => b.Name, (a, b) => new Movie() { di,  });

        }
    }
}
