using System.Text;

namespace BS
{
    public class ConsoleBoardWriter : IBoardWriter // TODO: Has no state is this worthy of being a class? could be static
    {
        public void WriteBoard(IBoard board)
        {
            var output = new StringBuilder();
            output.AppendLine("  " + string.Join(' ', RowLabels.Labels.Substring(0, Board.MaxRow).ToCharArray()));
            for (var y = 0; y < board.Coordinates.GetLength(1); y++)
            {
                output.AppendLine();
                output.Append(y + " ");
                for (var x = 0; x < board.Coordinates.GetLength(0); x++)
                {
                    output.Append(board.Coordinates[x, y].GetSign());
                    output.Append(" ");
                }
            }

            Log.Write(output.ToString());
        }
    }
}