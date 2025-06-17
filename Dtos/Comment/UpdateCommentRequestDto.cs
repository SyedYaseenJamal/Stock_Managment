using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace webapi.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title Must be atleast 5 Characters")]
        [MaxLength(280, ErrorMessage = "Title cannot be over 280 Characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Content Must be atleast 5 Characters")]
        [MaxLength(280, ErrorMessage = "Content cannot be over 280 Characters")]
        public string Content { get; set; } = string.Empty;
    }
}