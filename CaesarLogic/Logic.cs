using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaesarsLogic
{
    public class Logic
    {
        private const string alphabet = "abcdefghijklmnopqrstuvwxyzæøå ";
        private readonly Dictionary<char, int> alphabetCharToPosition;
        private readonly Dictionary<int, char> alphabetPositionToChar;
        private readonly char[] _newLineChars;

        public Logic(params char[] newLineChars)
        {
            _newLineChars = newLineChars;
            var alphabetCharList = alphabet.ToCharArray().ToList();
            alphabetCharToPosition = alphabetCharList.ToDictionary(x => x, x => alphabetCharList.IndexOf(x));
            alphabetPositionToChar = alphabetCharList.ToDictionary(x => alphabetCharList.IndexOf(x), x => x);
        }

        public string GetEncryptString(int positionsToMove, string inputString)
        {
            var result = new StringBuilder();
            foreach (var inputLine in inputString.Split(_newLineChars, StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (var item in inputLine.ToCharArray())
                {
                    result.Append(GetEncryptChar(positionsToMove, item));
                }
                result.Append(Environment.NewLine);
            }
            result.Remove(result.Length - 2, 1);
            return result.ToString();
        }

        public string GetDecryptString(int positionsToMove, string inputString)
        {
            var result = new StringBuilder();
            foreach (var inputLine in inputString.Split(_newLineChars, StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (var item in inputLine.ToCharArray())
                {
                    result.Append(GetDecryptChar(positionsToMove, item));

                }
                result.Append(Environment.NewLine);
            }
            result.Remove(result.Length - 2, 1);
            return result.ToString();
        }

        private char GetEncryptChar(int positionsToMove, char inputChar)
        {
            //Go positive
            int filteredPositionsToMove = positionsToMove % alphabet.Length;

            int indexToReturn = alphabetCharToPosition[inputChar] + filteredPositionsToMove;

            if(indexToReturn >= alphabet.Length)
            {
                indexToReturn = indexToReturn - alphabet.Length;
            }

            return alphabetPositionToChar[indexToReturn];
        }

        private char GetDecryptChar(int positionsToMove, char inputChar)
        {
            //Go negative
            int filteredPositionsToMove = positionsToMove % alphabet.Length;

            int indexToReturn = alphabetCharToPosition[inputChar] - filteredPositionsToMove;

            if(indexToReturn < 0)
            {
                indexToReturn = indexToReturn + alphabet.Length;
            }

            return alphabetPositionToChar[indexToReturn];
        }
    }
}
