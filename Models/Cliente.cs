using System.ComponentModel.DataAnnotations;

namespace WEB_API_CORE.Models
{
  public class CLIENTE
  {
    [Key]
    public int ID {get; set;}

    [Required(ErrorMessage = "Este campo CODIGO é obrigatório")]
    public int CODIGO {get; set;}

    [Required(ErrorMessage = "Este CPF_CNPJ é obrigatório")]
    [MaxLength(14, ErrorMessage = "Este campo deve conter no minimo 3 e 60 caracteres")]
    [MinLength(11, ErrorMessage = "Este campo deve conter no minimo 3 e 60 caracteres")]
    public string CPF_CNPJ { get; set; }

    [MaxLength(60, ErrorMessage = "Este campo deve conter no minimo 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter no minimo 3 e 60 caracteres")]
    public string EMAIL { get; set; }

    [Required(ErrorMessage = "Este campo NOME é obrigatório")]
    [MaxLength(60, ErrorMessage="Este campo deve conter no minimo 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage="Este campo deve conter no minimo 3 e 60 caracteres")]
    public string NOME {get;set;}
    public string EXCLUIDO { get; set; }

    }
}