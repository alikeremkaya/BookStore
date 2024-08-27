


namespace HS14_MVCKitapEvi.Aplication.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IDataResult<CategoryDTO>> CreateAsync(CategoryCreateDTO categoryCreateDTO)
        {
            if (await _categoryRepository.AnyAsync(x => x.Name.ToLower() == categoryCreateDTO.Name.ToLower()))
            {
                return new ErrorDataResult<CategoryDTO>("Mevcut kategori Sistemde Kayıtlı!");
            }
            var newCategory = categoryCreateDTO.Adapt<Category>();
            await _categoryRepository.AddAsync(newCategory);
            await _categoryRepository.SaveChangesAsync();
            var categoryDTO = newCategory.Adapt<CategoryDTO>();
            return new SuccessDataResult<CategoryDTO>(categoryDTO, "Kayıt işlemi başarılı !");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingCategory = await _categoryRepository.GetByIdAsync(id);
            if (deletingCategory == null)
            {
                return new ErrorResult("Silinecek veri Bulunamadı");
            }
            await _categoryRepository.DeleteAsync(deletingCategory);
            await _categoryRepository.SaveChangesAsync();
            return new SuccessResult("Kategori  silme işlemi başarılı");
        }

        public async Task<IDataResult<List<CategoryListDTO>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryListDTOs = categories.Adapt<List<CategoryListDTO>>();
            if (categories.Count() <= 0)
            {
                return new ErrorDataResult<List<CategoryListDTO>>(categoryListDTOs,"Listelenecek Kategori bulunamadı");
            }
            
            return new SuccessDataResult<List<CategoryListDTO>>(categoryListDTOs, "Kategori Listeleme Başarılı");
        }

        public async Task<IDataResult<CategoryDTO>> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category is null)
            {
                new ErrorDataResult<CategoryDTO>("Gösterilecek Kategori bulunamadı.");


            }
            var categoryDto = category.Adapt<CategoryDTO>();
            return new SuccessDataResult<CategoryDTO>(categoryDto, "Kategori Gösterme Başarılı");


        }

        public async Task<IDataResult<CategoryDTO>> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO)
        {
            var updatingCategory = await _categoryRepository.GetByIdAsync(categoryUpdateDTO.Id);
            if (updatingCategory is null)
            {
                return new ErrorDataResult<CategoryDTO>("Güncellenecek Kategori Bulunamadı");

            }
            var updatedCategory = categoryUpdateDTO.Adapt(updatingCategory);
            await _categoryRepository.UpdateAsync(updatedCategory);
            await _categoryRepository.SaveChangesAsync();
            return new SuccessDataResult<CategoryDTO>(updatedCategory.Adapt<CategoryDTO>(), "Kategori Güncelleme Başarılı");
        }
    }
}
