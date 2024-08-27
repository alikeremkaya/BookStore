

namespace HS14_MVCKitapEvi.Aplication.Services.PublisherServices
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<IDataResult<PublisherDTO>> CreateAsync(PublisherCreateDTO publisherCreateDTO)
        {
            if (await _publisherRepository.AnyAsync(x => x.Name.ToLower() == publisherCreateDTO.Name.ToLower()))
            {
                return new ErrorDataResult<PublisherDTO>("Mevcut kitapevi Sistemde Kayıtlı!");
            }
            var newPublisher = publisherCreateDTO.Adapt<Publisher>();
            await _publisherRepository.AddAsync(newPublisher);
            await _publisherRepository.SaveChangesAsync();
            var publisherDTO = newPublisher.Adapt<PublisherDTO>();
            return new SuccessDataResult<PublisherDTO>(publisherDTO, "Kayıt işlemi başarılı !");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingPublisher = await _publisherRepository.GetByIdAsync(id);
            if (deletingPublisher == null)
            {
                return new ErrorResult("Silinecek veri Bulunamadı");
            }
            await _publisherRepository.DeleteAsync(deletingPublisher);
            await _publisherRepository.SaveChangesAsync();
            return new SuccessResult("kitapevi  silme işlemi başarılı");
        }

        public async Task<IDataResult<List<PublisherListDTO>>> GetAllAsync()
        {
            var publishers = await _publisherRepository.GetAllAsync();
            var publisherListDTOs = publishers.Adapt<List<PublisherListDTO>>();
            if (publishers.Count() <= 0)
            {
                return new ErrorDataResult<List<PublisherListDTO>>(publisherListDTOs, "Listelenecek kitapevi bulunamadı");
            }
            
            return new SuccessDataResult<List<PublisherListDTO>>(publisherListDTOs, "kitapevi Listeleme Başarılı");
            ;
        }

        public async Task<IDataResult<PublisherDTO>> GetByIdAsync(Guid id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);

            if (publisher is null)
            {
                new ErrorDataResult<PublisherDTO>("Gösterilecek kitapevi bulunamadı.");


            }
            var publisherDto = publisher.Adapt<PublisherDTO>();
            return new SuccessDataResult<PublisherDTO>(publisherDto, "kitapevi Gösterme Başarılı");


        }

        public async Task<IDataResult<PublisherDTO>> UpdateAsync(PublisherUpdateDTO publisherUpdateDTO)
        {
            var updatingPublisher = await _publisherRepository.GetByIdAsync(publisherUpdateDTO.Id, false);
            if (updatingPublisher == null)
            {
                return new ErrorDataResult<PublisherDTO>("Güncellenecek Kategori Bulunamadı");
            }

            var updatedPublisher = publisherUpdateDTO.Adapt(updatingPublisher);
            await _publisherRepository.UpdateAsync(updatedPublisher);
            await _publisherRepository.SaveChangesAsync();


            return new SuccessDataResult<PublisherDTO>(updatedPublisher.Adapt<PublisherDTO>(), "Kategori Güncelleme Başarılı");
        }
    }
}
