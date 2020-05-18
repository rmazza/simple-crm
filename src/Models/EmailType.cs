using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SimpleCRM.Models
{
    [Table("email_type")]
    public class EmailType
    {
        [Key]
        [Column("emt_id")]
        public Guid EmailTypeId { get; set; }

        [Column("emt_type")]
        public string Type { get; set; }

        [Column("emt_add_user")]
        public string AddUser { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("emt_add_date")]
        public DateTime AddDate { get; set; }

        [Column("emt_change_user")]
        [AllowNull]
        public string ChangeUser { get; set; }

        [Column("emt_change_date")]
        [AllowNull]
        public DateTime ChangeDate { get; set; }

    }
}
