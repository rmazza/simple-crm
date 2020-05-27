using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SimpleCRM.Models
{
    [Table("customer")]
    public class Customer
    {
        private Guid id;
        private string firstName;
        private string middleName;
        private string lastName;
        private Guid addUser;
        private DateTime addDate = DateTime.Now;
        private Guid? changeUser;
        private DateTime? changeDate;

        [Column("cst_id")]
        [Key]
        public Guid CustomerId { get => id; set => id = value; }

        [Column("cst_first_name")]
        public string FirstName { get => firstName; set => firstName = value; }

        [Column("cst_middle_name")]
        public string MiddleName { get => middleName; set => middleName = value; }

        [Column("cst_last_name")]
        public string LastName { get => lastName; set => lastName = value; }

        [Column("cst_add_user")]
        public Guid AddUser { get => addUser; set => addUser = value; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cst_add_date")]
        public DateTime AddDate { get => addDate; set => addDate = value; }

        [Column("cst_change_user")]
        [AllowNull]
        public Guid? ChangeUser { get => changeUser; set => changeUser = value; }

        [Column("cst_change_date")]
        [AllowNull]
        public DateTime? ChangeDate { get => changeDate; set => changeDate = value; }

        public List<EmailAddress> EmailAddresses { get; } = new List<EmailAddress>();
    }
}
