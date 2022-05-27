using System.ComponentModel.DataAnnotations;

namespace mvc_dio.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Range(1, 100, ErrorMessage = "Limite de cadastro até 100.")]
        public int Quantidade { get; set; }
        

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
