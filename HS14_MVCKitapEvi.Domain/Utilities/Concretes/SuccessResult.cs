namespace HS14_MVCKitapEvi.Domain.Utilities.Concretes;
public class SuccessResult : Result
{
    public SuccessResult() : base(true) { }
    public SuccessResult(string message) : base(true, message)
    {

    }

}
