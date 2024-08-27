using HS14_MVCKitapEvi.Domain.Core.BaseEntities;


namespace HS14_MVCKitapEvi.Domain.Entities;

public class Category:AuditableEntity
{
    public Category()
    {
        Books = new HashSet<Book>();
    }
    public string? Name { get; set; }
    //Kategorinin adı. Bu özellik nullable (string?) tipindedir, yani boş bırakılabilir.

    //Nav
    public virtual IEnumerable<Book> Books { get; set; }
    //Kategorideki tüm kitapların koleksiyonunu temsil eder.
    //Bu özellik, navigasyon özelliği (NAV) olarak adlandırılır ve genellikle ilişkisel veritabanlarda bir tablodan diğerine bağlantı kurmak için kullanılır.
    //Bu durumda, Category ve Book tabloları arasında bir ilişki kurulmuştur.
}
