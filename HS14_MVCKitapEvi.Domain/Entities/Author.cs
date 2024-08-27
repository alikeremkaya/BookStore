using HS14_MVCKitapEvi.Domain.Core.BaseEntities;

namespace HS14_MVCKitapEvi.Domain.Entities
{
    public class Author:AuditableEntity
    {
        public Author()
        {// Books koleksiyonu için bir HashSet<Book> örneği oluşturulur.
         // Bu, Books koleksiyonunun boş bir koleksiyon olarak başlatılmasını sağlar
         // ve böylece null referans hatası oluşmasının önüne geçilir.
            Books =new HashSet<Book>();
        }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        //NAV
        public virtual IEnumerable<Book> Books { get; set; }
  // Yazarın yazdığı kitapların koleksiyonunu temsil eder.
  // Bu özellik, navigasyon özelliği (NAV) olarak adlandırılır ve genellikle ilişkisel veritabanlarda bir tablodan diğerine bağlantı kurmak için kullanılır.
  // Bu durumda, Author ve Book tabloları arasında bir ilişki kurulmuştur.

    }
}
