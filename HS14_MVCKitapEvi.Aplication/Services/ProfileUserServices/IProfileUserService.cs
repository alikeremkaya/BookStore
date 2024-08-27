

namespace HS14_MVCKitapEvi.Aplication.Services.ProfileUserServices;

public interface IProfileUserService
{

    Task<IDataResult<List<ProfileUserListDTO>>>GetAllAsync();


    Task<IDataResult<ProfileUserDTO>>CreateAsync(ProfileUserCreateDTO profileUserCreateDTO);


    Task <IResult> DeleteAsync(Guid id);


    Task<IDataResult<ProfileUserDTO>> GetByIdAsync(Guid id);



    Task<IDataResult<ProfileUserDTO>> UpdateAsync(ProfileUserUpdateDTO profileUserUpdateDTO);


}
