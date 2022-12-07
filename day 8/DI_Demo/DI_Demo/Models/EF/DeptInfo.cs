using System;
using System.Collections.Generic;

namespace DI_Demo.Models.EF
{
    public partial class DeptInfo
    {

        public DeptInfo()
        {
            EmployeeInfos = new HashSet<EmployeeInfo>();
        }

        public int DId { get; set; }
        public string? DName { get; set; }
        public string? DLocation { get; set; }

        public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; }

       

        public List<DeptInfo> GetDeptByLocation(string loc)
        {

            EmployeeDBContext _db = new EmployeeDBContext();

            var deptByLoc = (from d in _db.DeptInfos
                            where d.DLocation == loc
                            select d).ToList();
            return deptByLoc;


         }





    }
}
