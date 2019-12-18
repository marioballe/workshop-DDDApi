using ProjectsBC.Domain.Entities;
using System;

namespace ProjectsBC.Domain
{
    public interface IProjectRepository {
        Project GetById(int id);
    }
}
