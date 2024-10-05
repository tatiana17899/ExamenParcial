using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ExamenParcial.Models
{
    [Table("t_remesa")]
    public class Remesa
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public long Id { get; set; }
      public string? Remitente { get; set; }
      public string? Destinatario { get; set; }
      public string? PaisOrigen { get; set; }
      public string? PaisDestino { get; set; }
      public decimal? MontoEnviado { get; set; } 
      public string? Moneda { get; set; }
      public decimal? TasaCambio { get; set; } 
      public decimal? MontoRecibido { get; set; }
      public string? EstadoTransaccion { get; set; }
      public DateTime FechaTransaccion { get; set; }
      public string? UsuarioID { get; set; }
      [ForeignKey("UsuarioID")]
      public virtual IdentityUser? Usuario { get; set; }

    }
}