using System.ComponentModel.DataAnnotations;

namespace SmartCity.API.Models;

public class Sensor
{
    public int Id { get; set; }

    [Required]
    public string Localizacao { get; set; }

    [Required]
    public string Tipo { get; set; }

    [Required]
    public double Valor { get; set; }

    public DateTime DataLeitura { get; set; } = DateTime.UtcNow;
}
