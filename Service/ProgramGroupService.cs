using System.Collections.Generic;
using AutoMapper;
using DotNetPOC.Interfaces;
using DotNetPOC.Models;
using DotNetPOC.Resources;

namespace DotNetPOC.Service
{
    public class ProgramGroupService : IProgramGroupService
    {
        private readonly IProgramGroupBO programGroupBO;
        private readonly IMapper mapper;
        public ProgramGroupService(IProgramGroupBO programGroupBO, IMapper mapper)
        {
            this.mapper = mapper;
            this.programGroupBO = programGroupBO;
        }
        public IEnumerable<ProgramGroupResource> Get()
        {
            var programGroups = programGroupBO.Get();
            return mapper.Map<IEnumerable<ProgramGroup>, IEnumerable<ProgramGroupResource>>(programGroups);
        }
        public ProgramGroupResource GetActual() => mapper.Map<ProgramGroup, ProgramGroupResource>(programGroupBO.GetActual());
        public ProgramGroupResource Save(ProgramGroupResource programGroupResource)
        {
            var programGroup = mapper.Map<ProgramGroupResource, ProgramGroup>(programGroupResource);
            programGroupBO.Save(programGroup);
            return mapper.Map<ProgramGroup, ProgramGroupResource>(programGroup);
        }
        public void Set(int id)
        {
            programGroupBO.Set(id);
        }
    }
}