namespace HS14_MVCKitapEvi.Domain.Utilities.Interfaces;

public interface IResult
{
    public bool IsSuccess { get; set; }
    public string Messages { get; set; }
}
//Bu, kodunuzun esnekliğini artırır ve farklı sınıfların benzer davranışları paylaşmalarını sağlar.
//Ayrıca, arayüzler sayesinde, bir sınıfın veya struct'un hangi özellikleri taşıdığını açıkça belirtmiş olursunuz,
//bu da kodunuzun daha anlaşılır olmasını sağlar.
