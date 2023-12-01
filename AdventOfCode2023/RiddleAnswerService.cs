using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace AdventOfCode2023
{
    public class RiddleAnswerService
    {
        public int DayOnePartOne()
        {
            string[] inputLines = ReadInput(1);
            var digitsByLine = inputLines.Select(line =>
            {
                IEnumerable<int> digits = line.Where(char.IsDigit).Select(c => (int)char.GetNumericValue(c));
                return digits.FirstOrDefault()*10 + digits.Last();
            });

            return digitsByLine.Sum();
        }

        public int DayOnePartTwo()
        {
            string[] inputLines = ReadInput(1);
            //IEnumerable<int> digitsByLine = inputLines.Select(line =>
            //{
            //    return NewMethod(line);
                
            //});
            var digitsByLine = new List<int>();
            foreach (var line in inputLines)
            {
                digitsByLine.Add(NewMethod(line));
            }
            return digitsByLine.Sum();
        }

        private static int NewMethod(string line)
        {
            Dictionary<int, int> litteralDigits = new();
            foreach (string digit in Enum.GetNames<EnumDigits>())
            {
                if (line.IndexOf(digit) > -1 && Enum.TryParse(digit, out EnumDigits value))
                {
                    litteralDigits.TryAdd(line.IndexOf(digit), (int)value);
                    litteralDigits.TryAdd(line.LastIndexOf(digit), (int)value);
                }
            }
            for(int i = 0; i < line.Length; i++)
            {
                if (char.GetNumericValue(line[i]) > -1)
                    litteralDigits.TryAdd(i, (int)char.GetNumericValue(line[i]));
            };

            return litteralDigits[litteralDigits.Keys.Min()] * 10 + litteralDigits[litteralDigits.Keys.Max()];
        }

        private enum EnumDigits
        {
            one = 1,
            two = 2, 
            three = 3,
            four = 4, 
            five = 5, 
            six = 6, 
            seven = 7,
            eight = 8,
            nine = 9,
        }

        private static string[] ReadInput(int day)
        {
            return File.ReadAllLines($"inputs/input{day}.txt");
        }
    }
}
