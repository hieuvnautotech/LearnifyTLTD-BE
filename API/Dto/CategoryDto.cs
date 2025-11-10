using System;


namespace API.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }     // hoặc Guid nếu bạn dùng Guid
        public string Name { get; set; } = string.Empty;
    }
}