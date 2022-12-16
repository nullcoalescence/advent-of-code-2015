namespace advent_of_code_2015.Days
{
    internal class Day2 : IDay
    {
        public void Run()
        {
            var fileContents = File.ReadLines(@"Input/day_2.txt");

            int paperSqFt = 0;
            int ribbonFt = 0;

            foreach (var line in fileContents)
            {
                var dimensions = line.Split("x");

                var present = new RectangualarPrism
                {
                    Length = int.Parse(dimensions[0]),
                    Wdith = int.Parse(dimensions[1]),
                    Height = int.Parse(dimensions[2]),
                };

                paperSqFt += CalculateWrappingPaperNeeded(present);
                ribbonFt += CalculateRibbonLength(present);
            }

            Console.WriteLine($"The total square feet of wrapping paper needed is: {paperSqFt}");
            Console.WriteLine($"The total feet of ribbon needed is: {ribbonFt}");
        }

        private int CalculateWrappingPaperNeeded(RectangualarPrism present)
        {
            var area = (2 * present.Length * present.Wdith) 
                + (2 * present.Wdith * present.Height)
                + (2 * present.Height * present.Length);

            int[] dimensions = { present.Length, present.Wdith, present.Height };
            Array.Sort(dimensions);

            var smallestSideArea = dimensions[0] * dimensions[1];

            return (area + smallestSideArea);
        }

        private int CalculateRibbonLength(RectangualarPrism present)
        {
            int[] dimensions = { present.Length, present.Wdith, present.Height };
            Array.Sort(dimensions);

            var perimeterOfSmallestSide = (dimensions[0] * 2) + (dimensions[1] * 2);

            var volume = (present.Length * present.Wdith * present.Height);

            return (perimeterOfSmallestSide + volume);
        }

        private record RectangualarPrism
        {
            public int Length;
            public int Wdith;
            public int Height;
        }
    }
}
