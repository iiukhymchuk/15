namespace Model
{
    public class Board
    {
        private int size;
        public static Board Singleton { get; set; } = new Board();

        private int[,] self;

        private Board() { }

        public int this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= size) return -1;
                if (y < 0 || y >= size) return -1;
                return self[x, y];
            }
            set
            {
                if (x < 0 || x >= size) return;
                if (y < 0 || y >= size) return;
                self[x, y] = value;
            }
        }

        public void SetSize(int size)
        {
            this.size = size;
            self = new int[size, size];
        }
    }
}