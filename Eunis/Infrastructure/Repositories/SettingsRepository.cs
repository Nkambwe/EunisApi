using Eunis.Data;
using Eunis.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eunis.Infrastructure.Repositories {
    public class SettingsRepository : Repository<Settings>, ISettingsRepository {

        private readonly EunisDbContext _context;
        public SettingsRepository(EunisDbContext context)
            : base(context) {
        }
    }
}
