namespace Comix.Models
{
    public class ComicsPerson:Entity
    {
        public long ComicsId { get; set; }
        public Comics Comics { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; }
        public long PersonTypeId { get; set; }
        public PersonType PersonType { get; set; }
         
    }
}