using System;
using System.Collections.Generic;
using System.IO;

namespace LearningDiary
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Would you like to see all the topics? Type yes or no: ");
            //string topicAnswer = Console.ReadLine();

            //TopicQuestion(topicAnswer);
         
            ExposeTheTextFile();
            Console.WriteLine(" ");
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
            bool newTopic = true;

            do {
                
                Console.WriteLine("Write ID: ");
                userInputs.Id = int.Parse(Console.ReadLine());

                Console.WriteLine(" ");

                Console.WriteLine("Write the title: ");
                userInputs.TheTitle = Console.ReadLine();

                Console.WriteLine(" ");

                Console.WriteLine("Write the description: ");
                userInputs.TheDescription = Console.ReadLine();

                Console.WriteLine(" ");

                Console.WriteLine("How much time do you think you gonna spend: ");
                userInputs.EstimatedTimeToMaster = double.Parse(Console.ReadLine());

                Console.WriteLine(" ");

                Console.WriteLine("How much time you have used so far?: ");
                userInputs.TheUsedTime = double.Parse(Console.ReadLine());

                Console.WriteLine(" ");

                Console.WriteLine("What source do you use: ");
                userInputs.TheSource = Console.ReadLine();

                Console.WriteLine(" ");

                Console.WriteLine("Write the date you started learning: dd/mm/yyyy");
                userInputs.StartLearning = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine(" ");

                Console.WriteLine("Is your learning progress still going? Type yes or no: ");
                string isGoing = Console.ReadLine();

                Console.WriteLine(" ");

                //Tsekkaa onko vastaus learning progressiin yes vai no
                if (isGoing.ToLower() == "yes")
                {
                    userInputs.InProgress = true;
                    inputsList.Add(
                    "ID: " + userInputs.Id + "\n" +
                    "Title: " + userInputs.TheTitle + " \n" +
                    "Description: " + userInputs.TheDescription + " \n" +
                    "Estimated Time To Master: " + userInputs.EstimatedTimeToMaster + "\n" +
                    "Used Time: " + userInputs.TheUsedTime + "h" + " \n" +
                    "Used Source: " + userInputs.TheSource + "\n" +
                    "Started learning: " + userInputs.StartLearning.ToShortDateString() + "\n" +
                    "Are you still learning?: " + userInputs.InProgress + "\n"
                    );
                }

                else if (isGoing.ToLower() == "no")
                {
                    userInputs.InProgress = false;

                    Console.WriteLine("Write the date you stop learning", "dd,mm,yyyy: ");
                    userInputs.FinishedLearning = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine(" ");
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

                Console.WriteLine("Do you want to add another topic? Type yes or no: ");
                string anotherTopic = Console.ReadLine();

                
                if (anotherTopic.ToLower() == "yes")
                {
                    Console.Clear();
                    newTopic = true;
                }
                else 
                {
                    Console.Clear();
                    newTopic = false;
                }
            }
            while (newTopic);

            string[] inputsToArray = inputsList.ToArray();
            Console.WriteLine("You added " + inputsToArray.Length + " new topics");

            foreach (var item in inputsToArray)
            {
                Console.WriteLine(item);
            }

            //Tiedostoon lisääminen
            if (File.Exists(path))
            {
                File.AppendAllText(path, string.Join(Environment.NewLine, inputsToArray));
                
            }
        }



        static void ExposeTheTextFile()
        {
            string path = @"C:\Users\ChristianKeihäs\source\repos\LearningDiary\Topics.txt";
            Console.WriteLine("Would you like to see your topics so far? Type yes or no: ");
            string exposeFiles = Console.ReadLine();

            if(exposeFiles.ToLower() == "yes")
            {
                if(new FileInfo(path).Length == 0)
                {
                    Console.WriteLine("You have empty file");
                }

                if (File.Exists(path)) 
                {
                    try
                    {
                        string readTextFile = File.ReadAllText(path);
                        Console.WriteLine(readTextFile);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("File doesn't exist");
                        Console.WriteLine(e.Message);
                    }
                }
                
            }
        }
    }




    class UserInputs
    {
        public int Id { get; set; }
        public string TheTitle { get; set; }
        public string TheDescription { get; set; }
        public double EstimatedTimeToMaster { get; set; }
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
