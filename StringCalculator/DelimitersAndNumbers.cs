namespace StringCalculator
{
    public class DelimitersAndNumbers
    {
        public DelimitersAndNumbers(string delimiters, string numbers)
        {
            Delimiters = delimiters.ToCharArray();
            Numbers = numbers;
        }

        public char [] Delimiters { get; set; }

        public string Numbers { get; set; }
    }
}
