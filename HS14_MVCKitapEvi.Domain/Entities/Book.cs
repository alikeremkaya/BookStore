using HS14_MVCKitapEvi.Domain.Core.BaseEntities;

namespace HS14_MVCKitapEvi.Domain.Entities;

public class Book:AuditableEntity
{
    public string Name { get; set; }
    public DateTime DateOfPublish { get; set; }
    //Kitabın yayın tarihi.
    public bool IsAvailable { get; set; }
    //Kitabın mevcut olup olmadığına dair bir boolean değer.




    //*Nav//kitabın kategori, yazar ve yayıncısına ait bilgileri temsil etmek için navigasyon özellikleri (NAV) içerir

    public Guid CategoryId { get; set; }
    public virtual  Category Category { get; set; }
    public Guid    AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public Guid PublisherId  { get; set; }
    public virtual Publisher Publisher { get; set; }


    //Bu navigasyon özellikleri, Entity Framework gibi ORM çerçeveleri kullanılarak
    //veritabanı tabloları arasındaki ilişkileri temsil etmek için kullanılır.
    //Bu sayede, bir kitabın kategorisi,
    //yazarı ve yayıncısı gibi ilişkili verileri doğrudan Book nesnesi üzerinden erişilebilir
    //ve yönetilebilir hale getirilmiş olur.
}
