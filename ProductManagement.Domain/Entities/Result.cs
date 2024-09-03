namespace ProductManagement.Domain.Entities;

public class Result<T>
{
    public T? Value { get; set; }
    public bool IsSuccess { get; set; }
    public List<string>? Errors { get; set; }
}
