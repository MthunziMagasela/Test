using System;
using System.Linq;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            StringCalculator st = new StringCalculator();
            int total = st.Add("1,2,3");
            Console.WriteLine("Total " + total);
            Console.ReadKey();
        }
    }

    public class StringCalculator
    {
        private const string DEFAULT_DELIMITER = ",";

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiter = DEFAULT_DELIMITER;
            var indexOfDelimiterDefinition = numbers.IndexOf("//");
            if (indexOfDelimiterDefinition == 0)
            {
                var delimiterDefinitionEndIndex = numbers.IndexOf("\n");
                var delimiterDefinition = numbers.Substring(2, delimiterDefinitionEndIndex - 2);
                delimiter = delimiterDefinition;
                numbers = numbers.Substring(delimiterDefinitionEndIndex + 1);
            }

            var numbersArray = numbers
                .Replace("\n", delimiter)
                .Split(delimiter)
                .Select(int.Parse)
                .ToArray();

            var negativeNumbers = numbersArray.Where(n => n < 0).ToArray();
            if (negativeNumbers.Any())
            {
                throw new Exception($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }

            return numbersArray.Sum();
        }
    }



}
