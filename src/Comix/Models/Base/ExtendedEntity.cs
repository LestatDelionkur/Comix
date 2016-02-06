using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Entity.Metadata.Internal;

namespace Comix.Models
{
    public class ExtendedEntity:Entity
    {
        [Display(Name = "Наименование")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Последнее изменение")]
        public DateTime Edited { get; set; }

    }
}