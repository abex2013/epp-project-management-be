using Excellerent.ResourceManagement.Domain.Interfaces.Repository;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.ResourceManagement.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Excellerent.ResourceManagement.UnitTests
{
    public class EmployeeServiceTest
    {
        private readonly EmployeeService _EmpService;
        private readonly Mock<IEmployeeRepository> EmpRepository = new Mock<IEmployeeRepository>();

        public EmployeeServiceTest()
        {
            _EmpService = new EmployeeService(EmpRepository.Object);
        }

        [Fact]
        public async Task GetAllEmployees()
        {
            Guid EmpId = Guid.NewGuid();
            var EmployeeEntity = new List<Employee>() { 
            new Employee()
            {
                Guid = EmpId,
                FirstName = "abel",
                FatherName = "abel",
                GrandfatherName = "abel",
                DateofBirth = DateTime.Now,
                Nationality = new List<Nationality>() {

                    new Nationality() {
                        Guid = Guid.NewGuid(),
                        IsActive = true,
                        Name = "Ethiopian",
                        CreatedbyUserGuid = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        IsDeleted = false
                    }
                },
                IsActive = true,
                EmployeeOrganization = new EmployeeOrganization() {
                    Guid = Guid.NewGuid(),
                    DutyStation = 1,
                    IsActive = true,
                    DutyBranch = 1,
                    Department = "HR",
                    CompaynEmail = "d@mail.com",
                    CreatedbyUserGuid = Guid.NewGuid(),
                    EmploymentType = 1,
                    JobTitle = "manager",
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    EmployeeId = Guid.NewGuid(),
                    JoiningDate = DateTime.Now,
                    PhoneNumber = "251784596",
                    ReportingManager = Guid.NewGuid(),
                    Status = 1,
                    TerminationDate = DateTime.Now
                },
                CreatedbyUserGuid = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                EmergencyContact = new List<EmergencyContact>() {
                    new EmergencyContact() {
                        Guid = Guid.NewGuid(),
                        CreatedbyUserGuid = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        EmployeeId = 1,
                        FatherName = "abel",
                        FirstName = "abel",
                        IsActive = true,
                        IsDeleted = false,
                        Relationship = "bro",
                        Address = new List<EmergencyAddress>()
                        {
                            new EmergencyAddress()
                            {
                                Guid = Guid.NewGuid(),
                                CreatedDate = DateTime.Now,
                                City = "Addis",
                                Country = "Ethiopia",
                                CreatedbyUserGuid = Guid.NewGuid(),
                                HouseNumber = "12344",
                                IsActive = true,
                                IsDeleted = false,
                                PhoneNumber = "2514587896",
                                PostalCode = 1234,
                                StateRegionProvice = "Addis",
                                SubCityZone = "Bole",
                                Woreda = "12"
                            }
                        }

                    }

                },
                Gender = "male",
                IsDeleted = false,
                MobilePhone = "25145126398",
                PersonalEmail = "asdasd@mail.com",
                PersonalEmail2 = "wasdasd@mail.com",
                PersonalEmail3 = "qasdasd@mail.com",
                Phone1 = "251879652",
                Phone2 = "251687541",
                Photo = "",
                EmployeeAddress = new List<PersonalAddress>() {

                            new PersonalAddress(){
                             Guid = Guid.NewGuid(),
                              City = "Addis",
                               Country="Ethio",
                                CreatedbyUserGuid = Guid.NewGuid(),
                                 CreatedDate = DateTime.Now,
                                  HouseNumber = "1452545",
                                   IsActive = true,
                                    IsDeleted = false,
                                     PhoneNumber = "25147856324",
                                      PostalCode = 12545,
                                       StateRegionProvice = "Addis",
                                        SubCityZone = "Bole",
                                         Woreda = "12"
                            }
                        },
                 FamilyDetails = new List<FamilyDetails>()
                 {
                     new FamilyDetails(){
                      Guid = Guid.NewGuid(),
                       CreatedbyUserGuid = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                          DoB = DateTime.Now,
                           EmployeeId = Guid.NewGuid(),
                            FamilyMemberId = Guid.NewGuid(),
                              FullName = "abel",
                               Gender = "male",
                                IsActive = true,
                                 IsDeleted = false,
                                  
                                   Remark = "ok",
                                     Relationship = new Relationship()


                     }
                 }

                 }
            };



             EmpRepository.Setup(x =>  x.GetEmployeesAsync()).ReturnsAsync(EmployeeEntity);
            //Act
            var retrivedEmp = await _EmpService.GetAllEmployeesAsync();
            //Assert
            Assert.Equal(EmployeeEntity, retrivedEmp);



        }
        



    }
}
