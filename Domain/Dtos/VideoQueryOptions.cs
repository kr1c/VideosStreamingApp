using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class VideoQueryOptions
    {
        #region Properties

        public int? Page { get; set; }
        public int? PageSize { get; set; } = 20;
        public string SearchValue { get; set; }
        public short? AgeGroup { get; set; }
        public string VideoType { get; set; }
        public long[] Categories { get; set; }
        public DateTime? AvailabilityFrom { get; set; }
        public DateTime? AvailabilityTo { get; set; }

        #endregion
    }
}
