using System;
using System.Linq;
using System.Threading.Tasks;
using CreateTemplate.Core.Constants;
using CreateTemplate.Data.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CreateTemplate.Data.Contexts.DatabaseInitializer
{
  public interface IDatabaseInitializer
  {
    Task SeedAsync();
  }

  public class DatabaseInitializer : IDatabaseInitializer
  {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    private readonly ILogger _logger;

    public DatabaseInitializer(ApplicationDbContext context, ILogger<DatabaseInitializer> logger,UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
      _context = context;
      _logger = logger;
      _userManager = userManager;
      _roleManager = roleManager;
    }

    public async Task SeedAsync()
    {
      await _context.Database.MigrateAsync().ConfigureAwait(false);

      if (!await _context.Users.AnyAsync())
      {
        _logger.LogInformation("Generating inbuilt accounts");
        await EnsureRoleAsync(Constants.Role.Administrator);
        await CreateUserAsync("administrator", "abcde@1234", "administrator@hoaphat.com","+1 (123) 000-0000", new string[] { Constants.Role.Administrator });
        _logger.LogInformation("Inbuilt account generation completed");
      }
    }

    private async Task EnsureRoleAsync(string roleName)
    {
      if (await _roleManager.FindByNameAsync(roleName) == null)
      {
        var applicationRole = new IdentityRole(roleName);

        var result = await _roleManager.CreateAsync(applicationRole);

        if (!result.Succeeded)
          throw new Exception(
            $"Seeding \"{roleName}\" role failed. Errors: {string.Join(Environment.NewLine, result.Errors)}");
      }
    }

    private async Task<User> CreateUserAsync(string userName, string password, string email, string phoneNumber,string[] roles)
    {
      var applicationUser = new User
      {
        UserName = userName,
        Email = email,
        PhoneNumber = phoneNumber,
        EmailConfirmed = true,

      };

      var result = await _userManager.CreateAsync(applicationUser, password);
      if (!result.Succeeded)
        return null;

      applicationUser = await _userManager.FindByNameAsync(applicationUser.UserName);

      try
      {
        result = await this._userManager.AddToRolesAsync(applicationUser, roles.Distinct());
      }
      catch
      {
        await _userManager.DeleteAsync(applicationUser);
        throw;
      }

      if (!result.Succeeded)
      {
        await _userManager.DeleteAsync(applicationUser);
        return null;
      }

      return applicationUser;
    }
  }
}
