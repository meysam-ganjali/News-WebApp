namespace News.Utility;

public class ResultDto
{
    public bool Status { get; set; }
    public string Message { get; set; }
}

public class ResultDto<TEntity>
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public TEntity Data { get; set; }
}