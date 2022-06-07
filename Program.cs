using System;
using System.Collections.Generic;

namespace LearningDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isLearning = true;
            bool newTopic = true;
            UserInputs userInputs = new UserInputs();
            var inputsList = new List<string>();

            do
            {
                //Kommentti
                Console.Write("Write the title: ");
                string title = Console.ReadLine();
                userInputs.TheTitle = title;

                Console.Write("Write the description: ");
                string description = Console.ReadLine();
                userInputs.TheDescription = description;


                Console.Write("How much time do you think you gonna spend: ");
                double usedTime = double.Parse(Console.ReadLine());
                userInputs.TheUsedTime = usedTime;

                Console.Write("What source do you use: ");
                string source = Console.ReadLine();
                userInputs.TheSource = source;

                //Console.Write("Write the date you started learning: ");
                //DateTime startingDate = new DateTime();

                Console.Write("Is your learning progress still going? Type yes or no: ");
                string isGoing = Console.ReadLine();
                userInputs.TheIsGoing = isGoing;

                if(isGoing.ToLower() == "yes")
                {
                    Console.WriteLine("Learning still going");
                }
                else
                {
                    isLearning = false;
                }

                inputsList.Add(
                    userInputs.TheTitle + 
                    userInputs.TheDescription + 
                    userInputs.TheUsedTime +
                    userInputs.TheSource
                    );


                Console.Write("Do you want to add another topic? Type yes or no: ");
                string addAnswer = Console.ReadLine();

                //string[] inputsToArray = inputsList.ToArray();

                if(addAnswer == "no")
                {
                    for (int i = 0; i < inputsList.Count; i++)
                    {
                        Console.WriteLine(i);
                    }
                    newTopic = false;
                }

            } while (newTopic);
            

            Console.WriteLine("{0} {1} {2} {3} {4}",
                userInputs.TheTitle,
                userInputs.TheDescription,
                userInputs.TheUsedTime,
                userInputs.TheSource,
                userInputs.TheIsGoing
                );
        }
    }
    class UserInputs
    {
        public string TheTitle { get; set; }
        public string TheDescription { get; set; }
        public double TheUsedTime { get; set; }
        public string TheSource { get; set; }
        public string TheIsGoing { get; set; }
        
    }
}
