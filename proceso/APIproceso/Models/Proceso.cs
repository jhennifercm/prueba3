using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIproceso.Models
{
    public class Proceso
    {
        public enum TipoArea  
        {
            Recepcion,
            Produccion,
            Envios
        }

        [Key]
        public int ProcesoId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Encargado { get; set; }

        [Required]
        public decimal Monto { get; set; }

        public TipoArea Area { get; set; }

    }
}