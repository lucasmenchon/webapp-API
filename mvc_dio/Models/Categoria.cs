using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_dio.Models
{
    public class Categoria
    {

        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Não é possível cadastrar sem um nome.")]
        public string Descricao { get; set; }

    }
}
