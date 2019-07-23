using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeofenceClockIn.MobileAppService.Services;
using Microsoft.AspNetCore.Mvc;
using Square.Connect.Model;

namespace GeofenceClockIn.MobileAppService.Controllers
{
    public class SquareController : Controller
    {
        private readonly ISquareService _squareService;

        public SquareController(ISquareService squareService)
        {
            _squareService = squareService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("shifts/get/{employeeId}")]
        public ActionResult<List<Shift>> GetAllShiftsByEmployeeId(string employeeId)
        {
            List<Shift> listOfShifts = default;
            employeeId = null;

            try
            {
                listOfShifts = _squareService.GetAllShiftsByEmployeeId(employeeId);
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message} while retrieving shifts for employee id: {employeeId}.");
            }

            return listOfShifts;
        }

        [HttpPost("shifts/create")]
        public ActionResult<string> CreateShift([FromBody]Shift shift)
        {
            string createdId = default;
            //Shift newShift = new Shift(EmployeeId: "mxYbEc9mwv8HvzTDqUbI", LocationId: "Q1M7965YS9HY4", StartAt: "2018-07-23T10:00:00-07:00");

            try
            {
                createdId = _squareService.CreateShift(shift);
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message} while creating shift.");
            }
            
            return createdId;
        }

        [HttpPut("shifts/update/{id}")]
        public ActionResult<Shift> UpdateShift(string id, [FromBody] Shift shift)
        {
            Shift updatedShift = default;

            try
            {
                updatedShift = _squareService.UpdateShift(id, shift);
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message} while updating shift: {id}.");
            }

            return updatedShift;
        }

        [HttpDelete("shifts/delete/{id}")]
        public ActionResult<string> Delete(string id)
        {
            string deletedId = default;

            try
            {
                deletedId = _squareService.DeleteShift(id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message} while deleting shift: {id}.");
            }

            return deletedId;
        }
    }
}
