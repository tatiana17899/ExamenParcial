using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenParcial.Models
{
    [Table("t_conversion")]
    public class Conversiones
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public long Id { get; set; }
      public string? MonedaOrigen { get; set; }
      public string? MonedaDestino { get; set; }
      public decimal? TasaCambio { get; set; }
      public DateTime Fecha { get; set; } 
    }
}