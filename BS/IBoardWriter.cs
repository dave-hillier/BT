namespace BS
{

    public interface IBoardWriter // DH: investigate this interface - Naming convention - what does this actually do? Write to Console?
    {
        void WriteBoard(IBoard board);
    }
}