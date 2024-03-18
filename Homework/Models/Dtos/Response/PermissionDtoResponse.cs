namespace Homework.Models.Dtos.Response
{
    public class PermissionDtoResponse
    {
        public Status Status { get; set; }
        public PermisstionData[] data { get; set; }

    }

    public class PermisstionData 
    {
        public string permissionId { get; set; }
        public string permissionName { get; set; }
        
    }

}
