using AppUpdatesManager.Domain.Interfaces;

using AppUpdatesManager.Domain.Entities;
using System.Threading.Tasks;
using AppUpdatesManager.Infrastructure.Data;



namespace AppUpdatesManager.Infrastructure.Repositories
{
    public class AppUpdateRepository : IAppUpdateRepository
    {
        private readonly AppUpdatesManagerDbContext _context;



        public AppUpdateRepository(AppUpdatesManagerDbContext context)
        {
            _context = context;
        }



        async Task<bool> IAppUpdateRepository.AddUpdateAsync(ApplicationUpdate update)
        {
            // Реализация добавления обновления в базу данных
            _context.ApplicationUpdates.Add(update);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
