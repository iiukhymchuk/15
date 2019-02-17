namespace Controller
{
    public class Game
    {
        private readonly int size;
        private readonly int[,] map;
        private int spaceX;
        private int spaceY;

        public Game(int size)
        {
            if (size < 2) size = 2;
            if (size > 5) size = 5;
            this.size = size;
            spaceX = spaceY = size - 1;

            map = new int[size, size];
        }

        public void Start()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    map[x, y] = Helpers.CoordsToIndex(x, y, size);
                }

            map[spaceX, spaceY] = 0;
        }

        public int GetNumber(int index)
        {
            var (x, y) = Helpers.IndexToCoords(index, size);

            if (x < 0 || x >= size) return -1;
            if (y < 0 || y >= size) return -1;

            return map[x, y];
        }
    }
}