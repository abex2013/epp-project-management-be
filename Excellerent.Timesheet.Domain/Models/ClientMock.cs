using System.Collections.Generic;

namespace Excellerent.Timesheet.Domain.Models
{
    public class ClientMock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProjectMock> Pojects { get; set; }
    }
}
