namespace Social.Shared.Commands
{
    public abstract class Result
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public bool Success => Status >= 200 && Status <= 299;
        public IList<string> Errors { get; set; }
    }
}
