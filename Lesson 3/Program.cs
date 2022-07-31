using System;

namespace Lesson_3
{
    internal class Program
    {

        static void GameAnswersCheckOrScore(string select, string correct, ref int score)
        {
            if (correct == select)
            {
                score += 10;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=====True====");
            }
            else
            {
                score -= (score == 0) ? 0 : 10;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("====False====");
            }
        }



        static int getAnswer(int answerCount, string question, string[] answers)
        {
            int choice = 0;

            do
            {
                int questionNumber = 0;
                Console.WriteLine(question);

                foreach (var item in answers)
                {
                    Console.WriteLine($"{++questionNumber})  {item}");
                }

                Console.WriteLine("Enter choice: ");
                int.TryParse(Console.ReadLine(), out choice);
                Console.WriteLine("\n");


            } while (choice < 1 || choice > answerCount);
            return choice;
        }



        static void RandomMethod(string[] arr)
        {
            Random random = new Random();

            for (int i = arr.Length - 1; i > 0; --i)
            {
                int temp = random.Next(i + 1);

                string tempStr = arr[i];
                arr[i] = arr[temp];
                arr[temp] = tempStr;
            }
        }

        static void Game()
        {
            int score = 0;
            const short questionCount = 10, answerCount = 3;

            string[] questons =
            {
                "Dunyanin en boyuk adasi hansidir?",
                "Dunyanin en uzun kisinin boyu nece sm dir?",
                "Reference tiplerin default u nedir?",
                "C# necenci ilde yaranib?",
                "Hansi tip value tip deyil?",
                "Interpolation ucun hansi simvoldan istifade etmek lazimdir?",
                "C#-da Preticate-in return type-i hansidir?",
                "Erazi butovluyune gore en boyuk olke hansidir?",
                "C++ necenci ilde yaranib",
                "Wifi kim terefinden yaradilib?"
            };


            string[][] answers = new string[questionCount][]
            {
                new string[answerCount]{"Madacaskar", "Qrenlandiya", "Yeni Qvineya"},
                new string[answerCount]{"2.48 cm ", "2.51 cm", "2.74 cm"},
                new string[answerCount]{"0","null","false"},
                new string[answerCount]{"2002", "2000", "1995"},
                new string[answerCount]{"int","string","bool"},
                new string[answerCount]{"?","$","!"},
                new string[answerCount]{"void", "bool", "float"},
                new string[answerCount]{"ABS", "Rusya", "Kanada"},
                new string[answerCount]{"1978","1987","2002"},
                new string[answerCount]{"Mark Zukherberg", "Hedy Lamarr", "Linus Torvalds"},
            };


            for (int i = 0; i < questionCount; i++)
            {
                var correctAnswer = answers[i][1];
                RandomMethod(answers[i]);
                int choice = getAnswer(answerCount, questons[i], answers[i]);
                GameAnswersCheckOrScore(answers[i][choice - 1], correctAnswer, ref score);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine($"Score is: {score}");
        }

        static void Main()
        {
            Game();
        }
    }
}
