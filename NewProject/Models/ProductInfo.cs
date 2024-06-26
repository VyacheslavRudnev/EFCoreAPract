﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Models;

public class ProductInfo
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public override string ToString()
    {
        return $"{Description} | {Quantity}";
    }
}

