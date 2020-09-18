namespace Domain.Entities
{
    public class VideoImage
    {
        #region Properties

        public long Id { get; set; }
        public string Url { get; set; }

        public long VideoId { get; set; }
        public int VideoImageTypeId { get; set; }

        public Video Video { get; set; }
        public VideoImageType VideoImageType { get; set; }

        #endregion
    }
}
