using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechCodeLib.DTOS;

namespace TechCodeLib.Services.Contract
{
    public interface IAppUserService
    {
        Task<IEnumerable<AppUserDTO>> GetAppUserDTOs();
    }
}
