using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace razorPages.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }

        [Column(TypeName = "ntext")]
        public string? Content { get; set; }
    }
}