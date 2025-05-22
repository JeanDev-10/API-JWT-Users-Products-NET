using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace API_JWT_USERS_PRODUCTS.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Marca { get; set; }

    public decimal? Price { get; set; }
     // Clave foránea para User
    public int UserId { get; set; }
    
    // Propiedad de navegación
    [JsonIgnore] // Opcional: Evitar referencia circular
    public User User { get; set; }
}
