using System;

namespace DotNetPOC.Models
{
    public class ProgramGroup
    {
        public int ProgramGroupId { get; set; }
        public string ConnectionStringKey { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Actual { get; set; }
    }
}