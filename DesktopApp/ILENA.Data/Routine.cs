using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILENA.Data
{
    public static class Routine
    {
        public static void createRoutine(Model.Routine routine)
        {
            using (var db = new ILENAContext())
            {
                db.Routines.Add(routine);
                db.SaveChanges();
            }
        }
    }
}
