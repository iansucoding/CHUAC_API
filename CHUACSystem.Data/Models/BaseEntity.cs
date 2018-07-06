using System;
using System.ComponentModel.DataAnnotations;

namespace CHUACSystem.Data.Models
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
