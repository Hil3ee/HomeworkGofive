namespace Homework.Models.Dtos.Request
{
    public class GetUserPageDtoRequest
    {
        public string? orderBy { get; set; }
        public string? orderDirection { get; set; }
        public int? pageNumber { get; set; }
        public int? pageSize { get; set; }
        public string? search { get; set; }
    }
}
