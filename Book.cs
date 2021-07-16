using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        //Explicit constructor method
       public Book(string name)
       {
           grades = new List<double>();
           Name = name;
       
       } 
       public void AddGrade(char letter)
       {
           switch(letter)
           {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
           }
       }
       public object AddGrade(double grade)
       {
           if(grade <= 100 && grade >= 0)
           {
               grades.Add(grade);
           }
           else
           {
               throw new ArgumentException($"Invalid {nameof(grade)}");
           }
        return "Invalid Input Value";// Solved the not all code paths return a value error
       }

       public Statistics GetStatistics()
       {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;



            foreach(var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when  d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when  d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when  d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when  d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;

            }

            return result;
            
       }

       private List<double> grades; //Fields to maintain state of an object
       
       public string Name //Getters and Setters
       
        {
            get;
            private set;
        } 

        //readonly string category = "Science";
        //const string category = "Science";
         
    }
}