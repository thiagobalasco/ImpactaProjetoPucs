using System.ComponentModel.DataAnnotations;

namespace PucsMVC.Models.EF
{
    public class Modelo : Entity
    {

        public string NomeModelo { get; set; }

        public virtual Marca? Marca { get; set; }

        public int MarcaId { get; set; }
    }
}
