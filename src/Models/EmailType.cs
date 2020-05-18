using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SimpleCRM.Models
{
    [Table("email_type")]
    public class EmailType
    {
        private DateTime? changeDate;
        private string changeUser;
        private DateTime addDate;
        private string addUser;
        private string type;
        private Guid emailTypeId;

        [Key]
        [Column("emt_id")]
        public Guid EmailTypeId { get => emailTypeId; set => emailTypeId = value; }

        [Column("emt_type")]
        public string Type { get => type; set => type = value; }

        [Column("emt_add_user")]
        public string AddUser { get => addUser; set => addUser = value; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("emt_add_date")]
        public DateTime AddDate { get => addDate; set => addDate = value; }

        [Column("emt_change_user")]
        [AllowNull]
        public string ChangeUser { get => changeUser; set => changeUser = value; }

        [Column("emt_change_date")]
        [AllowNull]
        public DateTime? ChangeDate { get => changeDate; set => changeDate = value; }

    }
}
