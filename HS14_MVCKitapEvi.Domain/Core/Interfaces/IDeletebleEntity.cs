
namespace HS14_MVCKitapEvi.Domain.Core.Interfaces
{
    public interface IDeletebleEntity
    {
        public string? DeletedBy { get; set; }


        public DateTime? DeletedDate { get; set; }


    }
}
