using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SimpleCRM.Models
{
    [Table("email")]
    public class EmailAddress
    {
        private Guid id;
        private string email;
        private Guid customerId;
        private Guid addUser;
        private DateTime addDate;
        private Guid? changeUser;
        private DateTime? changeDate;
        private Guid emailTypeId;

        [Column("eml_id")]
        [Key]
        public Guid EmailId { get => id; set => id = value; }

        [Column("eml_cst_id")]
        public Guid CustomerId { get => customerId; set => customerId = value; }

        [Column("eml_emt_id")]
        public Guid EmailTypeId { get => emailTypeId; set => emailTypeId = value; }

        [Column("eml_address")]
        public string Email { get => email; set => email = value; }

        [Column("eml_add_user")]
        public Guid AddUser { get => addUser; set => addUser = value; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("eml_add_date")]
        public DateTime AddDate { get => addDate; set => addDate = value; }

        [Column("eml_change_user")]
        [AllowNull]
        public Guid? ChangeUser { get => changeUser; set => changeUser = value; }

        [Column("eml_change_date")]
        [AllowNull]
        public DateTime? ChangeDate { get => changeDate; set => changeDate = value; }

        
        public EmailType EmailType { get; set; }
    }
}
