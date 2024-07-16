using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Emps = new HashSet<Emp>();
        }

        public string Deptid { get; set; } = null!;
        public string? Deptname { get; set; }

        public virtual ICollection<Emp> Emps { get; set; }
    }
}
