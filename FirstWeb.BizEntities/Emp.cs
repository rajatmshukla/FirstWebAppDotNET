using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWeb.BizEntities
{
    public class Emp
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public int deptno { get; set; }
        public decimal salary { get; set; }
        public string DateUpdated { get; set; }

        public string CompareResult { get; set; }

        public string DateResult { get; set; }

    }
}
