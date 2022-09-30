using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatos.Modelo
{
    public class FatosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "O Id é obrigatório.")]
        public int id { get; set; }


        [Display(Name = "Fatos Chuck Norris")]
        [StringLength(5000)]
        public string FatosChuckNorris { get; set; }

        [Display(Name = "Data criação")]
        public DateTime DataCriacao { get; set; }

    }
}




