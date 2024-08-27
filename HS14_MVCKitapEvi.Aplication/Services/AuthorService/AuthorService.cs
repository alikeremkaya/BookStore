


namespace HS14_MVCKitapEvi.Aplication.Services.AuthorService;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IDataResult<AuthorDTO>> CreateAsync(AuthorCreateDTO authorCreateDTO)
    {
        if (await _authorRepository.AnyAsync(x => x.Name.ToLower() == authorCreateDTO.Name.ToLower()))

        {
            return new ErrorDataResult<AuthorDTO>("Mevcut yazar sisteminde kayıtlı!");

        }
        var newAuthor = authorCreateDTO.Adapt<Author>();
        await _authorRepository.AddAsync(newAuthor);
        await _authorRepository.SaveChangesAsync();
        var authorDTO = newAuthor.Adapt<AuthorDTO>();
        return new SuccessDataResult<AuthorDTO>(authorDTO, " Yazar Ekleme Başarılı!");
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var deletingAuthor = await _authorRepository.GetByIdAsync(id);
        if (deletingAuthor == null)
        {
            return new ErrorResult("Silinecek veri bulunamadı");
        }
        await _authorRepository.DeleteAsync(deletingAuthor);
        await _authorRepository.SaveChangesAsync();
        return new SuccessResult("Yazar silme işlemi başarılı");
    }

    public async Task<IDataResult<List<AuthorListDTO>>> GetAllAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        var authorsListDTOs = authors.Adapt<List<AuthorListDTO>>();
        if (authors.Count() <= 0)
        {
            return new ErrorDataResult<List<AuthorListDTO>>(authorsListDTOs, "Listelenecek Yazar bulunamadı");
        }

        return new SuccessDataResult<List<AuthorListDTO>>(authorsListDTOs, "Yazar Listeleme Başarılı ");
    }

    public async Task<IDataResult<AuthorDTO>> GetByIdAsync(Guid id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author == null)
        {
            return new ErrorDataResult<AuthorDTO>("Listelenecek yazar bulunamadı!");
        }
        var authorDto = author.Adapt<AuthorDTO>();
        return new SuccessDataResult<AuthorDTO>(authorDto, " Yazar listeleme işlemi  başarılı!");
    }

    public async Task<IDataResult<AuthorDTO>> UpdateAsync(AuthorUpdateDTO authorUpdateDTO)
    {
        var updateingAuthor = await _authorRepository.GetByIdAsync(authorUpdateDTO.Id);
        if (updateingAuthor is null)
        {
            return new ErrorDataResult<AuthorDTO>("Güncellenecek yazar bulunamadı!");
        }
        var updatedAuthor = authorUpdateDTO.Adapt(updateingAuthor);
        await _authorRepository.UpdateAsync(updatedAuthor);
        await _authorRepository.SaveChangesAsync();
        return new SuccessDataResult<AuthorDTO>(updatedAuthor.Adapt<AuthorDTO>(), "Yazar Güncelleme Başarılı!");
    }
}
