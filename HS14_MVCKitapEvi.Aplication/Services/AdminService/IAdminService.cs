

namespace HS14_MVCKitapEvi.Aplication.Services.AdminService;

public interface IAdminService
{
    Task<IDataResult<List<AdminListDTO>>> GetAllAsync();

    Task<IDataResult<AdminDTO>> CreateAsync(AdminCreateDTO adminCreateDTO);


    Task<IResult> DeleteAsync(Guid id);

    Task<IDataResult<AdminDTO>> GetByIdAsync(Guid id);

    Task<IDataResult<AdminDTO>> UpdateAsync(AdminUpdateDTO adminUpdateDTO);

}
