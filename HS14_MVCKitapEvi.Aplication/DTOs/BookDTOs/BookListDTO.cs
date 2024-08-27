

namespace HS14_MVCKitapEvi.Aplication.DTOs.BookDTOs
{
    public class BookListDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfPublish { get; set; }
        public bool IsAvailable { get; set; }


        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }
    }
}
