using ProjectsBC.Domain.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectsBC.Domain.Entities
{
    public class Project
    {
        private readonly List<Sprint> _sprints; //això es un patró
        public int Id { get; set; }
        public string Decription { get; set; }
        public ICollection<Pbi> Backlog { get; set; }
        public IEnumerable<Sprint> Sprints { get => _sprints; } // Un enumerable no té add, la protegim per a evitar project.sprint.add
        public Team Team { get; set; }

        public void AddSprint(Sprint sprintToAdd)
        {
            //Jo t'accepto aquest sprint si no col·lisiona amb cap altre
            if(!CheckOverlapping(sprintToAdd))
            {
                _sprints.Add(sprintToAdd);
            }
            else
            {
                throw new DomainException($"collision sprint");
            }
        }

        private Project() { 
        
        }
        public Project(string desc)
        {
            _sprints = new List<Sprint>();
            Decription = desc;
        }
        private bool CheckOverlapping(Sprint newSprint)
        {
            return Sprints.Any(s => s.OverlapsWith(newSprint));
        }
    }
}
