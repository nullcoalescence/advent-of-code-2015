namespace advent_of_code_2015.Days
{
    internal class Day3 : IDay
    {
        public void Run()
        {
            var fileContents = File.ReadAllText(@"Input/day_3.txt");

            // Part 1:
            var contents = fileContents.ToCharArray();

            var startingCoordinates = new Coordinates { X = 0, Y = 0 };
            List<Coordinates> visitedCoordinates = new List<Coordinates> { new Coordinates { X = startingCoordinates.X, Y = startingCoordinates.Y } };

            var currentCoordinates = startingCoordinates;

            int housesThatRecievedAtLeastOnePresent = 1;
            foreach (var item in contents)
            {
                // parse new instruction and update coordinates
                if (item == Positions.RIGHT)
                {
                    currentCoordinates.X++;
                }
                else if (item == Positions.LEFT)
                {
                    currentCoordinates.X--;
                }
                else if (item == Positions.UP)
                {
                    currentCoordinates.Y++;
                }
                else if (item == Positions.DOWN)
                {
                    currentCoordinates.Y--;
                }
                else
                {
                    throw new InvalidDataException();
                }

                // calculate if houses have recieved at leastn one present by checking if the coordinates are present in the list
                // if they aren't, that means we have NOT already accounted for that house in our count and need to add it.
                if (!visitedCoordinates.Contains(currentCoordinates))
                {
                    housesThatRecievedAtLeastOnePresent++;
                }

                // update visitedCoordinates
                visitedCoordinates.Add(new Coordinates { X = currentCoordinates.X, Y = currentCoordinates.Y });
            }

            Console.WriteLine($"The total amount of houses that recieved at least one present is: {housesThatRecievedAtLeastOnePresent}");

            // Part 2:
            contents = fileContents.ToCharArray();

        }


        private record Coordinates
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        private class Positions
        {
            public static char LEFT = '<';
            public static char RIGHT = '>';
            public static char UP = '^';
            public static char DOWN = 'v';
        }

    }
}
