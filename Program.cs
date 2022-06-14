using System;
using System.Collections.Generic;
using System.IO;

namespace LearningDiary
{
    class Program
    {
        static void Main(string[] args)
        {

            ExposeTheTextFile();
            Console.WriteLine(" ");
            HandlingUserInputs();

        }



        static void HandlingUserInputs() 
        {
            string path = @"C:\Users\ChristianKeihäs\source\repos\LearningDiary\Topics.txt";
            List<Topics> inputsList = new List<Topics>();
            
            bool newTopic = true;


            do {
                Topics topics = new Topics();

                Console.WriteLine("Do you want to search Topic you receantly added?: Type yes or no");
                string showTopics = Console.ReadLine();

                if (showTopics.ToLower() == "yes")
                {
                    Console.WriteLine("Type ID number: ");
                    int idNumber = int.Parse(Console.ReadLine());

                    Topics t = inputsList.Find(x => x.Id == idNumber);
                    Console.WriteLine(t);
                }
                
                Console.WriteLine("Write ID: ");
                topics.Id = int.Parse(Console.ReadLine());

                Console.WriteLine(" ");

                Console.WriteLine("Write the title: ");
                topics.TheTitle = Console.ReadLine();

                Console.WriteLine(" ");

                Console.WriteLine("Write the description: ");
                topics.TheDescription = Console.ReadLine();

                Console.WriteLine(" ");

                Console.WriteLine("How much time do you think you gonna spend: ");
                topics.EstimatedTimeToMaster = double.Parse(Console.ReadLine());

                Console.WriteLine(" ");

                Console.WriteLine("How much time you have used so far?: ");
                topics.TheUsedTime = double.Parse(Console.ReadLine());

                Console.WriteLine(" ");

                Console.WriteLine("What source do you use: ");
                topics.TheSource = Console.ReadLine();

                Console.WriteLine(" ");

                Console.WriteLine("Write the date you started learning: dd/mm/yyyy");
                topics.StartLearning = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine(" ");

                Console.WriteLine("Is your learning progress still going? Type yes or no: ");
                string isGoing = Console.ReadLine();

                inputsList.Add(topics);

                Console.WriteLine(" ");

                //Tsekkaa onko vastaus learning progressiin yes vai no
                if (isGoing.ToLower() == "yes")
                {
                    topics.InProgress = true;
                    inputsList.Add(topics);
                }

                else if (isGoing.ToLower() == "no")
                {
                    topics.InProgress = false;

                    Console.WriteLine("Write the date you stop learning", "dd,mm,yyyy: ");
                    topics.FinishedLearning = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine(" ");
                    inputsList.Add(topics);
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

            
            Console.WriteLine("You added " + inputsList.Count + " new topics");
            Console.WriteLine(" ");
            //foreach (Topics item in inputsList)
            //{
            //    Console.WriteLine(item);
            //}

            //Tiedostoon lisääminen
            if (File.Exists(path))
            {
                File.AppendAllText(path, string.Join(Environment.NewLine, inputsList));
                
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


    class Topics
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

        public override string ToString()
        {
            string overriding = "";

            overriding += "ID: " + Id + "\n";
            overriding += "Title: " + TheTitle + "\n";
            overriding += "Description: " + TheDescription + "\n";
            overriding += "Estimated time to master: " + EstimatedTimeToMaster + "\n";
            overriding += "Used time so far: " + TheUsedTime + "\n";
            overriding += "Sources: " + TheSource + "\n";
            overriding += "Are you still learning: " + InProgress + "\n";
            overriding += "You started learning: " + StartLearning.ToShortDateString() + "\n";
            overriding += "You finished learning: " + FinishedLearning.ToShortDateString() + "\n";


            return overriding;
        }
    }
}
