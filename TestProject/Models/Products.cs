using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestProject.Models;

public partial class Products
{
    [Key]
    public int Id { get; set; }
    public int SubCategoryId { get; set; }

    public string? ProductName { get; set; }

    public string? Clour { get; set; }
    public string? Size { get; set; }

}
