using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Emp
    {
        public int Empid { get; set; }
        public string? Empname { get; set; }
        public decimal? Salary { get; set; }
        public string? Deptid { get; set; }

        public virtual Dept? Dept { get; set; }
    }
}
