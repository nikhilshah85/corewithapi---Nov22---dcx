using System.Reflection.Metadata.Ecma335;

namespace firstWebAPI.Models
{
    public class Employees
    {
        public int eId { get; set; }
        public string eName { get; set; }
        public string eDesignation { get; set; }

        public double   eSalary  { get; set; }

        public bool eIsPermenant { get; set; }

        static List<Employees> eList = new List<Employees>()
        {
            new Employees() { eId=101, eName="Sahil", eDesignation="Sales", eIsPermenant=true, eSalary=5000},
            new Employees() { eId=102, eName="Rahul", eDesignation="HR", eIsPermenant=true, eSalary=15000},
            new Employees() { eId=103, eName="Kriti", eDesignation="Sales", eIsPermenant=false, eSalary=25000},
            new Employees() { eId=104, eName="Akshay", eDesignation="Sales", eIsPermenant=true, eSalary=4000},
            new Employees() { eId=105, eName="Ritu", eDesignation="Accounts", eIsPermenant=true, eSalary=18000},
            new Employees() { eId=106, eName="Mohan", eDesignation="Accounts", eIsPermenant=true, eSalary=45000},

        };

        public List<Employees> GetAllEmployees()
        {
            return eList;
        }

        public Employees GetEmployeeById(int id)
        {
            var emp = eList.Find(er => er.eId == id);
            if (emp != null)
            {
                return emp;
            }
            throw new Exception("Employee not found");
        }

        public List<Employees> GetEmployeeStatus(bool isPermenant)
        {
            var emp = eList.FindAll(er => er.eIsPermenant == isPermenant);
            return emp;
        }


        public int TotalEmployees()
        {
            return eList.Count;
        }
        public List<Employees> GetEmployeeBydesigantion(string desigantion)
        {
            var emp = eList.FindAll(er => er.eDesignation == desigantion);
            return emp;
        }

        public string AddEmployee(Employees newEmpObj)
        {
            //do validation here
            //Eg
            if (newEmpObj.eName.Length < 2)
            {
                throw new Exception("Name is not accepted, please contact admin, (recommendations: provide name more than 2 characters");
            }
            eList.Add(newEmpObj);
            return "Employee Added Successfully";
        }

        public string UpdateEmployee(Employees empObjChanges)
        {
            var emp = eList.Find(er => er.eId == empObjChanges.eId);
            if (emp!=null)
            {
                emp.eName = empObjChanges.eName;
                emp.eSalary = empObjChanges.eSalary;
                emp.eIsPermenant = empObjChanges.eIsPermenant;
                return "Employee Details changed successfully";
            }
            throw new Exception("Employee not found in system");
        }

        public string DeleteEmployee(int id)
        {
            var emp = eList.Find(er => er.eId == id);
            if (emp != null)
            {
                eList.Remove(emp);
                return "Employee Deleted Successfully";
            }
            throw new Exception("Employee Not Found, and this not deleted");
        }
    }
}











