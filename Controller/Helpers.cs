namespace Controller
{
    static class Helpers
    {
        internal static int CoordsToIndex(int x, int y, int size)
        {
            return y * size + x;
        }


    }
}