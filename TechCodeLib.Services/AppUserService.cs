using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechCodeLib.DTOS;
using TechCodeLib.Repositories;
using TechCodeLib.Services.Contract;

namespace TechCodeLib.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly TechCodeLibUoW _uow;
        private readonly IMapper _mapper;
        public AppUserService(TechCodeLibUoW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AppUserDTO>> GetAppUserDTOs()
        {
            var result = await _uow.AppUserRepository.GetAllAsync();
            //return result.Select(x => _mapper.Map<AppUserDTO>(x)).ToList();
            return new List<AppUserDTO>() { new AppUserDTO { Id=1, FirstName = "John", Password = "Smith", Email = "John.Smith@gmail.com", ContactNo = 217343862} };
        }
    }
}
