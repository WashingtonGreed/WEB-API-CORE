using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_CORE.Models
{
  public class PRODUTO
  {
    [Key]

    public int ID {get; set;}

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(60, ErrorMessage="Este campo deve conter no minimo 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage="Este campo deve conter no minimo 3 e 60 caracteres")]
    public string NOME {get;set;}

    [MaxLength(1024, ErrorMessage="Este campo deve conter no minimo 3 e 60 caracteres")]
    public string DESCRICAO {get;set;}

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range (0,int.MaxValue, ErrorMessage="Insira um valor no preço")]

    [Column(TypeName = "decimal(18,4)")]
    public decimal PRECO {get; set;}
    public CATEGORIA CATEGORIA {get; set;}
    public string EXCLUIDO { get; set; }

    }
}