using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using LearningDiary.Models;
using LauraJaChristianHarkka;
using TopicQuestions;

namespace LearningDiary
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine(" ");
            await HandlingUserInputs();

            
        }


        static async Task HandlingUserInputs()
        {
            Class1 compare = new Class1();
            
            bool newTopic = true;

            using (LearningDiaryContext table = new LearningDiaryContext())
            {
                var topics = table.Topics.Select(x => x);
                var userInput = new Topic();

                Console.WriteLine("MAIN MENU");
                Console.WriteLine(" ");
                Console.WriteLine("A) Add a new topic \n" +
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

                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Write the title: ");
                                userInput.Title = Console.ReadLine();
                                break;
                            }
                            catch
                            {

                                Console.WriteLine("Error! Write valid Title");
                            } 
                        }

                        Console.WriteLine(" ");

                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Write the description: ");
                                userInput.Description = Console.ReadLine();
                                break;
                            }
                            catch
                            {

                                Console.WriteLine("Error! Write valid Description");
                            } 
                        }

                        Console.WriteLine(" ");

                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("How much time do you think you gonna spend: ");
                                userInput.TimeToMaster = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {

                                Console.WriteLine("Error! Write only numbers");
                            } 
                        }

                        Console.WriteLine(" ");

                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("How much time you have used so far?: ");
                                userInput.TimeSpend = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {

                                Console.WriteLine("Error! Write only numbers");
                            } 
                        }

                        Console.WriteLine(" ");

                        Console.WriteLine("What source do you use: ");
                        userInput.Source = Console.ReadLine();

                        Console.WriteLine(" ");

                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Write the date you started learning: dd/mm/yyyy");
                                userInput.StartLearningDate = Convert.ToDateTime(Console.ReadLine());
                                break;
                            }
                            catch
                            {

                                Console.WriteLine("Write a valid date");
                            } 
                        }

                        //Paritehtävä
                        bool tulos = compare.IsFuture((DateTime)userInput.StartLearningDate);

                        Console.WriteLine(tulos);

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

                        /*Paritehtävä
                        compare.Start((DateTime)userInput.StartLearningDate, (double)userInput.TimeToMaster);

                        TimeSpan ts = TimeSpan.FromDays((long)userInput.TimeToMaster);

                        compare.IsLate((DateTime)userInput.StartLearningDate, (DateTime)userInput.CompletionDate, ts);
                        */


                        table.Topics.Add(userInput);
                        table.SaveChanges();

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

                    }
                    while (newTopic);

                    //Console.WriteLine("You added" + userInput.Count() + "new topics!");
                }


                //Näytä haettu topic
                await ShowWithId(mainMenuAnswer);

                //Poista topic
                await DeleteTopic(mainMenuAnswer);

                //Editoi topicia
                await EditTopic(mainMenuAnswer);
                

            }


        }



        //Editoi topicia
        public static async Task EditTopic(string mainMenuAnswer)
        {
            Topic olio = new Topic();
            using (LearningDiaryContext ld = new LearningDiaryContext())
            {
                if (mainMenuAnswer.ToLower() == "c")
                {
                    Console.WriteLine("Write topics ID number what you want to edit: ");
                    int editAnswer = int.Parse(Console.ReadLine());

                    var editTopic = await Task.Run(() => ld.Topics.Where(x => x.Id == editAnswer));



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

                    //var haeTopic = ld.Topics.Where(x => x.Id == typedNum).Single();

                    if (typedNum == 1)
                    {
                        Console.WriteLine("Write new Title: ");
                        string newTitle = Console.ReadLine();

                        foreach (var x in editTopic)
                        {
                            x.Title = newTitle;
                        }

                        try
                        {
                            ld.SaveChanges();
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e);
                        }
                        
                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new title is: " + newTitle);

                    }

                    if (typedNum == 2)
                    {
                        Console.WriteLine("Write new Description: ");
                        string newDescription = Console.ReadLine();

                        foreach (var x in editTopic)
                        {
                            x.Description = newDescription;
                        }

                        try
                        {
                            ld.SaveChanges();
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e);
                        }

                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new description is: " + newDescription);
                    }

                    if (typedNum == 3)
                    {
                        Console.WriteLine("Write new estimated time to master: ");
                        int newTimeToMaster = int.Parse(Console.ReadLine());

                        foreach (var x in editTopic)
                        {
                            x.TimeToMaster = newTimeToMaster;
                        }

                        try
                        {
                            ld.SaveChanges();
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e);
                        }

                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new time to master is: " + newTimeToMaster);
                    }

                    if (typedNum == 4)
                    {
                        Console.WriteLine("Write new used time: ");
                        int newTimeSpend = int.Parse(Console.ReadLine());

                        foreach (var x in editTopic)
                        {
                            x.TimeSpend = newTimeSpend;
                        }

                        try
                        {
                            ld.SaveChanges();
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e);
                        }

                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new used time is: " + newTimeSpend);
                    }

                    if (typedNum == 5)
                    {
                        Console.WriteLine("Write new source: ");
                        string newSource = Console.ReadLine();

                        foreach (var x in editTopic)
                        {
                            x.Source = newSource;
                        }

                        try
                        {
                            ld.SaveChanges();
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e);
                        }

                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new source is: " + newSource);
                    }

                    if (typedNum == 6)
                    {
                        Console.WriteLine("Change the starting date: ");
                        DateTime newStartingDate = Convert.ToDateTime(Console.ReadLine());

                        foreach (var x in editTopic)
                        {
                            x.StartLearningDate = newStartingDate;
                        }

                        try
                        {
                            ld.SaveChanges();
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e);
                        }

                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new starting date is: " + newStartingDate);
                    }

                    if (typedNum == 7)
                    {
                        Console.WriteLine("Change the ending date: ");
                        DateTime newEndDate = Convert.ToDateTime(Console.ReadLine());

                        foreach (var x in editTopic)
                        {
                            x.CompletionDate = newEndDate;
                        }

                        try
                        {
                            ld.SaveChanges();
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e);
                        }

                        Console.WriteLine("CHANGE COMPLETED!");
                        Console.WriteLine("Your new end date is: " + newEndDate);
                    }

                    ld.SaveChanges();
                }
            }
        }




        //Poista topic
        public static async Task DeleteTopic(string mainMenuAnswer)
        {
            using (LearningDiaryContext ld = new LearningDiaryContext())
            {
                if (mainMenuAnswer.ToLower() == "d")
                {
                    Console.WriteLine("Write ID number that you want to delete: ");
                    int deleteAnswer = int.Parse(Console.ReadLine());

                    var showDeleteTopic = ld.Topics.Where(x => x.Id == deleteAnswer);
                    foreach (var item in showDeleteTopic)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("Do you want to delete this topic? Type yes or no: ");
                    string delete = Console.ReadLine();

                    var deleteTopic = await Task.Run(() => ld.Topics.FirstOrDefault(x => x.Id == deleteAnswer));
                    if (delete.ToLower() == "yes")
                    {
                        ld.Topics.Remove(deleteTopic);
                    }
                }

                ld.SaveChanges();
            }
                
        }





        //Näytä topic haetulla ID numerolla
        public static async Task ShowWithId(string mainMenuAnswer)
        {
            using (LearningDiaryContext ld = new LearningDiaryContext())
            {
                if (mainMenuAnswer.ToLower() == "b")
                {
                    Console.WriteLine("Write the ID number: ");
                    int searchIdNum = int.Parse(Console.ReadLine());
                 
                    var showTopic = await Task.Run(()=> ld.Topics.Where(x => x.Id == searchIdNum));

                    foreach (var item in showTopic)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

    }
}
