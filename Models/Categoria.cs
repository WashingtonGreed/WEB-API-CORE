using System.ComponentModel.DataAnnotations;

namespace WEB_API_CORE.Models
{
  public class CATEGORIA
  {
    [Key]
    public int ID {get; set;}

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(60, ErrorMessage="Este campo deve conter no minimo 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage="Este campo deve conter no minimo 3 e 60 caracteres")]

    public string NOME {get;set;}
    public string EXCLUIDO { get; set; }

    }
}