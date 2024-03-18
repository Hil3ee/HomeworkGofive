using Homework.Models.Domain;

namespace Homework.Models.Dtos.Request
{
    public class AddUserDtoRequest
    {
        public string userid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string? phone { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string roleid { get; set; }
        public PermissionDtoRequest[] permission { get; set; }
    }

    public class PermissionDtoRequest
    {
        public string permissionid { get; set; }
        public bool isReadable { get; set; }
        public bool isWritable { get; set; }
        public bool isDeletable { get; set; }


    }
}
