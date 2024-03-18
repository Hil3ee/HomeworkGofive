
using System.Data;

namespace Homework.Models.Dtos.Response
{
    public class RoleDtoResponse
    {
        public Status Status { get; set; }
        public dataRole[] data { get; set; }
    }


    public class dataRole
    {
        public string roleId { get; set; }
        public string rolename { get; set; }
}
}
