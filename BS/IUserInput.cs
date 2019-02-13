namespace BS
{
    public interface IPlayerInput // DH: From the interface it not clear what this is going to do - consider name read
    {
        Coordinates ReadCoordinates();

        Orientation ReadDirection();
    }
}