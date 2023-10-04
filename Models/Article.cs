using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [StringLength(255, MinimumLength = 5, ErrorMessage = "{0} phải dài từ 5 255 kí tự")]
        [Required(ErrorMessage = "{0} phải nhập")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Tiêu Đề")]
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Ngày tạo")]
        [Required(ErrorMessage = "{0} phải nhập")]
        public DateTime? Created { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Nội dung")]
        public string? Content { get; set; }
    }
}