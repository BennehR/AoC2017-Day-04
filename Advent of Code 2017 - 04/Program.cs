using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Advent_of_Code_2017___04
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Setup////
            string[] input = File.ReadAllLines(@"C:\Users\ben.rendall\Drive Documents\Visual Studio\Projects\Advent of Code 2017\Day 04\input.txt");

            int validPhrases = 0;
            int phraseCount = 0;
            char inputSpace = ' ';
            Dictionary<string, int> phraseLib = new Dictionary<string, int>();
            List<string> validPhrasesList = new List<string>();

            ////Section 1////

            for(int i = 0; i < input.Count(); i++)
            {
                string[] inputSplit = input[i].Split(inputSpace);

                for (int j = 0; j < inputSplit.Count(); j++)
                {
                    try
                    {
                        phraseLib.Add(inputSplit[j], 1);
                    }
                    catch
                    {
                        phraseLib[inputSplit[j]] += 1;
                    }
                }

                foreach(var item in phraseLib)
                {
                    if(item.Value == 1)
                    {
                        phraseCount++;
                    }
                }

                if(phraseCount == inputSplit.Count())
                {
                    validPhrasesList.Add(input[i]);
                    validPhrases++;
                }

                phraseLib.Clear();
                phraseCount = 0;
            }

            Console.WriteLine(string.Format("Section 1 - Number of valid passphrases: {0}", validPhrases));

            ////Section 2////

            //Create a new array from the valid array list
            //Reset validPhrases int and clear the phraseLib library
            string[] validArray = validPhrasesList.ToArray();
            validPhrases = 0;
            phraseLib.Clear();

            for (int i = 0; i < validArray.Count(); i++)
            {
                //Split the valid array into segments the same as Section 1
                string[] validSplit = validArray[i].Split(inputSpace);

                //Loop through each split item and re-arrange its contents into alphabetical order
                for (int j = 0; j < validSplit.Count(); j++)
                {
                    string splitUnform = validSplit[j];
                    char[] splitChars = validSplit[j].ToArray();
                    Array.Sort(splitChars);
                    string splitFormatted = new string(splitChars);
                    Console.WriteLine("{0} => {1}", splitUnform, splitFormatted);
                    validSplit[j] = splitFormatted;
                }

                //Sort the split array alphabetically
                Array.Sort(validSplit);

                //Loop through the split array and try add the items to the phrase library, if it already exists then increment its int value by 1
                for(int k = 0; k < validSplit.Count(); k++)
                {
                    try
                    {
                        phraseLib.Add(validSplit[k], 1);
                    }
                    catch
                    {
                        phraseLib[validSplit[k]] += 1;
                    }
                }

                //Loop through the phrase library and compare int values
                foreach (var item in phraseLib)
                {
                    if (item.Value == 1)
                    {
                        phraseCount++;
                    }
                }

                //Compare the phraseCount to how many items are in the split array
                //If the two do not match, a duplicate was found and the phrase is invalid
                if (phraseCount == validSplit.Count())
                {
                    validPhrases++;
                }

                phraseLib.Clear();
                phraseCount = 0;
            }

            Console.WriteLine(string.Format("Section 2 - Number of valid passphrases: {0}", validPhrases));

            Console.ReadKey();
        }
    }
}
