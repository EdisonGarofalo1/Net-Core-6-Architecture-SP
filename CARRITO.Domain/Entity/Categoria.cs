using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARRITO.Domain.Entity
{
    public class Categoria
    {

        [Key]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }
        public int Activo { get; set; }
    }
}
