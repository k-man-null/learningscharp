using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)//Method is Main
        {   
            var book = new Book("Bill's Grade Book");
            // book.AddGrade(45.5);
            // book.AddGrade(40.25);
            // book.AddGrade(42.15);
            // book.AddGrade(35.5);

            while(true)
            {
                Console.WriteLine("Enter a Grade or 'Q' to quit" );
                var input = Console.ReadLine();
                
                if(input == "Q")
                {
                   break;
                }

                try 
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }

                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)  
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                   Console.WriteLine("**"); 
                }
                
            }
            
            var stats = book.GetStatistics();
    

            Console.WriteLine($"For the {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
        
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter is {stats.Letter}");
        }
    }
}
