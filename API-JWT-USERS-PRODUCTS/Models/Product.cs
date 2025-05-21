using System;
using System.Collections.Generic;

namespace API_JWT_USERS_PRODUCTS.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Marca { get; set; }

    public decimal? Price { get; set; }
}
