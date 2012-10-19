using System.Linq;


namespace StringCalculator
{
    public class DelimitersAndNumbers
    {
        public DelimitersAndNumbers(string delimiters, string numbers)
        {
            Delimiters = delimiters.Select(s => s.ToString()).ToArray();
            Numbers = numbers;
        }

        public string[] Delimiters { get; set; }

        public string Numbers { get; set; }
    }
}
