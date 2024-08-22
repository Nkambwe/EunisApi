using AutoMapper;
using Eunis.Helpers;

namespace Eunis.Infrastructure.Services {
    public interface IService {

        void Adapter(IMapper mapper, IServiceLogger logger);
    }
}
