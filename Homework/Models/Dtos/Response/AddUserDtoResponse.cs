using Homework.Models.Domain;

namespace Homework.Models.Dtos.Response
{
    public class AddUserDtoResponse
    {
        public Status Status { get; set; }
        public DataAdduserResponse[] Data { get; set; }
    }

    public class DataAdduserResponse 
    {
        public string userid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string? phone { get; set; }
        public RoleAddResponse role { get; set; }
        public string username { get; set; }
        public PermissionAddResponse[] permisson { get; set; }
    }
    public class PermissionAddResponse 
    {
        public string permissionId { get; set; }
        public string permissionName { get; set; }
    }

    public class RoleAddResponse
    {
        public string roleId { get; set;}
        public string roleName { get; set; }
    }

}
