namespace HS14_MVCKitapEvi.Domain.Utilities.Concretes;

public class ErrorResult:Result
{
    public ErrorResult(): base(false) { }
    public ErrorResult(string massage) : base(false, massage) { }
}
