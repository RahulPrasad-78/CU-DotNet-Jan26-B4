using System;
using System.Collections.Generic;

namespace LibraryManagement.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? BookName { get; set; }

    public int? Price { get; set; }

    public int? Quantity { get; set; }

    public int? AvilableQuantity { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }
}
