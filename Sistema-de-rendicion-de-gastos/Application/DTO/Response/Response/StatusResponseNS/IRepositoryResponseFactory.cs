
namespace Application.Dto.Response.StatusResponseNS
{
    public interface IRepositoryResponseFactory
    {
        public StatusResponse DbUpdateException();
        public StatusResponse DbUpdateConcurrencyException();
        public StatusResponse DbEntityValidationException();
        public StatusResponse NotSupportedException();
        public StatusResponse ObjectDisposedException();
        public StatusResponse InvalidOperationException();
        public StatusResponse Ok();       
    }
}
