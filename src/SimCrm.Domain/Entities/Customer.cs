using SimCrm.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCrm.Domain.Entities
{

    [Table("customer")]
    public class Customer : IDatabaseTable
    {
        [Column("cst_key")]
        [Key]
        public Guid Id { get; set; }

        [Column("cst_user_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 UserId { get; set; }

        [Column("cst_first_name")]
        [Required]
        public string FirstName { get; set; }

        [Column("cst_middle_name")]
        public string MiddleName { get; set; }

        [Column("cst_last_name")]
        [Required]
        public string LastName { get; set; }

        [Column("cst_dob")]
        public DateTime? DateOfBirth { get; set; }

        [Column("cst_add_user")]
        public Guid AddUser { get; set; }

        [Column("cst_add_date")]
        public DateTime AddDate { get; set; }

        [Column("cst_change_user")]
        public Guid? ChangeUser { get; set; }

        [Column("cst_change_date")]
        public DateTime? ChangeDate { get; set; }

        public List<EmailAddress> EmailAddresses { get; set; }

        //public List<PhoneNumber> PhoneNumbers { get; } = new List<PhoneNumber>();

    }
}
