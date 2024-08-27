namespace HS14_MVCKitapEvi.Aplication.Services.BookServices;

public interface IBookService
{
    Task<IDataResult<List<BookListDTO>>> GetAllAsync();

    //Task<IDataResult<List<BookListDTO>>> döndürür.
    //Burada, IDataResult<T> genel bir sonuç türüdür ki bu da bir veri seti ile birlikte bir durum bilgisi içerir.
    //List<BookListDTO> ise, dönen kitap listesini temsil eder.

    Task<IDataResult<BookDTO>> CreateAsync(BookCreateDTO bookCreateDTO);

    //Bu yöntem, yeni bir kitap oluşturmak için kullanılır.
    //Bir BookCreateDTO nesnesi alır ve sonucu Task<IDataResult<BookDTO>> olarak döndürür.
    //Bu, yeni oluşturulan kitabı ve oluşturma sonucunu içeren bir nesneyi döndürür.

    Task<IResult> DeleteAsync(Guid id);
    // Bu yöntem, belirtilen ID'ye sahip kitabı silmek için kullanılır.
    // Guid id, silinecek kitabinin benzersiz kimliğini belirtir.
    // Sonuç, işlem sonucunu Task<IResult> olarak döndürür.

    Task<IDataResult<BookDTO>> GetByIdAsync(Guid id);

    Task<IDataResult<BookDTO>> UpdateAsync(BookUpdateDTO bookUpdateDTO);

    Task<IDataResult<List<BookListDTO>>> GetAllForProfileUserAsync();

}
