using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestProject.Models;

public partial class Category
{
    [Key]
    public int Id { get; set; }

    public string? CategoryName { get; set; }
}
