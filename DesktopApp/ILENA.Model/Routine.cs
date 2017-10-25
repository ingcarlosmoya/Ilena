using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ILENA.Model
{
    public class Routine
    {
        private List<Movement> movements;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PatientId { get; set; }
        public DateTime CreateDateTime { get; set; }

        public List<Movement> Movements
        {
            get {
                if (this.movements != null)
                    return this.movements;
                else
                {
                    this.movements = new List<Movement>();
                    return this.movements;
                }
            }
            set
            {
                movements = value;
            }
        }

        public Routine(Guid patientId, string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            PatientId = patientId;
            CreateDateTime = DateTime.Now;
        }
    }
}
