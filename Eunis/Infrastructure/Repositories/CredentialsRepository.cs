using Eunis.Data;
using Eunis.Data.Models;

namespace Eunis.Infrastructure.Repositories
{
    public class CredentialsRepository : Repository<Credentials>, ICredentialsRepository {

        public CredentialsRepository(EunisDbContext context) 
            : base(context) {
        }

        //public async Task UpdateCredentialAsync(Expression<Func<Credentials, bool>> expression) {
        //    var affectedRows = await _context.Person.Where(expression)
        //         .ExecuteUpdateAsync(updates =>
        //    updates.SetProperty(p => p.IsActive, false));

        //    return affectedRows == 0 ? Results.NotFound() : Results.NoContent();
        //}
    }
}
