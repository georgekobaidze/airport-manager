using AirportManager.API.Models;
using AirportManager.API.Services.Interfaces;

namespace AirportManager.API.Services.Implementations;

public class UserService : IUserService
{
    public User ValidateUserCredentials(string userName, string password)
    {
        // TODO: this is a dummy service and will be implemented later.

        var user = new User
        {
            Id = 1,
            Email = "user@airportmanagertest.com",
            FirstName = "Giorgi",
            LastName = "Kobaidze"
        };

        return user;
    }
}