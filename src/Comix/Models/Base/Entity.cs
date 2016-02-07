using System.ComponentModel.DataAnnotations;

namespace Comix.Models
{
    public class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}