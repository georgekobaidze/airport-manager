using AirportManager.API.Models;

namespace AirportManager.API.Services.Interfaces;

public interface IUserService
{
    User ValidateUserCredentials(string userName, string password);
}