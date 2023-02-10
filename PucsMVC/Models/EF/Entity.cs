using System.ComponentModel.DataAnnotations;


namespace PucsMVC.Models.EF
{
    public abstract class Entity
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
