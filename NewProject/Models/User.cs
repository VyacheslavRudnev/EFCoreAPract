using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(32)]
    public string Name { get; set; }

    [Required]
    [StringLength(64)]
    public string LastName { get; set; }
    public int Amount { get; set; }

    [Required]
    public Role UserRole { get; set; }
    public List<Product> Products { get; set; }

    public enum Role 
    {
        Customer,
        Seller
    }
}
