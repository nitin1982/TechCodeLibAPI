using System;
using System.Threading.Tasks;
using TechCodeLib.DAL;
using TechCodeLib.DAL.Entities;
using TechCodeLib.Repositories.Contract;

namespace TechCodeLib.Repositories
{
    public class TechCodeLibUoW: IDisposable
    {
        private readonly TechCodeLibContext _context;
        private ITechCodeLibRepository<AppUser> _appUserRepository;
        private ITechCodeLibRepository<Course> _courseRepository;
        //private ITechCodeLibRepository<SectionVideo> _sectionVideoRepository;
            
        public TechCodeLibUoW(TechCodeLibContext context)
        {
            _context = context;
        }

        ~TechCodeLibUoW()
        {
            Disposing(false);
        }

        public ITechCodeLibRepository<AppUser> AppUserRepository
        {
            get
            {
                if (_appUserRepository == null)
                    _appUserRepository = new TechCodeLibRepository<AppUser>(_context);
                return _appUserRepository;
            }
        }

        public ITechCodeLibRepository<Course> CourseRepository
        {
            get
            {
                if (_courseRepository == null)
                    _courseRepository = new TechCodeLibRepository<Course>(_context);
                return _courseRepository;
            }
        }

        

       

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool _disposed;
        protected virtual void Disposing(bool disposing)
        {
            if (disposing)
            {
                if (!_disposed)
                {
                    _context.Dispose();
                }
            }

            this._disposed = true;
        }

        public void Dispose()
        {
            Disposing(true);
            GC.SuppressFinalize(this);
        }
    }
}
