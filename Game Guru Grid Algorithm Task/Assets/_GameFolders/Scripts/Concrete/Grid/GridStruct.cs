namespace GameGuruGridTask.Grids
{
    public struct GridStruct
    {
        public int X { get;private set; }
        public int Y { get;private set; }

        public GridStruct(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
    
}
