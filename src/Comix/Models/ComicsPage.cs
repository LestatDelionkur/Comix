namespace Comix.Models
{
    public class ComicsPage:Entity
    {
        public int Number { get; set; }
        public long ComixId { get; set; }
        public string Path { get; set; }
        public Comics Comics { get; set; }
    }
}