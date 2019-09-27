using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIeval.Models
{
    public enum TypeSex
    {
        Masculino,
        Femenino
    }
    public class Estudiante
    {
        [Key]

        public int StudentID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public TypeSex Sex { get; set; }
        [Required]
        public int Date { get; set; }
        [Required]
        public virtual ICollection<Nota> Notas { get; set; }
    }
}