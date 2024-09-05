using Eunis.Data.Models;

namespace Eunis.Infrastructure.Services {
    public interface ISettingService: IService {
        Settings FindByParameter(string parameterName);
        Task<Settings> FindByParameterAsync(string parameterName);
    }
}
