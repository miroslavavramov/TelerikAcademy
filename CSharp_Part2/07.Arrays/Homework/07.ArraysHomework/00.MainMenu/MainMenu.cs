using System;
using System.Threading;

    class Program
    {
        static void Main()
        {
            Console.Title = "07.Arrays Homework";
            Console.BufferWidth = Console.WindowWidth = 105;
            Console.BufferHeight = Console.WindowHeight = 41;
            Console.SetCursorPosition(45, 15);
            Console.WriteLine("HOLA !");
            Thread.Sleep(1800);

        navigate:
            Console.Clear();
            Console.BufferHeight = Console.WindowHeight;
            ContentsPart1();
            while (true)
            {
                Console.CursorVisible = false;
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        Console.Clear();
                        ContentsPart2();
                    }
                    else if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        Console.Clear();
                        ContentsPart1();
                    }
                    else if(pressedKey.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
            //choose task
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(1, 34);
                Console.Write("Type task number from \"1\" to \"21\" and press ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("<ENTER>");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(" execute it,\n type");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" \"back\" ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("to go to Main Menu or ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\"exit\" ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("to close the program. ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string input = Console.ReadLine();
                Console.ResetColor();
                switch (input)
                {
                    default: 
                        goto navigate;
                    case "back":
                        goto navigate;
                    case "exit":
                        Exit();
                        break;
                    case "1": Console.Clear();
                        PrintArray.Main();
                        break;
                    case "2": Console.Clear();
                        EqualArrays.Main();
                        break;
                    case "3": Console.Clear();
                        CompareCharArrays.Main();
                        break;
                    case "4": Console.Clear();
                        MaxSeqOfConsElements.Main();
                        break;
                    case "5": Console.Clear();
                        MaxIncreasingSeq.Main();
                        break;
                    case "6": Console.Clear();
                        MaxSumOfElements.Main();
                        break;
                    case "7": Console.Clear();
                        SelectionSort.Main();
                        break;
                    case "8": Console.Clear();
                        MaxSumOfSeq.Main();
                        break;
                    case "9": Console.Clear();
                        MostFrequentNumber.Main();
                        break;
                    case "10": Console.Clear();
                        FindSumInArray.Main();
                        break;
                    case "11": Console.Clear();
                        BinarySearch.Main();
                        break;
                    case "12": Console.Clear();
                        ArrayOfLetters.Main();
                        break;
                    case "13": Console.Clear();
                        MergeSortAlgorithm.Main();
                        break;
                    case "14": Console.Clear();
                        QuickSortAlgorithm.Main();
                        break;
                    case "15": Console.Clear();
                        SieveOfErathosthenesAlgorithm.Main();
                        break;
                    case "16": Console.Clear();
                        CheckSubsetSum.Main();
                        break;
                    case "17": Console.Clear();
                        CheckSpecificSubsetSum.Main();
                        break;
                    case "18": Console.Clear();
                        SortByRemoving.Main();
                        break;
                    case "19": Console.Clear();
                        PrintAllPermutations.Main();
                        break;
                    case "20": Console.Clear();
                        PrintAllVariations.Main();
                        break;
                    case "21": Console.Clear();
                        PrintAllCombinations.Main();
                        break;
                }
            }
            
        }
        static void ContentsPart1()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n Homework 07.Arrays\n\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"   
       Task 1:  Write a program that allocates array of 20 integers and initializes
                each element by its index multiplied by 5. Print the obtained array 
                on the console.
       Task 2:  Write a program that reads two arrays from the console and compares
                them element by element.
       Task 3:  Write a program that compares two char arrays lexicographically 
                (letter by letter).
       Task 4:  Write a program that finds the maximal sequence of equal elements in an array.
                Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.
       Task 5:  Write a program that finds the maximal increasing sequence in an array. 
                Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
       Task 6:  Write a program that reads two integer numbers N and K and an array of 
                N elements from the console. Find in the array those K elements that 
                have maximal sum.
       Task 7:  Write a program to sort an array. Use the ""selection sort"" algorithm: 
                Find the smallest element, move it at the first position, find the smallest
                from the rest, move it at the second position, etc.
       Task 8:  Write a program that finds the sequence of maximal sum in given array. 
                Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
       Task 9:  Write a program that finds the most frequent number in an array. 
	            Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times) 
       Task 10: Write a program that finds in given array of integers a sequence of 
                given sum S (if present).
                Example: {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}
       Task 11: Write a program that finds the index of given element in a sorted array of 
                integers by using the binary search algorithm (find it in Wikipedia).
       Task 12: Write a program that creates an array containing all letters from the alphabet(A-Z). 
                Read a word from the console and print the index of each of its letters in the array.
                ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(0, 37);
            Console.WriteLine(" Use arrows to navigate through the pages.");
            Console.Write(" Press ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("<ENTER>");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" to begin typing.");
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.Write(" <ESC>");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            //Console.Write(" to go back.");
            Console.SetCursorPosition(90, 37);
            Console.WriteLine("Page 1/2");
            Console.SetCursorPosition(35, 38);
        }
        static void ContentsPart2()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n Homework 07.Arrays\n\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"
       Task 13: * Write a program that sorts an array of integers using the merge sort 
                 algorithm (find it in Wikipedia).
       Task 14: Write a program that sorts an array of strings using the quick sort
                 algorithm (find it in Wikipedia).
       Task 15: Write a program that finds all prime numbers in the range [1...10 000 000]. 
                 Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
       Task 16: * We are given an array of integers and a number S. Write a program to find
                 if there exists a subset of the elements of the array that has a sum S. 
                 Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)
       Task 17: * Write a program that reads three integer numbers N, K and S and an array 
                 of N elements from the console. Find in the array a subset of K elements that
                 have sum S or indicate about its absence.
       Task 18: * Write a program that reads an array of integers and removes from it a minimal
                 number of elements in such way that the remaining array is sorted in increasing
                 order. Print the remaining sorted array. 
                 Example: {6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}
       Task 19: * Write a program that reads a number N and generates and prints all the 
                 permutations of the numbers [1 … N]. 
                 Example: n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
       Task 20: Write a program that reads two numbers N and K and generates all the variations
                 of K elements from the set [1..N]. Example:
	             N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, 
                 {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
       Task 21: Write a program that reads two numbers N and K and generates all the combinations
                 of K distinct elements from the set [1..N]. Example:
	             N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, 
                 {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
            ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(0, 37);
            Console.WriteLine(" Use arrows to navigate through the pages.");
            Console.Write(" Press ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("<ENTER>");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" to begin typing.");
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.Write(" <ESC>");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            //Console.Write(" to go back.");
            Console.SetCursorPosition(90, 37);
            Console.WriteLine("Page 2/2");
        }
        static void Exit()
        {
            Console.Clear();
            Console.SetCursorPosition(45, 15);
            Console.ResetColor();
            Console.WriteLine("Au Revuir!");
            //Console.WriteLine("(Място за вашата реклама.)");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
        
    }

