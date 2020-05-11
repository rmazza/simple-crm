using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRM.Models
{
    public class Customer
    {
        private Guid id;
        private string firstName;
        private string middleName;
        private string lastName;
        private string addUser;
        private DateTime addDate = DateTime.Now;
        private string changeUser;
        private DateTime changeDate;

        [Column("cst_id")]
        public Guid Id { get => id; set => id = value; }

        [Column("cst_first_name")]
        public string FirstName { get => firstName; set => firstName = value; }

        [Column("cst_middle_name")]
        public string MiddleName { get => middleName; set => middleName = value; }

        [Column("cst_last_name")]
        public string LastName { get => lastName; set => lastName = value; }

        [Column("cst_add_user")]
        public string AddUser { get => addUser; set => addUser = value; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cst_add_date")]
        public DateTime AddDate { get => addDate; set => addDate = value; }

        [Column("cst_change_user")]
        public string ChangeUser { get => changeUser; set => changeUser = value; }

        [Column("cst_change_date")]
        public DateTime ChangeDate { get => changeDate; set => changeDate = value; }
    }
}
