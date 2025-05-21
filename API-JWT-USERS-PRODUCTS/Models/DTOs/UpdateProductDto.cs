using System.ComponentModel.DataAnnotations;

namespace API_JWT_USERS_PRODUCTS.Models.DTOs
{
    public class UpdateProductDto
    {
        [Required(ErrorMessage = "El ID es obligatorio")]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string? Name { get; set; }

        [StringLength(50, ErrorMessage = "La marca no puede exceder 50 caracteres")]
        public string? Marca { get; set; }

        [Range(0.01, 1000000, ErrorMessage = "El precio debe estar entre 0.01 y 1,000,000")]
        public decimal? Price { get; set; }
    }
}
