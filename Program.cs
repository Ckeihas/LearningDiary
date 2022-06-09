using System;
using System.Collections.Generic;
using System.IO;

namespace LearningDiary
{
    class Program
    {
        static void Main(string[] args)
        {
     
            Console.WriteLine("Would you like to see all the topics? Type yes or no: ");
            string topicAnswer = Console.ReadLine();

            TopicQuestion(topicAnswer);

            HandlingUserInputs();

        }



        static void ShowTopics()
        {
            string[] topics = {
                "ID", 
                "Title", 
                "Description",
                "Estimated time to master", 
                "Time Spend", "Source", 
                "Start Learning Date",
                "In progress",
                "Completion Date"
            };

            foreach (var item in topics)
            {
                Console.WriteLine(item);
            }
        }




        static void TopicQuestion(string answer)
        {

            if (answer.ToLower() == "yes")
            {
                ShowTopics();
                Console.WriteLine(" ");
            }
            
        }


        static void HandlingUserInputs() 
        {
            string path = @"C:\Users\ChristianKeihäs\source\repos\LearningDiary\Topics.txt";
            var inputsList = new List<string>();
            UserInputs userInputs = new UserInputs();

            Console.WriteLine("Write ID: ");
            userInputs.Id = int.Parse(Console.ReadLine());

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


            //Tsekkaa onko vastaus learning progressiin yes vai no
            if (isGoing.ToLower() == "yes")
            {
                userInputs.InProgress = true;
                inputsList.Add(
                "ID: " + userInputs.Id + "\n" +
                "Title: " + userInputs.TheTitle + " \n" +
                "Description: " + userInputs.TheDescription + " \n" +
                "Used Time: " + userInputs.TheUsedTime + "h" + " \n" +
                "Used Source: " + userInputs.TheSource + "\n" +
                "Started learning: " + userInputs.StartLearning.ToShortDateString() + "\n" +
                "Are you still learning?: " + userInputs.InProgress + "\n"
                //"You finished learning: " + userInputs.FinishedLearning.ToShortDateString()
                );
            }

            else if (isGoing.ToLower() == "no")
            {
                userInputs.InProgress = false;

                Console.WriteLine("Write the date you stop learning", "dd,mm,yyyy: ");
                userInputs.FinishedLearning = Convert.ToDateTime(Console.ReadLine());
                inputsList.Add(
                "ID: " + userInputs.Id + "\n" +
                "Title: " + userInputs.TheTitle + " \n" +
                "Description: " + userInputs.TheDescription + " \n" +
                "Used Time: " + userInputs.TheUsedTime + "h" + " \n" +
                "Used Source: " + userInputs.TheSource + "\n" +
                "Started learning: " + userInputs.StartLearning.ToShortDateString() + "\n" +
                "Are you still learning?: " + userInputs.InProgress + "\n" +
                "You finished learning: " + userInputs.FinishedLearning.ToShortDateString()
                );
            }

            string[] inputsToArray = inputsList.ToArray();
            foreach (var item in inputsToArray)
            {
                Console.WriteLine(item);
            }

            //Tiedostoon lisääminen

            if (File.Exists(path))
            {
                File.AppendAllText(path, string.Join(Environment.NewLine, inputsToArray));
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
                
            }
            else
            {
                Console.WriteLine("Tiedostoa ei löydy");
            }
                */
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
