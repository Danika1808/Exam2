namespace Application.Validation
{
    public class Result
    {
        public string Content { get; private set; }
        
        public Result(string content)
        {
            Content = content;
        }
    }
}