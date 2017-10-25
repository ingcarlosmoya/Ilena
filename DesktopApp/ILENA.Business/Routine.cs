using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILENA.Model;

namespace ILENA.Business
{
    public class Routine
    {
        public Model.Routine GetRoutineByGuid(Guid routineGuid)
        {
            Model.Routine routine =  Data.Officer.GetRoutineByGuid(routineGuid);
            return routine;
        }
    }
}
