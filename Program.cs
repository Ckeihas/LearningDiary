using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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


                Console.WriteLine(" ");

                //Tsekkaa onko vastaus learning progressiin yes vai no
                if (isGoing.ToLower() == "yes")
                {
                    topics.InProgress = true;
                    
                }

                else if (isGoing.ToLower() == "no")
                {
                    topics.InProgress = false;

                    Console.WriteLine("Write the date you stop learning", "dd,mm,yyyy: ");
                    topics.FinishedLearning = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine(" ");
                    
                }

                inputsList.Add(topics);

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

            Console.WriteLine("Do you want to search Topic you receantly added?: Type yes or no");
            string showTopics = Console.ReadLine();

            if (showTopics.ToLower() == "yes")
            {
                Console.WriteLine("Type ID number: ");
                int idNumber = int.Parse(Console.ReadLine());

                Topics t = inputsList.Find(x => x.Id == idNumber);
                Console.WriteLine(t);

                Console.WriteLine("Do you want to edit this topics fields? Type yes or type e for exit: ");
                string editAnswer = Console.ReadLine();

                Console.WriteLine(" ");

                if(editAnswer.ToLower() == "yes")
                {
                    Console.WriteLine(
                    "1) ID "
                    + "\n" +
                    "2) Title"
                    + "\n" +
                    "3) Description"
                    + "\n" +
                    "4) Estimated time to master"
                    + "\n" +
                    "5) Used time"
                    + "\n" +
                    "6) Source"
                    + "\n" +
                    "7) Day you started"
                    + "\n" +
                    "8) Day you finished"
                    );



                    //Aiheen muokkaaminen
                    Console.WriteLine("Select a number you want to edit and type the number: ");
                    int typedNum = int.Parse(Console.ReadLine());

                    if (typedNum == 2)
                    {
                        Console.WriteLine("Write new Title: ");
                        string newTitle = Console.ReadLine();

                        t.TheTitle = newTitle;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new title is: " + t.TheTitle);
                    }

                    if(typedNum == 3)
                    {
                        Console.WriteLine("Write new Description: ");
                        string newDescription = Console.ReadLine();

                        t.TheDescription = newDescription;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new description is: " + t.TheDescription);
                    }

                    if(typedNum == 4)
                    {
                        Console.WriteLine("Write new estimated time to master: ");
                        double newTimeToMaster = double.Parse(Console.ReadLine());

                        t.EstimatedTimeToMaster = newTimeToMaster;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new estimated time is: " + t.EstimatedTimeToMaster);
                    }

                    if(typedNum == 5)
                    {
                        Console.WriteLine("Write new used time: ");
                        double newTimeToMaster = double.Parse(Console.ReadLine());

                        t.TheUsedTime = newTimeToMaster;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new estimated time is: " + t.TheUsedTime);
                    }

                    if(typedNum == 6)
                    {
                        Console.WriteLine("Write new source: ");
                        string newSource = Console.ReadLine();

                        t.TheSource = newSource;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new source is: " + t.TheSource);
                    }

                    if(typedNum == 7)
                    {
                        Console.WriteLine("Change the starting date: ");
                        DateTime newStartingDate = Convert.ToDateTime(Console.ReadLine());

                        t.StartLearning = newStartingDate;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new starting date is: " + t.StartLearning.ToShortDateString());
                    }

                    if (typedNum == 8)
                    {
                        Console.WriteLine("Change the starting date: ");
                        DateTime newEndDate = Convert.ToDateTime(Console.ReadLine());

                        t.StartLearning = newEndDate;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new ending date is: " + t.FinishedLearning.ToShortDateString());
                    }
                }
               
            }

            else
            {
                Console.WriteLine("You added " + inputsList.Count + " new topics");
                Console.WriteLine(" ");
                foreach (Topics item in inputsList)
                {
                    Console.WriteLine(item);
                }
            }



            //Lisätyn aiheen poistaminen
            Console.WriteLine("Delete topic with ID number: yes or no ");
            string deleteAnswer = Console.ReadLine();

            if(deleteAnswer.ToLower() == "yes")
            {
                Console.WriteLine("write id number: ");
                int deleteNum = int.Parse(Console.ReadLine());
               
                inputsList.RemoveAll(x => x.Id == deleteNum);
                                            
            }


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

        public static void Edit()
        {
            Console.WriteLine("Select topic you want to edit and press the number of topic: ");
            int typedNum = int.Parse(Console.ReadLine());

            Console.WriteLine(
                "1) ID " 
                + "\n" +
                "2) Title"
                + "\n" +
                "3) Description"
                + "\n" +
                "4) Estimated time to master"
                + "\n" +
                "5) Used time"
                + "\n" +
                "6) Source"
                + "\n" +
                "7) Day you started"
                + "\n" +
                "8) Day you finished"
                );
        }
    }
}
