using System.Collections.Generic;
using System.Data.SqlClient;
using GeofenceClockIn.Models;
using Microsoft.Extensions.Configuration;

namespace GeofenceClockIn.MobileAppService.Accessors
{
    public class GenericAccessor : IGenericAccessor
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        
        public GenericAccessor(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetSection("SqlEndPointConnectionString").Value;
        }

        public List<Shift> GetAllShiftsByEmployeeId(string employeeId)
        {
            List<Shift> listOfShifts = new List<Shift>();
            string sqlQuery = "SELECT StartTime, EndTime, EmployeeId, LocationId, CompanyId, WageTitle, WageHourlyRate " +
                "FROM Shifts WHERE EmployeeId = @employeeId;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@employeeId", employeeId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Shift tempShift = new Shift()
                            {
                                StartTime = reader.GetDateTime(0),
                                EndTime = reader.GetDateTime(1),
                                EmployeeId = reader.GetString(2),
                                LocationId = reader.GetString(3),
                                CompanyId = reader.GetString(4),
                                Wage = new ShiftWage()
                                {
                                    Title = reader.GetString(5),
                                    HourlyRate = reader.GetDouble(6)
                                }
                            };

                            listOfShifts.Add(tempShift);
                        }
                    }
                }
            }

            return listOfShifts;
        }

        public string CreateShift(Shift shift)
        {
            string createdId = string.Empty;
            string sqlQuery = "INSERT INTO Shifts VALUES (@startTime, @endTime, @employeeId, @locationId, @companyId, @wageTitle, @wageHourlyRate); " +
                "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@startTime", shift.StartTime);
                    command.Parameters.AddWithValue("@endTime", shift.EndTime);
                    command.Parameters.AddWithValue("@employeeId", shift.EmployeeId);
                    command.Parameters.AddWithValue("@locationId", shift.LocationId);
                    command.Parameters.AddWithValue("@companyId", shift.CompanyId);
                    command.Parameters.AddWithValue("@wageTitle", shift.Wage.Title);
                    command.Parameters.AddWithValue("@wageHourlyRate", shift.Wage.HourlyRate);

                    createdId = command.ExecuteScalar().ToString();
                }
            }

            return createdId;
        }

        public string DeleteShift(string id)
        {
            string deletedId = string.Empty;
            string sqlQuery = "DELETE FROM Shifts WHERE Id = @id;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        deletedId = id;
                    }
                }
            }

            return deletedId;
        }

        public Shift UpdateShift(string id, Shift shift)
        {
            Shift updatedShift = null;
            string sqlQuery = "UPDATE Shifts SET " +
                "StartTime = @startTime, " +
                "EndTime = @endTime, " +
                "EmployeeId = @employeeId, " +
                "LocationId = @locationId, " +
                "CompanyId = @companyId, " +
                "WageTitle = @wageTitle, " +
                "WageHourlyRate = @wageHourlyRate " +
                "WHERE Id = @id;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@startTime", shift.StartTime);
                    command.Parameters.AddWithValue("@endTime", shift.EndTime);
                    command.Parameters.AddWithValue("@employeeId", shift.EmployeeId);
                    command.Parameters.AddWithValue("@locationId", shift.LocationId);
                    command.Parameters.AddWithValue("@companyId", shift.CompanyId);
                    command.Parameters.AddWithValue("@wageTitle", shift.Wage.Title);
                    command.Parameters.AddWithValue("@wageHourlyRate", shift.Wage.HourlyRate);
                    command.Parameters.AddWithValue("@id", id);

                    if(command.ExecuteNonQuery() == 1)
                    {
                        updatedShift = shift;
                    }
                }
            }

            return updatedShift;
        }
    }

}
