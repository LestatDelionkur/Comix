using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comix.Models
{
    public class Comics:ExtendedEntity
    {
        public long ComicKindId { get; set; }
        public ComicsKind ComicsKind { get; set; }
        public ComicsType ComicsType { get; set; }
        public long? ParentComicsId { get; set; }
        public Comics ParentComics { get; set; }
        public List<ComicsPerson> ComicsPersons { get; set; } 
        public virtual ICollection<Comics> Comicses { get; set; } 
        public virtual ICollection<ComicsPage> ComicsPages { get; set; } 
    }

   public enum ComicsType {Com,Vol,Chap }




}
