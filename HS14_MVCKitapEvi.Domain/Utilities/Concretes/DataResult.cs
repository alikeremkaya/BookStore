using HS14_MVCKitapEvi.Domain.Utilities.Interfaces;
namespace HS14_MVCKitapEvi.Domain.Utilities.Concretes;

public class DataResult<T> : Result, IDataResult<T> where T : class
{
    public T? Data { get; }
    public DataResult(T data, bool isSuccess) : base(isSuccess)
    {
//Bu constructor, data ve isSuccess parametrelerini alır ve Result sınıfının iki parametreli constructorunu çağırır.(base(isSuccess)).
//Ardından, Data özelliği ile data parametresini ayarlar.
//Bu constructor, DataResult<T> nesnesinin oluşturulduğu anda belirtilen bir değerde başarılı olup olmadığını ve başarılı ise hata mesajlarını belirlemek için kullanılır.
        Data = data;
    }
    public DataResult(T data, bool isSuccess, string message) : base(isSuccess, message)
    {

//Bu constructor, data, isSuccess ve message parametrelerini alır
//ve Result sınıfının çift parametreli constructorunu çağırır
//(base(isSuccess, message)). Ardından, Data özelliği ile data parametresini ayarlar.
//Bu constructor, DataResult<T> nesnesinin oluşturulduğu anda belirtilen bir değerde başarılı olup olmadığını ve başarılı ise hata mesajlarını belirlemek için kullanılır.
        Data = data;



    }
}
