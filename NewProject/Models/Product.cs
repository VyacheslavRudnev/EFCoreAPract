using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string ProductName { get; set; }

    [Required]
    public int ProductPrice { get; set; }
    public ProductInfo ProductInfo { get; set; }
}
