using SofthouseDev.Api.Models.Request;
using SofthouseDev.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofthouseDev.Api.Persistence
{
    public interface IUserRepository
    {
        UserProfile Authenticate(LoginClient request);
        UserProfile Registration(RegisterClient request);
    }
}
