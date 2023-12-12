using Excellerent.Timesheet.Domain.Interfaces.Repository;
using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Models;
using Excellerent.Timesheet.Domain.Services;
using Excellerent.Timesheet.Domain.Mapping;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace Excellerent.Timesheet.Unittests
{
    public class TimeEntryServiceTests
    {
        private readonly TimeEntryService _timeEntryService;
        private readonly TimesheetAprovalService _timesheetAprovalService;
        private readonly Mock<ITimeEntryRepository> _timeEntryRepo = new Mock<ITimeEntryRepository>();
        private readonly Mock<ITimeSheetService> _itimesheetService = new Mock<ITimeSheetService>();
        private readonly Mock<ITimesheetAprovalService> _itimesheetApprovalService = new Mock<ITimesheetAprovalService>();
        private readonly Mock<ITimesheetAprovalRepository> _itimesheetApprovalRepo = new Mock<ITimesheetAprovalRepository>();

        public TimeEntryServiceTests()
        {
            _timeEntryService = new TimeEntryService(_timeEntryRepo.Object, _itimesheetService.Object, _itimesheetApprovalService.Object);
            _timesheetAprovalService = new TimesheetAprovalService(_itimesheetApprovalRepo.Object); 
        }

        [Fact]
        public async Task ApproveTimeSheet_WithExistingTimeSheet_ReturnTimeEntry()
        {
            // Arrange
               var Note = "Some Note";
               var Date = DateTime.Now;
               var Index = 0;
               var Hour = 1;
               var ProjectId = Guid.NewGuid();
               var TimesheetGuid = Guid.NewGuid();

                var timeEntry = new List<TimeEntry>
                {
                    new TimeEntry
                    {
                        Note = Note,
                        Date = Date,
                        Index = Index,
                        Hour = Hour,
                        ProjectId = ProjectId,
                        TimesheetGuid = TimesheetGuid
                    }

                };

            _timeEntryRepo.Setup(repo => repo.FindAsync(x => x.TimesheetGuid == TimesheetGuid))
                .ReturnsAsync(timeEntry);

            // Act
                var result = await _timeEntryService.ApproveTimeSheet(TimesheetGuid);

            // Assert
                Assert.Equal(timeEntry, result);
        }

        [Fact]
        public async Task ApproveTimeSheet_WithUnexistingTimeSheet_ReturnNoContent() {

            // Arrange
            var Note = "Some Note";
            var Date = DateTime.Now;
            var Index = 0;
            var Hour = 1;
            var ProjectId = Guid.NewGuid();
            var TimesheetGuid = Guid.NewGuid();

            var timeEntry = new List<TimeEntry>
            {
                new TimeEntry
                {
                    Note = Note,
                    Date = Date,
                    Index = Index,
                    Hour = Hour,
                    ProjectId = ProjectId,
                    TimesheetGuid = TimesheetGuid
                }

            };

            _timeEntryRepo.Setup(repo => repo.FindAsync(x => x.TimesheetGuid == It.IsAny<Guid>()))
                .ReturnsAsync(timeEntry);
            // Act
            var result = await _timeEntryService.ApproveTimeSheet(TimesheetGuid);

            // Assert
            Assert.Null(result);

        }

        [Fact]
        public async Task GetTimesheetApprovalStatus_WithExistingTimeSheetStatus_TimesheetAproval() {

            // Arrange
            var TimesheetId = Guid.NewGuid();

            var timesheetApproval = new List<TimesheetAproval>
                {
                    new TimesheetAproval
                    {
                        TimesheetId = Guid.NewGuid(),
                        ProjectId = Guid.NewGuid(),
                        Status = (int)ApprovalStatus.Requested
                    }
                };           

            _itimesheetApprovalRepo.Setup(repo => repo.FindAsync(x => x.TimesheetId == TimesheetId))
                .ReturnsAsync(timesheetApproval);
            // Act
            var result = await _timesheetAprovalService.GetTimesheetApprovalStatus(TimesheetId);

            // Assert
            Assert.Equal(timesheetApproval.Select(x => x.MapToDto()), result);
        }
    }
}
