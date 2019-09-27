

namespace WebEval.Models
{
    using System.Data.Entity;

    public class DataContext :DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<WebEval.Models.Estudiante> Estudiantes { get; set; }

        public System.Data.Entity.DbSet<WebEval.Models.Nota> Notas { get; set; }
    }
}