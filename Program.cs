using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13ESZFirstHomeDissertation
{
    class Program
    {
        static List<int> sixtyFiveS = new List<int>();
        static int sixtyFiveIndex = -1;
        static int salaryIndex = -1;
        static List<int> numbersWithHundreds = new List<int>();
        static void Main(string[] args)
        {
            SixtyFiveS();
            int[] arr = new int[100];
            Random x = new Random();
            int counter = 0;
            int arrSum = 0;
            int[] avgBetween4T5T = new int[2];
            int beginnWithThree = 0;
            bool myBirthDayIsInIt = false;

            while(counter < 100)
            {
                int ranNumber = x.Next(1000, 10000);
                if (ranNumber % 5 == 0)
                {
                    arr[counter] = ranNumber;
                    Console.Write($"{arr[counter]}; ");
                    if ((counter+1) % 7 == 6) { Console.ForegroundColor = ConsoleColor.Green; } else { Console.ForegroundColor = ConsoleColor.White; }
                    if ((counter+1) % 10 == 0) { Console.WriteLine();}
                    arrSum += arr[counter];
                    if (arr[counter] >= 4000 && arr[counter] < 5000) { avgBetween4T5T[0] += arr[counter]; avgBetween4T5T[1]++; };
                    if (sixtyFiveIndex < 0) { FindSixtyFive(counter,arr[counter]); }
                    if ((arr[counter].ToString())[0].ToString() == "3") { beginnWithThree++; }
                    if (salaryIndex < 0 && arr[counter] >= 1800) { salaryIndex = counter; }
                    if (arr[counter] % 100 == 0) { numbersWithHundreds.Add(arr[counter]); }
                    if (!myBirthDayIsInIt) { myBirthDayIsInIt = arr[counter] == 1980; }

                    counter++;
                }
            }  
            Console.WriteLine();
            Console.WriteLine($"A tömb elemeinek összege {arrSum}.");
            Console.WriteLine($"A 4000-nél nem kissebb és az 5000-nél kissebb elemek átlaga {avgBetween4T5T[0]/avgBetween4T5T[1]}.");
            Console.WriteLine($"A tömbben {(sixtyFiveIndex > -1? "található oylan szám ami 65-nek a többszöröse.":"nem található olyan szám ami 65-nek a többszöröse.")}" +
                $" Az index így: {sixtyFiveIndex}, a szám: {(sixtyFiveIndex > -1? arr[sixtyFiveIndex]:-1)}.");
            Console.WriteLine($"A tömbben {beginnWithThree} darab 3-as számmal kezdődő szám van.");
            Console.WriteLine($"Véleményem szerint az elfogadható junior órabér {arr[salaryIndex]} Forint.");
            Console.WriteLine($"A következő számok tartalmaztak százasokat:");
            PrintHundredList();
            Console.WriteLine($"A születési évem öttel osztható változata {(myBirthDayIsInIt?"szerepel":"nem szerepel")} a tömbben.");

            Console.ReadKey();
        }

        static void PrintHundredList()
        {
            for(int i = 0; i < numbersWithHundreds.Count; i++)
            {
                if (numbersWithHundreds[i].ToString()[0] == numbersWithHundreds[i].ToString()[1]) { Console.BackgroundColor = ConsoleColor.Red; }
                else { Console.BackgroundColor = ConsoleColor.Black; }
                Console.Write($"{numbersWithHundreds[i]}; ");
            }
            Console.WriteLine();
        }

        static void FindSixtyFive(int actualIndex, int number)
        {
            for(int i = 0; i < sixtyFiveS.Count; i++)
            {
                if (number == sixtyFiveS[i]) { sixtyFiveIndex = actualIndex; i = sixtyFiveS.Count; }
            }
        }

        static void SixtyFiveS()
        {
            int number = 0;
            int startNumber = 62;
            int increaseNumber = 65;

            while(number < 4935)
            {
                number = startNumber * increaseNumber;
                sixtyFiveS.Add(number);
                startNumber++;
            }
        }
    }
}
