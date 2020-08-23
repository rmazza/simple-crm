using SimpleCRM.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SimpleCRM.Models
{
    [Table("email_type")]
    public class EmailType : IDatabaseTable
    {
        private DateTime? changeDate;
        private Guid? changeUser;
        private DateTime addDate;
        private Guid addUser;
        private string type;
        private Guid id;

        [Key]
        [Column("emt_id")]
        public Guid Id { get => id; set => id = value; }

        [Column("emt_type")]
        public string Type { get => type; set => type = value; }

        [Column("emt_add_user")]
        public Guid AddUser { get => addUser; set => addUser = value; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("emt_add_date")]
        public DateTime AddDate { get => addDate; set => addDate = value; }

        [Column("emt_change_user")]
        [AllowNull]
        public Guid? ChangeUser { get => changeUser; set => changeUser = value; }

        [Column("emt_change_date")]
        [AllowNull]
        public DateTime? ChangeDate { get => changeDate; set => changeDate = value; }

    }
}
