using HS14_MVCKitapEvi.Domain.Utilities.Interfaces;
namespace HS14_MVCKitapEvi.Domain.Utilities.Concretes;
public class Result : IResult
{
    public bool IsSuccess { get; set; }
    public string Messages { get; set; }
    public Result()
    {
 //Bu constructor, IsSuccess özelliği için varsayılan değer olarak false ve Messages özelliği için boş bir string (string.Empty) ayarlar.
//Bu, Result nesnesinin oluşturulduğu anda başarısız olduğunu varsayılan olarak belirtir.
        IsSuccess = false;
        Messages = string.Empty;
    }
    public Result(bool isSuccess)
    {
  //Bu constructor, isSuccess parametresi ile IsSuccess özelliğini ayarlar.
 //Bu sayede, Result nesnesinin oluşturulduğu anda belirtilen bir değerde başarılı olup olmadığını belirlemek mümkündür.
        IsSuccess = isSuccess;
    }
    public Result(bool isSuccess, string messages) : this(isSuccess)
    {
  //Bu constructor, isSuccess ve messages parametrelerini alır
 //ve ilk olarak tek parametreli constructor çağrılır (this(isSuccess)).
//Ardından, messages parametresi ile Messages özelliği ayarlanır.
//Bu constructor, Result nesnesinin oluşturulduğu anda belirtilen bir değerde başarılı olup olmadığını ve başarılı ise hata mesajlarını belirlemek için kullanılır.
        Messages = messages;
    }
}
