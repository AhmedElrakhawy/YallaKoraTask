using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace YallaKora.API.Models
{
    public partial class Role
    {
        public Role()
        {
            UserMasters = new HashSet<UserMaster>();
        }

        [Key]
        public int RoleId { get; set; }
        [StringLength(100)]
        public string RoleName { get; set; }

        [InverseProperty(nameof(UserMaster.Role))]
        public virtual ICollection<UserMaster> UserMasters { get; set; }
    }
}
