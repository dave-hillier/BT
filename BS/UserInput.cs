using System;

namespace BS
{
    public class UserInput : IPlayerInput
    {
        public Coordinates GetCoordinates()
        {
            Log.Output(
                "Please Enter a coordinates using letters for rows and number for columns, ex: A5 (A for row and 5 for column)");
            while (true)
            {
                var input = Console.ReadLine();
                var x = -1;
                var y = -1;
                if (input.Length != 2)
                {
                    Log.Error("Invalid input, Please try again");
                    continue;
                }

                x = RowLabels.GetLabelIndex(input[0].ToString().ToUpper()); // DH: index not checked

                if (!int.TryParse(input[1].ToString(), out y))
                {
                    Log.Error("Invalid Column vale, Please try again");
                    continue;
                }

                return new Coordinates(x, y);
            }
        }

        public Orientation GetDirection()
        {
            Log.Output("To which orientation: [Hh] for horizontal, and [Vv] vertical of the grid)");
            while (true)
            {
                var orientation = Console.ReadLine();
                switch (orientation.ToLower())
                {
                    case "h":
                        return Orientation.Horizontal;
                    case "v":
                        return Orientation.Vertical;
                }

                Log.Error("Invalid Horizontal/Vertical orientation, Please try again");
            }
        }
    }
}