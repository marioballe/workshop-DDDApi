using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsBC.Domain.Entities
{
    public class Sprint
    {
        public int Id { get; set; }

        public DateRange DateRange { get; set; }

        public bool OverlapsWith(Sprint other)
        {
            return other.DateRange.StartDate < this.DateRange.EndDate &&
                   other.DateRange.EndDate > this.DateRange.StartDate;
        }
    }
}
