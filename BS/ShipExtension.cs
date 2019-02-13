using System;

namespace BS
{
    /// <summary>
    /// Get Ship Cell value
    /// </summary>
    public static class ShipExtension
    {
        public static Cell ToCell(this Ship ship)
        {
            Enum.TryParse(ship.Type.ToString(), out Cell cell); // DH: loses error
            return cell;
        }
    }
}