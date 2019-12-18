using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsBC.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ProjectTaskStatus Status { get; set; }

        public User Owner { get; set; }
    }
}
