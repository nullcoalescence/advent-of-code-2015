namespace advent_of_code_2015.Days
{
    internal class Day1 : IDay
    {
        public void Run()
        {
            var fileContent = File.ReadAllText(@"Input/day_1.txt");
            var contents = fileContent.ToCharArray();

            int floor = 0;
            int basementIndex = -1;

            for (int i = 0; i < contents.Length; i++)
            {
                if (contents[i].Equals('('))
                {
                    floor++;
                }
                else if (contents[i].Equals(')'))
                {
                    floor--;
                }
                else
                {
                    throw new InvalidDataException();
                }

                // Part 2: check if we are on basement
                if (floor == -1 && basementIndex == -1)
                {
                    basementIndex = i + 1;
                }
            }

            Console.WriteLine($"Part 1: End floor: {floor}");
            Console.WriteLine($"Part 2: Position of character where basement (-1) entered: {basementIndex}");
        }
    }
}