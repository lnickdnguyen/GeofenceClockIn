using System;
using System.Collections.Generic;
using System.Text;

namespace GeofenceClockIn.Models
{
    public class Shift
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string EmployeeId { get; set; }

        public string LocationId { get; set; }

        public string CompanyId { get; set; }

        public ShiftWage Wage { get; set; }
    }
}
