using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace YallaKora.API.Models
{
    [Table("UserMaster")]
    public partial class UserMaster
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(200)]
        public string Password { get; set; }
        public int? RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("UserMasters")]
        public virtual Role Role { get; set; }
    }
}
