using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace MVC_AziendaEdile.Models
{
    public class Pagamento
    {
        public DateTime PeriodoPagamento {  get; set; }
        public Decimal AmmontarePagamento { get; set; }

        [Display(Name = "Versamento Acconto o Stipendio")]
        public string AccontoStipendio { get; set; }
        
        public Pagamento() { }

        public Pagamento(DateTime periodoPagamento, decimal ammontarePagamento, string accontoStipendio)
        {
            PeriodoPagamento = periodoPagamento;
            AmmontarePagamento = ammontarePagamento;
            AccontoStipendio = accontoStipendio;
        }
    }
}