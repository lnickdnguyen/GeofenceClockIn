using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeofenceClockIn.MobileAppService.Services;
using GeofenceClockIn.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeofenceClockIn.MobileAppService.Controllers
{
    public class GenericController : Controller
    {
        private readonly IGenericService _genericService;

        public GenericController(IGenericService genericService)
        {
            _genericService = genericService;
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

            try
            {
                listOfShifts = _genericService.GetAllShiftsByEmployeeId(employeeId);
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

            try
            {
                createdId = _genericService.CreateShift(shift);
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
                updatedShift = _genericService.UpdateShift(id, shift);
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
                deletedId = _genericService.DeleteShift(id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message} while deleting shift: {id}.");
            }

            return deletedId;
        }
    }
}
