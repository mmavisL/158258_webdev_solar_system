using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace _14068570___Solar_System.Models
{
    [Table("Planet")]
    public class Planet
    {
        [Key]
        public int Id { get; set; }

        public string Body { get; set; }
        public double Radius { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}