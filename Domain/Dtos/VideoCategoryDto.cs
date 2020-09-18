using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class VideoCategoryDto
    {
        public long Id { get; set; }
        public long VideoId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
