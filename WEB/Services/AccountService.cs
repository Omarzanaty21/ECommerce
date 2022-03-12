using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WEB.Data;
using WEB.Dtos;
using WEB.Interfaces;
using WEB.Models;
using WEB.ViewModels;

namespace WEB.Services;

public class AccountService : IAccountService
{
    private readonly DatabaseContext _context;

    public AccountService(DatabaseContext context)
    {
        _context = context;
    }

    public object ModelState { get; private set; }

    public async Task<AccountResultResponse> AdminPasswordSignInAsync(AdminViewModel model) 
    {
        var user = await _context.Admins.FirstOrDefaultAsync(x => x.Email == model.Email);

        if (user != null)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);
            
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            
            for (int i = 0; i < user.PasswordHash.Length; i++)
            {
                if (computeHash[i] != user.PasswordHash[i]) return new AccountResultResponse(false);
            }

            var claims = SetClaims(user);

            var claimsIdentity = new ClaimsIdentity(claims, "admin");
            var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);

            return new AccountResultResponse(true, claimsPrinciple, user);
        }

        return new AccountResultResponse(false);
    }

    public UserHashAndSalt HashPassword(UserViewModel model)
    {
        using var hmac = new HMACSHA512();

        var hash_salt = new UserHashAndSalt();

        hash_salt.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
        hash_salt.PasswordSalt = hmac.Key;

        return hash_salt;
    }

    private List<Claim> SetClaims(Admin user)
    {
        return new List<Claim> 
        {
            new Claim(ClaimTypes.Sid, user.Id.ToString()),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
            new Claim(ClaimTypes.Email, user.Email)
        };
    }
}
