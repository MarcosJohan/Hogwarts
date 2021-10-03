using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Models
{
    public class Solicitud
    {
        [Required]
        [StringLength(20,ErrorMessage = "El nombre es muy largo")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El Apellido es muy largo")]
        public string Apellido { get; set; }

        [Required]
        [Range(1,9999999999, ErrorMessage = "El identificador solo puede tener 10 digitos")]
        public long Identificador { get; set; }

        [Required]
        [Range(1,99, ErrorMessage ="La edad sale del rango")]
        public int Edad { get; set; }

        [Required]
        [Seleccion(ErrorMessage ="Escoja una casa valida")]
        public string Casa { get; set; }
        
    }

    #region Validacion
    
    public class SeleccionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string casa = (string)value;
            List<string> casas = new List<string> { "Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin" };
            
            var busqueda = casas.Where(d => d == casa).FirstOrDefault();

            return busqueda != null;
        }
    }

    #endregion
}
