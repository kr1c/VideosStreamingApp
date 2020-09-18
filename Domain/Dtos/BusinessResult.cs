namespace Domain.Dtos
{
    public class BusinessResult
    {
        #region Properties

        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
        public string Message { get; set; }
        public object ObjectResult { get; set; }
        public int Count { get; set; }

        #endregion
    }
}
