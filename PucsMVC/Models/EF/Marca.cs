using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PucsMVC.Models.EF
{
    public class Marca : Entity
    {
        public string NomeMarca { get; set; }

    }
}
