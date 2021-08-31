using SimCrm.Domain.Enumerations;
using SimCrm.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCrm.Domain.Entities
{
    [Table("email_address")]
    public class EmailAddress : IDatabaseTable
    {
        [Column("eml_id")]
        [Key]
        public Guid Id { get; set; }

        [Column("eml_cst_key")]
        public Guid CustomerId { get; set; }

        [Column("eml_home_address")]
        public string HomeEmailAddress { get; set; }

        [Column("eml_work_address")]
        public string WorkEmailAddress { get; set; }

        [Column("eml_other_address")]
        public string OtherEmailAddress { get; set; }

        [Column("eml_add_user")]
        public Guid AddUser { get; set; }

        [Column("eml_add_date")]
        public DateTime AddDate { get; set; }

        [Column("eml_change_user")]
        public Guid? ChangeUser { get; set; }

        [Column("eml_change_date")]
        public DateTime? ChangeDate { get; set; }
    }
}
