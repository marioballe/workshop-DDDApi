using FluentAssertions;
using ProjectsBC.Domain.Entities.Exceptions;
using System;
using Xunit;

namespace ProjectsBC.Domain.Entities.Tests
{
    public class ProjectTest
    {
        [Fact]
        public void GivenProjectWithSprintsThenAddingOverlappingSprintMustThrowException()
        {
            var project = new Project();
            var sprint1 = new Sprint()
            {
                DateRange = new DateRange(new DateTime(2019, 12, 18), new DateTime(2019, 12, 31))
            };
            var sprint2 = new Sprint()
            {
                DateRange = new DateRange(new DateTime(2019, 12, 25), new DateTime(2020, 1, 7))
            };
            project.AddSprint(sprint1);
            FluentActions.Invoking(() => project.AddSprint(sprint2)).Should().Throw<DomainException>();
        }
    }
}
