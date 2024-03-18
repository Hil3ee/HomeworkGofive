using System.ComponentModel.DataAnnotations;

namespace Homework.Models.Domain
{
    public class Role
    {
        [Key]
        public string roleId { get; set; }
        public string roleName { get; set; }
        
    }
}
