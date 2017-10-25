using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ILENA.Model;

namespace ILENA.Data
{
    public class ILENAContext: DbContext
    {
        public ILENAContext() : base("ILENA")
        {
        }
        public DbSet<ILENA.Model.Movement> Movements { get; set; }
        public DbSet<ILENA.Model.Routine> Routines { get; set; }
        public DbSet<ILENA.Model.Vector> Vectors { get; set; }
        public DbSet<ILENA.Model.Patient> Patients { get; set; }
        public DbSet<ILENA.Model.Evaluation> Evaluations { get; set; }
    }
}
