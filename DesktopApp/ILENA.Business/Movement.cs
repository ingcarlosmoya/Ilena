using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILENA.Business
{

    public class Movement
    {
        public List<Model.Movement> GetMovementsByRoutineGuid(Guid routineGuid)
        {
            var movements = Data.Officer.GetMovementsByRoutineGuid(routineGuid);
            return movements;
        }       
    }
}
