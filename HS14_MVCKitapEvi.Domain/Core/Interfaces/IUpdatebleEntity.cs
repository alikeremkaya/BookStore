
namespace HS14_MVCKitapEvi.Domain.Core.Interfaces
{
    public interface IUpdatebleEntity:ICreatableEntity
    {
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
