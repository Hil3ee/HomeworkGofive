using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework.Models.Domain
{
    public class Adduser
    {
        [Key]
        public string userid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string? phone { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        // Foreign key for Role
        public string roleId { get; set; }

        [ForeignKey("roleId")]
        public Role Role { get; set; }

        // Foreign key for Permission
        public string permissionId { get; set; }

        [ForeignKey("permissionId")]
        public Permission Permission { get; set; }
        public string? createdate { get; set; }
    }
}
