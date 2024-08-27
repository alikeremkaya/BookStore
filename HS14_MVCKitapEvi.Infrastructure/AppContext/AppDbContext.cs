using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using HS14_MVCKitapEvi.Domain.Core.BaseEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using HS14_MVCKitapEvi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;

namespace HS14_MVCKitapEvi.Infrastructure.AppContext;
//IdentityTabloları: AppDbContext sınıfı, IdentityDbContext<IdentityUser, IdentityRole, string> üzerinden türetilmiştir.
//Bu, ASP.NET Core Identity'nin kullanıcı (IdentityUser) ve roller (IdentityRole) için otomatik olarak yönettiği tabloları içerir.
//Ayrıca, kullanıcı kimlikleri string tipindedir. Bu tablolar, kullanıcı yönetimi ve yetkilendirme işlemlerini basitleştirir.
//Özel Tablolar: AppDbContext sınıfı, ayrıca Admin, ProfileUser, Category, Author, Publisher ve Book gibi özel tabloları temsil eden DbSet özelliklerini tanımlar.Bu özellikler,
//Entity Framework Core aracılığıyla bu tablolara erişim sağlar.Örneğin, Admins özelliği, Admin tablosuna erişim sağlar.
public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    private readonly IHttpContextAccessor _contextAccessor;

    //Bu yapıcı metot, DbContextOptions<AppDbContext> ve IHttpContextAccessor parametrelerini alır.
    //DbContextOptions<AppDbContext> parametri, veritabanı bağlantısının yapılandırmasını içerir.
    //IHttpContextAccessor parametri, mevcut HTTP bağlamına erişim sağlar,
    //bu da kullanıcı bilgilerini ve diğer HTTP özel durumlarını yakalamak için kullanılır.
    //_contextAccessor alanı, HTTP bağlamına erişmek için kullanılır.

    public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor contextAccessor) : base(options)
    {
        _contextAccessor = contextAccessor;
    }

    public const string DevConnectionString = "AppConnectionDev";

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    //Bu yapıcı metot, yalnızca DbContextOptions<AppDbContext> parametrelerini alır.
    //Bu, uygulamanın başka bir yerde IHttpContextAccessor'ı sağlamadan AppDbContext'yi başlatmak için kullanılır.


    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<ProfileUser> ProfileUsers { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Publisher> Publishers { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    //virtual anahtar kelimesi, Entity Framework Core'ın bu özelliklere erişimini dinamik olarak değiştirebilmesi için gereklidir.


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //ApplyConfigurationsFromAssembly metodu, model yapılandırmalarını içeren assembly'deki tüm yapılandırma sınıflarını bulup uygular.
        base.OnModelCreating(builder);
    }



    public override int SaveChanges()
    {
        SetBaseProperties();
        return base.SaveChanges();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetBaseProperties();
        return base.SaveChangesAsync(cancellationToken);
    }
    //SetIfDeleted, SetIfModified ve SetIfAdded yöntemleri,
    //BaseEntity türündeki kayıtların durumuna bağlı olarak, statüsünü, güncelleme tarihini,
    //güncelleme yapan kullanıcıyı ve benzeri bilgileri ayarlar.
    private void SetBaseProperties()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        var userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "UserBulunamadı";
        foreach (var entry in entries)
        {
            SetIfAdded(entry, userId);
            SetIfModified(entry, userId);
            SetIfDeleted(entry, userId);
        }
    }

    private void SetIfDeleted(EntityEntry<BaseEntity> entry, string userId)
    {
        if (entry.State != EntityState.Deleted)
        {
            return;
        }
        if (entry.Entity is not AuditableEntity entity)
        {
            return;

        }
        entry.State = EntityState.Modified;
        entry.Entity.Status = Domain.Enums.Status.Deleted;
        entity.DeletedDate = DateTime.Now;
        entity.DeletedBy = userId;

    }

    private void SetIfModified(EntityEntry<BaseEntity> entry, string userId)
    {
        if (entry.State == EntityState.Modified)
        {
            entry.Entity.Status = Domain.Enums.Status.Updated;
            entry.Entity.UpdatedBy = userId;
            entry.Entity.UpdatedDate = DateTime.Now;

        }
    }

    private void SetIfAdded(EntityEntry<BaseEntity> entry, string userId)
    {
        if (entry.State == EntityState.Added)
        {
            entry.Entity.Status = Domain.Enums.Status.Created;
            entry.Entity.CreatedBy = userId;
            entry.Entity.CreatedDate = DateTime.Now;

        }
    }
}
