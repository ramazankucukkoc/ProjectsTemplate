namespace Core.Persistence.Paging
{
    public class BasePageableModel
    {
        public int Index { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
        public int HasPrevious { get; set; }
        public int HasNext { get; set; }
    }
}
