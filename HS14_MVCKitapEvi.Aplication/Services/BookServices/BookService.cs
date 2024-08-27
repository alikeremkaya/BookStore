
namespace HS14_MVCKitapEvi.Aplication.Services.BookServices;
public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<IDataResult<BookDTO>> CreateAsync(BookCreateDTO bookCreateDTO)
    {
        if (await _bookRepository.AnyAsync(x => x.Name.ToLower() == bookCreateDTO.Name.ToLower()))
        {
            return new ErrorDataResult<BookDTO>("Kitap Ekleme Başarısız");
        }
        var newbook = bookCreateDTO.Adapt<Book>();
        await _bookRepository.AddAsync(newbook);
        await _bookRepository.SaveChangesAsync();
        return new SuccessDataResult<BookDTO>(newbook.Adapt<BookDTO>(), "Kitap Ekleme Başarılı");
        ;
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var deletingBook = await _bookRepository.GetByIdAsync(id);
        if (deletingBook == null)

        {
            return new ErrorResult("Silinecek veri bulunamadı");


        }
        await _bookRepository.DeleteAsync(deletingBook);
        await _bookRepository.SaveChangesAsync();

        return new SuccessResult("Yazar silme işlemi başarılı");
    }

    public async Task<IDataResult<List<BookListDTO>>> GetAllAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        if (books.Count() <= 0)
        {
            return new ErrorDataResult<List<BookListDTO>>(books.Adapt<List<BookListDTO>>(), "Listelenecek Kitap bulunamamaktadır.");
        }
        return new SuccessDataResult<List<BookListDTO>>(books.Adapt<List<BookListDTO>>(), "Kitap Listeleme başarılı.");
    }

    public async Task<IDataResult<List<BookListDTO>>> GetAllForProfileUserAsync()
    {
        var books = await _bookRepository.GetAllAsync(x => x.IsAvailable == true);
        if (books.Count()<=0)
        {
            return new ErrorDataResult<List<BookListDTO>>(books.Adapt <List< BookListDTO >>(), "Listelenecek Kitap Bulunamamaktadır.");
        }
        return new SuccessDataResult<List<BookListDTO>>(books.Adapt<List<BookListDTO>>(), "Kitap listeleme işlemi başarılı");
    }

    public async Task<IDataResult<BookDTO>> GetByIdAsync(Guid id)
    {
        var author = await _bookRepository.GetByIdAsync(id);
        if (author == null)
        {
            return new ErrorDataResult<BookDTO>("Listelenecek yazar bulunamadı!");
        }
        var authorDto = author.Adapt<BookDTO>();
        return new SuccessDataResult<BookDTO>(authorDto, " Yazar listeleme işlemi  başarılı!");
    }

    public async Task<IDataResult<BookDTO>> UpdateAsync(BookUpdateDTO bookUpdateDTO)
    {
        var bookingBook = await _bookRepository.GetByIdAsync(bookUpdateDTO.Id);
        if (bookingBook is null)
        {
            return new ErrorDataResult<BookDTO>("Güncellenecek yazar bulunamadı!");
        }
        var updatedBook = bookUpdateDTO.Adapt(bookingBook);
        await _bookRepository.UpdateAsync(updatedBook);
        await _bookRepository.SaveChangesAsync();
        return new SuccessDataResult<BookDTO>(updatedBook.Adapt<BookDTO>(), "Yazar Güncelleme Başarılı!");

    }
}
