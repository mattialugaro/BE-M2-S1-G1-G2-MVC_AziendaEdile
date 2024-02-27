using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_AziendaEdile.Models
{
    public class Dipendente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string CodiceFiscale {  get; set; }
        public bool Coniugato {  get; set; }

        [Display(Name = "Numero di figli a carico")]
        public int NumeroFigli {  get; set; }
        public string Mansione { get; set; }

        public Dipendente() { }

        public Dipendente(string nome, string cognome, string indirizzo, string codiceFiscale, bool coniugato, int numeroFigli, string mansione)
        {
            Nome = nome;
            Cognome = cognome;
            Indirizzo = indirizzo;
            CodiceFiscale = codiceFiscale;
            Coniugato = coniugato;
            NumeroFigli = numeroFigli;
            Mansione = mansione;
        }
        
    }
}