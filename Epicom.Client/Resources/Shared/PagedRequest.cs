namespace Epicom.Client.Resources.Shared
{
    public class PagedRequest
    {
        public PagedRequest()
        {
            Limit = 30;
        }

        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
