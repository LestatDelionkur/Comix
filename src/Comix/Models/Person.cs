using System.Collections.Generic;

namespace Comix.Models
{
    public class Person:ExtendedEntity
    {
        public virtual ICollection<ComicsPerson> ComicsPersons { get; set; } 
         
    }
}