using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace popCount.entities
{
    public class task
    {
        public int id { get; set; }
        public int idCity { get; set; }
        public status curStatus { get; set; }
        public DateOnly created_at { get; set; }
    }
}
