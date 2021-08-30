using SimCrm.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SimCrm.Domain.Entities
{

    [Table("customer")]
    public class Customer : IDatabaseTable
    {
        private Guid id;
        private Int64 userId;
        private string firstName;
        private string middleName;
        private string lastName;
        private DateTime? dateOfBirth;
        private Guid addUser;
        private DateTime addDate = DateTime.Now;
        private Guid? changeUser;
        private DateTime? changeDate;
        //private readonly ApplicationUser _user;

        [Column("cst_id")]
        [Key]
        public Guid Id { get => id; set => id = value; }

        [Column("cst_user_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 UserId { get => userId; set => userId = value; }

        [Column("cst_first_name")]
        [Required]
        public string FirstName { get => firstName; set => firstName = value; }

        [Column("cst_middle_name")]
        public string MiddleName { get => middleName; set => middleName = value; }

        [Column("cst_last_name")]
        [Required]
        public string LastName { get => lastName; set => lastName = value; }

        [Column("cst_dob")]
        public DateTime? DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }

        [Column("cst_add_user")]
        public Guid AddUser { get => addUser; set => addUser = value; }

        [Column("cst_add_date")]
        public DateTime AddDate { get => addDate; set => addDate = value; }

        [Column("cst_change_user")]
        //[AllowNull]
        public Guid? ChangeUser { get => changeUser; set => changeUser = value; }

        [Column("cst_change_date")]
        //[AllowNull]
        public DateTime? ChangeDate { get => changeDate; set => changeDate = value; }

        //public List<EmailAddress> EmailAddresses { get; } = new List<EmailAddress>();

        //public List<PhoneNumber> PhoneNumbers { get; } = new List<PhoneNumber>();

        [JsonConstructor]
        public Customer()
        {

        }
    }
}
