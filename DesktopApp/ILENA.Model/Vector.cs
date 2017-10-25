using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILENA.Model
{
    public class Vector
    {
        public string Joint { get; set; }
        public double Length { get; }
        public double LengthSquared { get; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Guid Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public Guid MovementId { get; set; }
        [ForeignKey("MovementId")]
        public virtual Movement Movement { get; set; }


        public Vector()
        {
            Id = Guid.NewGuid();
            CreateDateTime = DateTime.Now;
        }
    }
}
