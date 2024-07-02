using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PipeQRTrack.Data;

namespace PipeQRTrack.Services
{
    public class BasicService
    {

        private readonly AzureDbContext _context;

        public BasicService(AzureDbContext context)
        {
            _context = context;
        }
        public async Task<List<T>> GetAll<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<bool> SubmitEntity<T>(T entity) where T : class
        {
            try
            {
                _context.Set<T>().Add(entity); // Use Set<T>() to access DbSet dynamically
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;
                if (sqlException != null)
                {
                    // Log or handle SQL exception
                    Console.WriteLine(sqlException.Message);
                }
                else
                {
                    // Log or handle other exceptions
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }
    }
}
