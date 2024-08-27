

namespace HS14_MVCKitapEvi.Domain.Core.BaseEntities
{
    public class BaseUser:AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IdentityId { get; set; }
    }
}

//Bu sınıf, AuditableEntity adında başka bir sınıftan türetilmiştir.
//BaseUser sınıfı, kullanıcı bilgilerini temsil etmek için dört adet özelliğe sahiptir.