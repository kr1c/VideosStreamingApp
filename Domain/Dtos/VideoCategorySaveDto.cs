using System.Collections.Generic;

namespace Domain.Dtos
{
    public class VideoCategorySaveDto
    {
        public ICollection<CategoryDto> Categories { get; set; }
    }

    public class CategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
