using System.ComponentModel.DataAnnotations;

namespace RestauranteService.Application.Dtos
{
    public class RestauranteCreateDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Site { get; set; }
    }
}