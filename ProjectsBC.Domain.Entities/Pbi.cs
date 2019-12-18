using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsBC.Domain.Entities
{
    public class Pbi
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Task> Tasks { get; set; }

        public PbiStatus Status { get; set; }

        public Project Project { get; set; }
    }
}
