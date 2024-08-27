using HS14_MVCKitapEvi.Domain.Core.BaseEntities;


namespace HS14_MVCKitapEvi.Domain.Entities;

public class Publisher:AuditableEntity
{
    public Publisher()
    {
        Books= new HashSet<Book>();
    }
    public string Name { get; set; }
    public string Address { get; set; }

    //NAV
    public virtual IEnumerable<Book> Books { get; set; }
    //Yayıncının yayınladığı tüm kitapların koleksiyonunu temsil eder.
    //Bu özellik, navigasyon özelliği (NAV) olarak adlandırılır ve genellikle ilişkisel veritabanlarda bir tablodan diğerine bağlantı kurmak için kullanılır.
    //Bu durumda, Publisher ve Book tablaları arasında bir ilişki kurulmuştur.
}
