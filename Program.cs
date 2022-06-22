using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LearningDiary.Models;

namespace LearningDiary
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(" ");
            HandlingUserInputs();

        }



        static void HandlingUserInputs()
        {

            bool newTopic = true;

            using (LearningDiaryContext table = new LearningDiaryContext())
            {
                var topics = table.Topics.Select(x => x);
                var userInput = new Topic();

                Console.WriteLine("MAIN MENU");
                Console.WriteLine(" ");
                Console.WriteLine("A) Add a new topic \n " +
                    "B) Search topics with ID \n" +
                    "C) Edit your topics \n" +
                    "D) Delete topics");

                Console.WriteLine("Write the letter you wanna go to: ");
                string mainMenuAnswer = Console.ReadLine();


                //Uuden topicin lisääminen
                if (mainMenuAnswer.ToLower() == "a")
                {
                    do
                    {

                        Console.WriteLine("Write the title: ");
                        userInput.Title = Console.ReadLine();

                        Console.WriteLine(" ");

                        Console.WriteLine("Write the description: ");
                        userInput.Description = Console.ReadLine();

                        Console.WriteLine(" ");

                        Console.WriteLine("How much time do you think you gonna spend: ");
                        userInput.TimeToMaster = int.Parse(Console.ReadLine());

                        Console.WriteLine(" ");

                        Console.WriteLine("How much time you have used so far?: ");
                        userInput.TimeSpend = int.Parse(Console.ReadLine());

                        Console.WriteLine(" ");

                        Console.WriteLine("What source do you use: ");
                        userInput.Source = Console.ReadLine();

                        Console.WriteLine(" ");

                        Console.WriteLine("Write the date you started learning: dd/mm/yyyy");
                        userInput.StartLearningDate = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine(" ");

                        Console.WriteLine("Is your learning progress still going? Type yes or no: ");
                        string isGoing = Console.ReadLine();


                        Console.WriteLine(" ");

                        //Tsekkaa onko vastaus learning progressiin yes vai no
                        if (isGoing.ToLower() == "yes")
                        {
                            userInput.InProgress = true;

                        }

                        else if (isGoing.ToLower() == "no")
                        {
                            userInput.InProgress = false;

                            Console.WriteLine("Write the date you stop learning", "dd,mm,yyyy: ");
                            userInput.CompletionDate = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine(" ");

                        }


                        //Lisää uusi topic tai poistu
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

                        table.Topics.Add(userInput);
                        table.SaveChanges();
                    }
                    while (newTopic);

                    //Console.WriteLine("You added" + userInput.Count() + "new topics!");
                }


                //Näytä topic haetulla ID numerolla
                if (mainMenuAnswer.ToLower() == "b")
                {
                    Console.WriteLine("Write the ID number: ");
                    int searchIdNum = int.Parse(Console.ReadLine());

                    var showTopic = table.Topics.Where(x => x.Id == searchIdNum);
                    foreach (var item in showTopic)
                    {
                        Console.WriteLine(item);
                    }
                }


                //Editoi topicia haetulla id numerolla
                if (mainMenuAnswer.ToLower() == "c")
                {
                    Console.WriteLine("Write topics ID number what you want to edit: ");
                    int editAnswer = int.Parse(Console.ReadLine());

                    var editTopic = table.Topics.Where(x => x.Id == editAnswer);



                    Console.WriteLine(
                   "1) Title"
                   + "\n" +
                   "2) Description"
                   + "\n" +
                   "3) Estimated time to master"
                   + "\n" +
                   "4) Used time"
                   + "\n" +
                   "5) Source"
                   + "\n" +
                   "6) Day you started"
                   + "\n" +
                   "7) Day you finished"
                   );

                    Console.WriteLine("Select a number you want to edit and type the number: ");
                    int typedNum = int.Parse(Console.ReadLine());

                    var haeTopic = table.Topics.Where(x => x.Id == typedNum).Single();

                    if (typedNum == 1)
                    {
                        Console.WriteLine("Write new Title: ");
                        string newTitle = Console.ReadLine();

                        haeTopic.Title = newTitle;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new title is: " + haeTopic.Title);
                    }

                    if (typedNum == 2)
                    {
                        Console.WriteLine("Write new Description: ");
                        string newDescription = Console.ReadLine();

                        haeTopic.Description = newDescription;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new description is: " + haeTopic.Description);
                    }

                    if (typedNum == 3)
                    {
                        Console.WriteLine("Write new estimated time to master: ");
                        int newTimeToMaster = int.Parse(Console.ReadLine());

                        haeTopic.TimeToMaster = newTimeToMaster;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new estimated time is: " + haeTopic.TimeToMaster);
                    }

                    if (typedNum == 4)
                    {
                        Console.WriteLine("Write new used time: ");
                        int newTimeToMaster = int.Parse(Console.ReadLine());

                        haeTopic.TimeSpend = newTimeToMaster;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new estimated time is: " + haeTopic.TimeSpend);
                    }

                    if (typedNum == 5)
                    {
                        Console.WriteLine("Write new source: ");
                        string newSource = Console.ReadLine();

                        haeTopic.Source = newSource;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new source is: " + haeTopic.Source);
                    }

                    if (typedNum == 6)
                    {
                        Console.WriteLine("Change the starting date: ");
                        DateTime newStartingDate = Convert.ToDateTime(Console.ReadLine());

                        haeTopic.StartLearningDate = newStartingDate;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new starting date is: " + haeTopic.StartLearningDate);
                    }

                    if (typedNum == 7)
                    {
                        Console.WriteLine("Change the ending date: ");
                        DateTime newEndDate = Convert.ToDateTime(Console.ReadLine());

                        haeTopic.CompletionDate = newEndDate;
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new ending date is: " + haeTopic.CompletionDate);
                    }

                    table.SaveChanges();
                }
            }


        }

    }
}
