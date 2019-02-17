namespace Controller
{
    static class Helpers
    {
        internal static int CoordsToIndex(int x, int y, int size)
        {
            return y * size + x;
        }

        internal static (int, int) IndexToCoords(int index, int size)
        {
            var x = index % size;
            var y = index / size;
            return (x, y);
        }
    }
}