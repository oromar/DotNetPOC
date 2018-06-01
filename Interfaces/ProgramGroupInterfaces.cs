using System.Collections.Generic;
using DotNetPOC.Models;
using DotNetPOC.Resources;

namespace DotNetPOC.Interfaces
{
    public interface IProgramGroupDomain
    {
        ProgramGroupResource Save(ProgramGroupResource programGroupResource);
        IEnumerable<ProgramGroupResource> Get();
        void Set(int id);
        ProgramGroupResource GetActual();
    }
    public interface IProgramGroupOperations
    {
        ProgramGroup Save(ProgramGroup programGroup);
        IEnumerable<ProgramGroup> Get();
        void Set(int id);
        ProgramGroup GetActual();
    }
    public interface IProgramGroupBO : IProgramGroupOperations
    {
    }
    public interface IProgramGroupDAO : IProgramGroupOperations
    {
    }
}