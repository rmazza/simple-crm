using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SimpleCRM.Models
{
    [Table("phone")]
    public class PhoneNumber
    {
        private Guid id;
        private Guid customerId;
        private string number;
        private Guid phoneTypeId;
        private string extension;
        private Guid addUser;
        private DateTime addDate = DateTime.Now;
        private Guid? changeUser;
        private DateTime? changeDate;   

        [Column("phn_id")]
        public Guid Id { get => id; set => id = value; }

        [Column("phn_cst_id")]
        public Guid CustomerId { get => customerId; set => customerId = value; }

        [Column("phn_number")]
        [Required]
        public string Number { get => number; set => number = value; }

        [Column("phn_ext")]
        public string Extension { get => extension; set => extension = value; }

        [Column("phn_pht_id")]
        public Guid PhoneTypeId { get => phoneTypeId; set => phoneTypeId = value; }

        [Column("phn_add_user")]
        public Guid AddUser { get => addUser; set => addUser = value; }

        [Column("phn_add_date")]
        public DateTime AddDate { get => addDate; set => addDate = value; }

        [Column("phn_change_user")]
        [AllowNull]
        public Guid? ChangeUser { get => changeUser; set => changeUser = value; }

        [Column("phn_change_date")]
        [AllowNull]
        public DateTime? ChangeDate { get => changeDate; set => changeDate = value; }

        public PhoneType PhoneType { get; set; }
    }
}
