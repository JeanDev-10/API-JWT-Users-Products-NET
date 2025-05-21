using System.ComponentModel.DataAnnotations;

namespace API_JWT_USERS_PRODUCTS.Models.DTOs
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        [StringLength(50, ErrorMessage = "La marca no puede exceder 50 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 1000000, ErrorMessage = "El precio debe estar entre 0.01 y 1,000,000")]
        public decimal Price { get; set; }
    }
}
