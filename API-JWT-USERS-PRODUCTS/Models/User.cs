using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace API_JWT_USERS_PRODUCTS.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    [JsonIgnore] // No exponer la contraseña en respuestas JSON
    public string? Password { get; set; }
    // Relación 1 a muchos con Productos
    [JsonIgnore] // Opcional: Evitar referencia circular
    public ICollection<Product> Products { get; set; }
}
