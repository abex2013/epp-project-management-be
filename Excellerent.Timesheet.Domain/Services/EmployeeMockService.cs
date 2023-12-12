using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Excellerent.Timesheet.Domain.Services
{
    public class EmployeeMockService : IEmployeeMockService
    {
        private readonly List<EmployeeMock> _employees;
        public EmployeeMockService()
        {
            _employees = new List<EmployeeMock>();
            _employees.AddRange(
                new List<EmployeeMock> {

                    new EmployeeMock {
                        Id = 1,
                        Name = "Belay Retta",
                        ProjectId = 1,
                    },
                    new EmployeeMock {
                        Id = 2,
                        Name = "Alemayhu Ewnetu",
                        ProjectId = 2,
                    },
                    new EmployeeMock{
                        Id = 2,
                        Name = "Abel Debebe",
                        ProjectId = 2
                    },
                    new EmployeeMock{
                        Id = 2,
                        Name = "Berihun Hadis",
                        ProjectId = 0
                    },
                    new EmployeeMock{
                        Id = 2,
                        Name = "Eyob Adugna",
                        ProjectId = 0
                    }

                });


        }
        public List<EmployeeMock> GetEmployee(int? id)
        {
            return id == null ? _employees : _employees.Where(x => x.Id == id).ToList();
        }
    }
}
