using System.ComponentModel.DataAnnotations;

namespace WEB_API_CORE.Models
{
  public class REMESSA
  {
    [Key]
    public int ID { get; set; }

    [Required(ErrorMessage = "Este LOTE é obrigatório")]
    public LOTE LOTE { get; set; }

    [Required(ErrorMessage = "Este B1_FILIAL é obrigatório")]
    public string B1_FILIAL { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório DATA_EMISSAO")]
    public string DATA_EMISSAO { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório B1_GRUPO")]
    public string B1_GRUPO { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório ZZJ_CODCLI")]
    public string ZZJ_CODCLI { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório ZZJ_CODPRO")]
    public string ZZJ_CODPRO { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório B1_DESC")]
    public string B1_DESC { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório B1_YMODELO")]
    public string B1_YMODELO { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório B1_EDICAO")]
    public string B1_EDICAO { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório ZZJ_FILIAL")]
    public string ZZJ_FILIAL { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório ZZJ_SERIE")]
    public string ZZJ_SERIE { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório ZZJ_LOJA")]
    public string ZZJ_LOJA { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório ZZJ_ITEMNF")]
    public string ZZJ_ITEMNF { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório ZZJ_QTDFAT")]
    public int ZZJ_QTDFAT { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório ZZJ_SALDO")]
    public double ZZJ_SALDO { get; set; }

    public string B1_TAMANHO { get; set; }
    public string IMAGEM_0 { get; set; }

    public string IMAGEM_1 { get; set; }

    public string IMAGEM_2 { get; set; }
    public string EXCLUIDO { get; set; }

    }
}



