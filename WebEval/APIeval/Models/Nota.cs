

namespace APIeval.Models
{
    using System.ComponentModel.DataAnnotations;
    public enum TypeSubject
    {
        Matematica,
        Fisica,
        Quimica
    }
    public enum TypeState
    {
        Aprobado,
        Reprobado
    }
    public class Nota
    {
        [Key]

        public TypeSubject Subject { get; set; }
        [Required]
        public int Grades { get; set; }
        [Required]
        public TypeState State { get; set; }
        [Required]
        public Estudiante Estudiante { get; set; }
    }
}