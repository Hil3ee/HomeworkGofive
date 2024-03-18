namespace Homework.Models.Dtos.Request
{
    public class EditeUserDtoRequest
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string? phone { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string roleid { get; set; }
        public PermissionDtoRequest[] permission { get; set; }
    }


}
