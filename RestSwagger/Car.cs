namespace RestSwagger;

public class Car
{
    public Guid Id { get; set; }
    public DateTimeOffset? StartRent { get; set; }
    public DateTimeOffset? EndRent { get; set; }
    public bool IsRent => StartRent != null && EndRent == null;
}