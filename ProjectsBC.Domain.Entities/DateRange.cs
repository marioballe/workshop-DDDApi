using ProjectsBC.Domain.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsBC.Domain.Entities
{
    public class DateRange
    {
        private DateTime dateTime;

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public int Duration
        {
            get => (EndDate - StartDate).Days;
        }

        private DateRange()
        {

        }
        public DateRange(DateTime start, DateTime end)
        {
            if(end <= start)
            {
                throw new DomainException($"End date {end} cannot happen before or equal start");
            }

            StartDate = start;
            EndDate = end;
        }

        public DateRange(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public static bool operator ==(DateRange one, DateRange two)
         => one.EndDate == two.EndDate && one.StartDate == two.EndDate;

        public static bool operator !=(DateRange one, DateRange two)
            => !(one == two);

        public override bool Equals(object obj)
        {
            if(obj is DateRange)
            {
                return ((DateRange)obj) == this;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Duration.GetHashCode();
        }
    }
}
