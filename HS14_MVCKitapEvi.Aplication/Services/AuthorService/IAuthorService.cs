

namespace HS14_MVCKitapEvi.Aplication.Services.AuthorService;

public interface IAuthorService
{
    Task<IDataResult<AuthorDTO>> CreateAsync(AuthorCreateDTO authorCreateDTO);
    Task<IDataResult<List<AuthorListDTO>>> GetAllAsync();
    Task<IResult> DeleteAsync(Guid id);
    Task<IDataResult<AuthorDTO>> GetByIdAsync(Guid id);
    Task<IDataResult<AuthorDTO>> UpdateAsync(AuthorUpdateDTO authorUpdateDTO);
}
