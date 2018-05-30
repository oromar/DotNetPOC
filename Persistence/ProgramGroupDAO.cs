using System.Collections.Generic;
using DotNetPOC.Interfaces;
using DotNetPOC.Models;
using System.Linq;

namespace DotNetPOC.Persistence
{
    public class ProgramGroupDAO : IProgramGroupDAO
    {
        private readonly AuthContext context;
        public ProgramGroupDAO(AuthContext context)
        {
            this.context = context;
        }
        public IEnumerable<ProgramGroup> Get()
        {
            return context.ProgramGroups.ToList();
        }
        public ProgramGroup Save(ProgramGroup programGroup)
        {
            context.ProgramGroups.Add(programGroup);
            context.SaveChanges();
            return programGroup;
        }
        public void Set(int id)
        {
            throw new System.NotImplementedException();
        }
        public ProgramGroup GetActual()
        {
             throw new System.NotImplementedException();
        }
    }
}