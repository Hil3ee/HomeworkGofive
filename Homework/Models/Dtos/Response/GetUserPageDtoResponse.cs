namespace Homework.Models.Dtos.Response
{
    public class GetUserPageDtoResponse
    {
        public DataPage[] dataSource { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
    }

    public class DataPage
    {
        public string UserId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public RoleAddResponse role { get; set; }
        public string username { get; set; }
        public PermissionAddResponse[] permission { get; set; }
        public string createdDate { get; set; }
    }
}
