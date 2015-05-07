using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StringGenerator
{
    class StringGen
    {
        private string charList;

        public StringGen(string charString)
        {
            //charList = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            charList = charString;
        }

        public void SetCharList(string charString)
        {
            charList = charString;
        }


        public string GenerateString(string howLong,
            string spaceEveryX, string spaceEveryY, bool isInsertSpacesOn,
            string newLineEveryX, string newLineEveryY, bool isInsertNewLinesOn)
        {
            string finalString = "";

            try
            {
                int size = int.Parse(howLong);

                var stringChars = new char[size];
                var random = new Random();
                int countChars = 0;
                int countCharsForNewLine = 0;
                int everyXYinsertSpace = random.Next(int.Parse(spaceEveryX), (int.Parse(spaceEveryY) + 1));
                int everyXYinsertNewLine = random.Next(int.Parse(newLineEveryX), (int.Parse(newLineEveryY) + 1));
                bool isInsertSpaceChecked = isInsertSpacesOn;
                bool isInsertNewLineChecked = isInsertNewLinesOn;
                bool wasLastCharALetter = false;
                for (int i = 0; i < stringChars.Length; i++)
                {
                    if (countChars >= everyXYinsertSpace && isInsertSpaceChecked && (i + 1 < stringChars.Length))
                    {
                        everyXYinsertSpace = random.Next(int.Parse(spaceEveryX), (int.Parse(spaceEveryY) + 1));
                        stringChars[i] = ' ';
                        countChars = 0;
                        countCharsForNewLine++;
                        wasLastCharALetter = false;
                    }
                    else
                    {
                        stringChars[i] = charList[random.Next(charList.Length)];
                        countChars++;
                        countCharsForNewLine++;
                        wasLastCharALetter = true;
                    }
                    if (countCharsForNewLine >= everyXYinsertNewLine && isInsertNewLineChecked && (i + 2 < stringChars.Length) && wasLastCharALetter)
                    {
                        everyXYinsertNewLine = random.Next(int.Parse(newLineEveryX), (int.Parse(newLineEveryY) + 1));
                        stringChars[i + 1] = Environment.NewLine[0];
                        stringChars[i + 2] = Environment.NewLine[1];
                        countChars = 0;
                        countCharsForNewLine = 0;
                        i += 2;
                        wasLastCharALetter = false;
                    }
                }
                finalString = new String(stringChars);
            }
            catch (Exception e)
            {
                finalString = e.Message + Environment.NewLine + Environment.NewLine + e.StackTrace;
                MessageBox.Show(finalString);
            }
            return finalString;
        }





        public string GenerateCounterString(string howLong,
            string counterStringChar)
        {
            string finalString = "";

            try
            {
                int size = int.Parse(howLong);
                int countSize = 0;
                string numberString;
                while (size > countSize)
                {
                    if ((size - countSize) == 1)
                    {
                        finalString = counterStringChar.First() + finalString;
                        break;
                    }
                    numberString = (size - countSize).ToString();
                    finalString = numberString + counterStringChar.First() + finalString;
                    countSize = finalString.Length;
                }
            }
            catch (Exception e)
            {
                finalString = e.Message + Environment.NewLine + Environment.NewLine + e.StackTrace;
                MessageBox.Show(finalString);
            }
            return finalString;
        }

    }
}
