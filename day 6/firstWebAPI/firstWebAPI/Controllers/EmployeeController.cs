using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using firstWebAPI.Models;
using System.Linq.Expressions;

namespace firstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        Employees eObj = new Employees();

        [HttpGet]
        [Route("elist")]
        public IActionResult ShowAllEmployees()
        {
            return Ok(eObj.GetAllEmployees());
        }

        [HttpGet]
        [Route("elist/eDesigantion")]
        public IActionResult ShowEmployeeByDesignation(string eDesigantion)
        {

            var eData = eObj.GetEmployeeBydesigantion(eDesigantion);
            return Ok(eData);
        }

        [HttpGet]
        [Route("elist/isPermenant")]
        public IActionResult ShowEmployeeByStatus(bool isPermenant)
        {
            var eData = eObj.GetEmployeeStatus(isPermenant);
            return Ok(eData);
        }

        [HttpGet]
        [Route("elist/total")]
        public IActionResult ShowTotalEmployee()
        {
            return Ok(eObj.TotalEmployees());
        }

        [HttpGet]
        [Route("elist/id")]
        public IActionResult ShowEmployeeById(int id)
        {
            try
            {

                var emp = eObj.GetEmployeeById(id);
                return Ok(emp);
            }
            catch(Exception es)
            {
                return NotFound(es.Message);
            }
        }


        [HttpPost]
        [Route("elist/add")]
        public IActionResult AddEmployee(Employees newEmp)
        {
            try
            {
                var result = eObj.AddEmployee(newEmp);
                return Created("", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("elist/delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var result  = eObj.DeleteEmployee(id);
                return Ok(result);
            }
            catch (Exception es)
            {
                return NotFound(es.Message);
                
            }
        }

        [HttpPut]
        [Route("elist/edit")]
        public IActionResult EditEmployee(Employees changes)
        {
            try
            {
                var result = eObj.UpdateEmployee(changes);
                return Accepted(result);
            }
            catch (Exception es)
            {

                return BadRequest(es.Message);
            }
           
        }


    }
}


















