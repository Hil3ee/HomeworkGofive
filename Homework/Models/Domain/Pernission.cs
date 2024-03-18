using System.ComponentModel.DataAnnotations;

namespace Homework.Models.Domain
{
    public class Permission
    {
        [Key]
        public string permissionId { get; set; }
        public string permissionName { get; set; }
        public bool isReadable { get; set; }
        public bool isWritable { get; set; }
        public bool isDeletable { get; set; }
    }
}
