


namespace HS14_MVCKitapEvi.Aplication.Services.AdminService;

public class AdminService:IAdminService
{
    private readonly IAccountService _accountService;
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAccountService accountService, IAdminRepository adminRepository)
    {
        _accountService = accountService;
        _adminRepository = adminRepository;
    }

    public async Task<IDataResult<AdminDTO>> CreateAsync(AdminCreateDTO adminCreateDTO)
    {
        // E-posta zaten kullanılıyorsa hata döndür
        if (await _accountService.AnyAsync(x => x.Email == adminCreateDTO.Email))
        {
            return new ErrorDataResult<AdminDTO>("Email Kullanılıyor");
        }
        // Yeni IdentityUser oluştur
        IdentityUser identityUser = new()
        {
            Email = adminCreateDTO.Email,
            NormalizedEmail = adminCreateDTO.Email.ToLowerInvariant(),
            UserName = adminCreateDTO.Email,
            NormalizedUserName = adminCreateDTO.Email.ToUpperInvariant(),
            EmailConfirmed = true
        };

        DataResult<AdminDTO> result = new ErrorDataResult<AdminDTO>();

        // Transaction ve strateji başlat
        var strategy = await _adminRepository.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            var transactionScope = await _adminRepository.BeginTransactionAsync().ConfigureAwait(false);
            try
            {
                // Kullanıcı oluşturma işlemi
                var identityResult = await _accountService.CreateUserAsync(identityUser, Roles.Admin);
                if (!identityResult.Succeeded)
                {
                    result = new ErrorDataResult<AdminDTO>(identityResult.ToString());
                    transactionScope.Rollback();
                    return;
                }

                // AppUser nesnesini DTO'dan dönüştür ve ekle
                var admin = adminCreateDTO.Adapt<Admin>();
                admin.IdentityId = identityUser.Id;
                await _adminRepository.AddAsync(admin);
                await _adminRepository.SaveChangesAsync();

                result = new SuccessDataResult<AdminDTO>("Kullanıcı Ekleme Başarılı");
                transactionScope.Commit();
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<AdminDTO>("Ekleme Başarısız" + ex.Message);
                transactionScope.Rollback();
            }
            finally
            {
                transactionScope.Dispose();
            }
        });
        return result;
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        Result result = new ErrorResult();
        // Transaction ve strateji başlat
        var strategy = await _adminRepository.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            var transactionScope = await _adminRepository.BeginTransactionAsync().ConfigureAwait(false);
            try
            {
                // Silinecek kullanıcıyı ID ile getir
                var deletingUser = await _adminRepository.GetByIdAsync(id);
                if (deletingUser == null)
                {
                    result = new ErrorResult("Silinecek Kullanıcı Bulunamadı");
                    transactionScope.Rollback();
                    return;
                }

                // IdentityUser'ı sil
                var identityResult = await _accountService.DeleteUserAsync(deletingUser.IdentityId);
                if (!identityResult.Succeeded)
                {
                    result = new ErrorResult("Kullanıcı Silme İşlemi Başarısız: " + string.Join(", ", identityResult.Errors.Select(e => e.Description)));
                    transactionScope.Rollback();
                    return;
                }

                // AppUser'ı sil ve değişiklikleri kaydet
                await _adminRepository.DeleteAsync(deletingUser);
                await _adminRepository.SaveChangesAsync();
                result = new SuccessResult("Kullanıcı Silme İşlemi Başarılı");
                transactionScope.Commit();
            }
            catch (Exception ex)
            {
                result = new ErrorResult("Silme İşlemi Başarısız: " + ex.Message);
                transactionScope.Rollback();
            }
            finally
            {
                transactionScope.Dispose();
            }
        });
        return result;
    }

    public async Task<IDataResult<List<AdminListDTO>>> GetAllAsync()
    {
        // Tüm kullanıcıları getir
        var admins = await _adminRepository.GetAllAsync();
        // Kullanıcıları DTO'ya dönüştür
        var adminDTOs = admins.Adapt<List<AdminListDTO>>();
        if (admins.Count() <= 0)
        {
            return new ErrorDataResult<List<AdminListDTO>>(adminDTOs, "Görüntülenecek kullanıcı bulunamadı");
        }
        return new SuccessDataResult<List<AdminListDTO>>(adminDTOs, "Kullanıcı listeleme başarılı");
    }

    public async Task<IDataResult<AdminDTO>> GetByIdAsync(Guid id)
    {
        try
        {
            // Kullanıcıyı ID'si ile veritabanından çek
            var admin = await _adminRepository.GetByIdAsync(id);
            if (admin == null)
            {
                // Kullanıcı bulunamadıysa hata döndür
                return new ErrorDataResult<AdminDTO>("Kullanıcı Bulunamadı");
            }

            // Kullanıcıyı DTO'ya dönüştür
            var adminDTO = admin.Adapt<AdminDTO>();

            // Başarı ile döndür
            return new SuccessDataResult<AdminDTO>(adminDTO, "Kullanıcı Başarıyla Getirildi");
        }
        catch (Exception ex)
        {
            // Herhangi bir hata oluşursa hata mesajı ile döndür
            return new ErrorDataResult<AdminDTO>("Kullanıcı Getirme İşlemi Başarısız: " + ex.Message);
        }
    }

    public async Task<IDataResult<AdminDTO>> UpdateAsync(AdminUpdateDTO adminUpdateDTO)
    {
        DataResult<AdminDTO> result = new ErrorDataResult<AdminDTO>();
        var strategy = await _adminRepository.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            var transactionScope = await _adminRepository.BeginTransactionAsync().ConfigureAwait(false);
            try
            {
                // Güncellenecek Admin kullanıcıyı ID ile getir
                var updatingUser = await _adminRepository.GetByIdAsync(adminUpdateDTO.Id, false);
                if (updatingUser == null)
                {
                    result = new ErrorDataResult<AdminDTO>("Güncellenecek Kullanıcı Bulunamadı");
                    transactionScope.Rollback();
                    return;
                }

                // IdentityUser kaydını getir
                var identityUser = await _accountService.FindByIdAsync(updatingUser.IdentityId);
                if (identityUser == null)
                {
                    result = new ErrorDataResult<AdminDTO>("Güncellenecek Kullanıcıya ait Identity kaydı bulunamadı");
                    transactionScope.Rollback();
                    return;
                }

                // Admin bilgilerini DTO'dan güncelle
                updatingUser = adminUpdateDTO.Adapt(updatingUser);
                await _adminRepository.UpdateAsync(updatingUser);

                // IdentityUser bilgilerini güncelle
                identityUser.Email = adminUpdateDTO.Email;
                identityUser.UserName = adminUpdateDTO.Email;
                identityUser.NormalizedEmail = adminUpdateDTO.Email.ToUpperInvariant();
                identityUser.NormalizedUserName = adminUpdateDTO.Email.ToUpperInvariant();
                var identityResult = await _accountService.UpdateUserAsync(identityUser);
                if (!identityResult.Succeeded)
                {
                    result = new ErrorDataResult<AdminDTO>("Identity bilgilerini güncelleme başarısız: " + string.Join(", ", identityResult.Errors.Select(e => e.Description)));
                    transactionScope.Rollback();
                    return;
                }

                // Değişiklikleri kaydet
                await _adminRepository.SaveChangesAsync();
                result = new SuccessDataResult<AdminDTO>(updatingUser.Adapt<AdminDTO>(), "Kullanıcı Güncelleme Başarılı");
                transactionScope.Commit();
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<AdminDTO>("Güncelleme Başarısız: " + ex.Message);
                transactionScope.Rollback();
            }
            finally
            {
                transactionScope.Dispose();
            }
        });
        return result;
    }
}
