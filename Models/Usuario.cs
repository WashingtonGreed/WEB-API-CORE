using System.ComponentModel.DataAnnotations;
using WEB_API_CORE.Models;

namespace WEB_API_CORE.Models
{
  public class USUARIO
  {
    [Key]
    public int ID {get; set;}

    [Required(ErrorMessage = "Este NOME_SOBRENOME é obrigatório")]
    [MaxLength(60, ErrorMessage="Este campo deve conter no minimo 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage="Este campo deve conter no minimo 3 e 60 caracteres")]
    public string NOME_SOBRENOME {get;set;}

    [Required(ErrorMessage = "Este CPF_CNPJ é obrigatório")]
    [MaxLength(14, ErrorMessage = "Este campo deve conter no minimo 3 e 60 caracteres")]
    [MinLength(11, ErrorMessage = "Este campo deve conter no minimo 3 e 60 caracteres")]
    public string CPF_CNPJ { get; set; }

    [Required(ErrorMessage = "Este EMAIL é obrigatório")]
    [MaxLength(60, ErrorMessage="Este campo deve conter no minimo 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage="Este campo deve conter no minimo 3 e 60 caracteres")]
    public string EMAIL {get;set;}

    [Required(ErrorMessage = "Este SENHA é obrigatório")]
    [MaxLength(20, ErrorMessage="Este campo deve conter no minimo 6 e 60 caracteres")]
    [MinLength(6, ErrorMessage="Este campo deve conter no minimo 6 e 60 caracteres")]
    public string SENHA {get;set;}
    public string ACESSO {get; set;}
    public string EXCLUIDO { get; set; }


    }
}


