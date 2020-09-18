namespace Domain.Entities
{
    public class VideoCast
    {
        #region Properties

        public long Id { get; set; }
        public long VideoId { get; set; }
        public long CastPersonId { get; set; }
        public Video Video { get; set; }
        public CastPerson CastPerson { get; set; }

        #endregion
    }
}
