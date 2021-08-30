using System;

namespace SimCrm.Domain.Interfaces
{
    public interface IDatabaseTable
    {
        Guid Id { get; set; }
        Guid AddUser { get; set; }
        DateTime AddDate { get; set; }
        Guid? ChangeUser { get; set; }
        DateTime? ChangeDate { get; set; }
    }
}
