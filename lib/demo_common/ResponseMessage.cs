namespace demo_common
{
    public class ResponseMessage
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public object? data { get; set; }
        public int errorcode { get; set; }
    }
}
