using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace PucsMVC.Models.EF
{
    public class Apolice : Entity
    {

        [Display(Name = "Classe de bonus")]
        public string ClasseBonus { get; set; }

        [Display(Name = "Numero Apolice")]
        public string IdentificacaoApolice { get; set; }

        [Display(Name = "Inicio da vigencia"), DataType(DataType.Date)]
        public DateTime? DataInicioVigencia { get; set; }

        [Display(Name = "Fim da vigencia"), DataType(DataType.Date)]
        public DateTime? DataFimVigencia { get; set; }

        public virtual Cliente? Cliente { get; set; }

        public int ClienteId { get; set; }

        public virtual Modelo? Modelo { get; set; }

        public int ModeloId { get; set; }

    }
}
