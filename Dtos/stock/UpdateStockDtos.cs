using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos.stock
{
    public class UpdateStockDtos
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cant be more than 10 Character")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "Company Name cant be more than 10 Character")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 100000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Industry cant be more than 10 Character")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(100000, 50000000)] public decimal IndustryPrice { get;}
        public long MarketCap { get; set; }
    }
}