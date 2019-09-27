

namespace APIeval.Models
{
    using System.Data.Entity;
    public class DataContext :DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<APIeval.Models.Estudiante> Estudiantes { get; set; }

        public System.Data.Entity.DbSet<APIeval.Models.Nota> Notas { get; set; }
    }
}