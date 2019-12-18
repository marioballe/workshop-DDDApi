using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsBC.Domain.Entities.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException() : base()
        {

        }

        public DomainException(string msg) : base(msg)
        {

        }
    }
}
