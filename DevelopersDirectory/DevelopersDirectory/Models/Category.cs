using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevelopersDirectory.Models
{
    public class Category
    {
        public Category()
        {
            Developers = new List<Developer>();
        }
        public int CategoryId { get; set; }

        [StringLength(255)]
        [Index(IsUnique = true)]
        public string CategoryTitle { get; set; }

        public ICollection<Developer> Developers { get; set; }

    }
}