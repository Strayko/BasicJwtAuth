using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofthouseDev.Api.Models.Response
{
    public record UserProfile(
        string Email,
        string FirstName,
        string LastName,
        string Token);
}
