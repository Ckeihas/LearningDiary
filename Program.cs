﻿using System;
using System.Collections.Generic;
using System.IO;

namespace LearningDiary
{
    class Program
    {
        static void Main(string[] args)
        {

            var inputsList = new List<string>();
            UserInputs userInputs = new UserInputs();
            string path = @"C:\Users\ChristianKeihäs\source\repos\LearningDiary\Topics.txt";



            Console.WriteLine("Write the title: ");
                userInputs.TheTitle = Console.ReadLine();

                Console.WriteLine("Write the description: ");
                userInputs.TheDescription = Console.ReadLine();

                Console.WriteLine("How much time do you think you gonna spend: ");
                userInputs.TheUsedTime = double.Parse(Console.ReadLine());

                Console.WriteLine("What source do you use: ");
                userInputs.TheSource = Console.ReadLine();

                Console.WriteLine("Write the date you started learning: dd/mm/yyyy");
                userInputs.StartLearning = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Is your learning progress still going? Type yes or no: ");
                string isGoing = Console.ReadLine();



                if (isGoing.ToLower() == "yes")
                {
                    userInputs.InProgress = true;

                }

                else if (isGoing.ToLower() == "no")
                {
                    userInputs.InProgress = false;

                    Console.WriteLine("Write the date you stop learning", "dd,mm,yyyy: ");
                    userInputs.FinishedLearning = Convert.ToDateTime(Console.ReadLine());

                }

                inputsList.Add(
                    userInputs.TheTitle + " " +
                    userInputs.TheDescription + " " +
                    userInputs.TheUsedTime + " " +
                    userInputs.TheSource + " " +
                    userInputs.StartLearning + " " +
                    userInputs.InProgress + " " +
                    userInputs.FinishedLearning
                    );

                    string[] inputsToArray = inputsList.ToArray();
                    foreach (var item in inputsToArray)
                    {
                        Console.WriteLine(item);
                    }



            //Tiedostoon lisääminen

            if (File.Exists(path))
            {
                File.AppendAllText(path, string.Join(Environment.NewLine, inputsList));
                /*
                try
                {
                    String[] lines;
                    lines = File.ReadAllLines(path);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        Console.WriteLine(lines[i]);
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine("Tiedostoa ei voida lukea");
                    Console.WriteLine(e.Message);
                }
                */
            }
            else
            {
                Console.WriteLine("Tiedostoa ei löydy");
            }
        }
    }
    class UserInputs
    {
        public int Id { get; set; }
        public string TheTitle { get; set; }
        public string TheDescription { get; set; }
        public double TheUsedTime { get; set; }
        public string TheSource { get; set; }
        public bool InProgress { get; set; }
        public DateTime StartLearning { get; set; }
        public DateTime FinishedLearning { get; set; }
        
    }

    class Topic
    {
        public string Topics { get; set; }
    }
}
