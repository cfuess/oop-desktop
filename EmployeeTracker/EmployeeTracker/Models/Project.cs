using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class Project
    {
        public Project()
        {
            Technologies = new List<string>();
        }

        // declare public properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<string> Technologies { get; set; }
    }
}
