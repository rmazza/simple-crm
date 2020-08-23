using SimpleCRM.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SimpleCRM.Models
{
    [Table("phone_type")]
    public class PhoneType : IDatabaseTable
    {
        private Guid id;
        private Guid addUser;
        private DateTime addDate = DateTime.Now;
        private Guid? changeUser;
        private DateTime? changeDate;
        private string type;

        [Column("pht_id")]
        public Guid Id { get => id; set => id = value; }
        [Column("pht_type")]
        [Required]
        public string Type { get => type; set => type = value; }
        [Column("pht_add_user")]
        public Guid AddUser { get => addUser; set => addUser = value; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pht_add_date")]
        public DateTime AddDate { get => addDate; set => addDate = value; }

        [Column("pht_change_user")]
        [AllowNull]
        public Guid? ChangeUser { get => changeUser; set => changeUser = value; }

        [Column("pht_change_date")]
        [AllowNull]
        public DateTime? ChangeDate { get => changeDate; set => changeDate = value; }
    }
}
