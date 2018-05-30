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
            var app = context.AppStatus.OrderBy(a => a.AppStatusId).FirstOrDefault();
            if (app == null)
            {
                app = new AppStatus();
                context.AppStatus.Add(app);
                context.SaveChanges();
            }
            app.ActualProgramGroupId = id;
            context.SaveChanges();
        }
        public ProgramGroup GetActual()
        {
            var app = context.AppStatus.OrderBy(a => a.AppStatusId).FirstOrDefault();

            if (app != null)
            {
                return context.ProgramGroups.First(a => a.ProgramGroupId == app.ActualProgramGroupId);
            }
            return context.ProgramGroups
                .FirstOrDefault (a => a.ConnectionStringKey == "Default");
        }
    }
}