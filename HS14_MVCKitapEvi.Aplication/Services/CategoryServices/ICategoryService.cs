

namespace HS14_MVCKitapEvi.Aplication.Services.CategoryServices;

public interface  ICategoryService
{
    Task<IDataResult<CategoryDTO>> CreateAsync(CategoryCreateDTO categoryCreateDTO);
    Task<IDataResult<List<CategoryListDTO>>> GetAllAsync();
    Task<IResult>DeleteAsync(Guid id);
    Task<IDataResult<CategoryDTO>> GetByIdAsync(Guid id);
    Task<IDataResult<CategoryDTO>> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO);


    
}
