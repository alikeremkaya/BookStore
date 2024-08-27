using HS14_MVCKitapEvi.Domain.Enums;

namespace HS14_MVCKitapEvi.Domain.Core.Interfaces
{
    public  interface IEntity
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
    }
}
