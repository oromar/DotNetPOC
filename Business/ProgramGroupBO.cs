using System.Collections.Generic;
using AutoMapper;
using DotNetPOC.Interfaces;
using DotNetPOC.Models;

namespace DotNetPOC.Business
{
    public class ProgramGroupBO : IProgramGroupBO
    {
        private readonly IMapper mapper;
        private readonly IProgramGroupDAO dao;

        public ProgramGroupBO(IProgramGroupDAO dao, IMapper mapper)
        {
            this.dao = dao;
            this.mapper = mapper;
        }
        public ProgramGroup Save(ProgramGroup programGroup)
        {
            return dao.Save(programGroup);
        }
        public IEnumerable<ProgramGroup> Get()
        {
            return dao.Get();
        }
        public void Set(int id)
        {
            dao.Set(id);
        }
        public ProgramGroup GetActual()
        {
            return dao.GetActual();
        }
    }
}