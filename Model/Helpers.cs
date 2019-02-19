namespace Model
{
    public class Helpers
    {
        public static (int, int) IndexToCoords(int index, int size)
        {
            var x = index % size;
            var y = index / size;
            return (x, y);
        }

        public static int CoordsToIndex(int x, int y, int size)
        {
            return y * size + x;
        }
    }
}