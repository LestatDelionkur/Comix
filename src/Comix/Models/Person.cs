using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Comix.Models
{
    public class Person : Entity
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        public virtual ICollection<ComicsPerson> ComicsPersons { get; set; }

    }
}