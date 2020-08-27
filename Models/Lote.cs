using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_CORE.Models
{
    public class LOTE
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Este campo NOME é obrigatório")]
        public String NOME { get; set; }
        public IList<REMESSA> REMESSA { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório DATA")]
        public DateTime DATA { get; set; }
        public string EXCLUIDO { get; set; }

    }
}



