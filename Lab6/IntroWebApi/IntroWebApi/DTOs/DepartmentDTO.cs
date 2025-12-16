namespace IntroWebApi.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; } // ? indicates that the property can be null
    }
}
