

namespace HS14_MVCKitapEvi.Aplication.Services.PublisherServices;

public interface IPublisherService
{
    Task<IDataResult<PublisherDTO>> CreateAsync(PublisherCreateDTO publisherCreateDTO);
    Task<IDataResult<List<PublisherListDTO>>> GetAllAsync();
    Task<IResult> DeleteAsync(Guid id);
    Task<IDataResult<PublisherDTO>> GetByIdAsync(Guid id);
    Task<IDataResult<PublisherDTO>> UpdateAsync(PublisherUpdateDTO publisherUpdateDTO);
}
