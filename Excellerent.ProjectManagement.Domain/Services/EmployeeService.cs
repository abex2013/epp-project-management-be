using Excellerent.ProjectManagement.Domain.Interfaces.ServiceInterface;
using Excellerent.ProjectManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Excellerent.ProjectManagement.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        List<Employee> employees = new List<Employee>();
        public EmployeeService()
        {
            employees.AddRange(
            new List<Employee> {

                    new Employee {
                        Guid= new Guid("1fa85f64-5717-4562-b3fc-2c963f66afa6"),
                        Name = "Yosef Assefa",
                        Role ="Developer",
                        HiredDate = new DateTime(2021,5,1)

                    },
                    new Employee {
                        Guid= new Guid("2fa86f64-5717-4562-b3fc-2c963f66afa6"),
                        Name = "Yaschelew Erkihun",
                        Role ="Developer",
                        HiredDate = new DateTime(2015,5,1)
                    },
                    new Employee{
                        Guid= new Guid("3fa87f64-5717-4562-b3fc-2c963f66afa6"),
                        Name = "Abel Hailu",
                        Role ="Developer",
                        HiredDate = new DateTime(2015,5,1)
                    },
                    new Employee{
                        Guid= new Guid("4fa88f64-5717-4562-b3fc-2c963f66afa6"),
                        Name = "Abebe Kebede",
                        Role ="QA Tester",
                        HiredDate = new DateTime(2015,5,1)
                    },
                    new Employee{
                        Guid= new Guid("5fa89f64-5717-4562-b3fc-2c963f66afa6"),
                        Name = "Alemu Abraham",
                        Role = "Product Owner",
                        HiredDate = new DateTime(2015,5,1)
                    }

            }


            );

        }
        public IEnumerable<Employee> GetEmployee()
        {

            return employees;

        }

        public List<Employee> GetEmployeeById(Guid id)
        {
            return employees.Where(x => x.Guid == id).ToList();

        }
    }
}
