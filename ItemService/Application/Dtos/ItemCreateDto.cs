using System.ComponentModel.DataAnnotations;

namespace ItemService.Application.Dtos;

public class ItemCreateDto
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public double Preco { get; set; }
}