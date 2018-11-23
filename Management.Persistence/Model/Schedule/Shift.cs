using System;
using Dapper.FluentMap.Dommel.Mapping;
using Management.Persistence.Documents;

namespace Management.Persistence.Model
{
    public class ShiftMap : DommelEntityMap<Shift>
    {
        public ShiftMap()
        {
            ToTable("shifts");
            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.ShiftStart).ToColumn("shiftstart");
            Map(x => x.ShiftEnd).ToColumn("shiftend");
            Map(x => x.EmployeeOnShift).ToColumn("employee");
            Map(x => x.Duration).ToColumn("duration");
        }
        
    }
    
    public class Shift : IEntity
    {
        public Guid Id { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public Guid EmployeeOnShift { get; set; }
        public double Duration { get; set; }
        

      
    }
}