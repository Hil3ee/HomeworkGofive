namespace Homework.Models.Dtos.Response
{
    public class DeleteUserDtoResponse
    {
        public Status Status { get; set; }
        public DeleteData Data { get; set; }
    }

    public class DeleteData 
    {
        public bool result { get; set; }
        public string message { get; set; }
    }
}
