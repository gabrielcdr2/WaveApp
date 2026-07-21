using BCrypt.Net;
using Supabase.Gotrue;
using Wave.Core.Models;
using WaveApp.Data;

namespace WaveApp.Services;

public class AuthService
{
    private readonly AppDbContext _db;

    public AuthService(AppDbContext db)
    {
        _db = db;
    }

    public bool Login(string login, string senha)
    {
        var user = _db.Users.FirstOrDefault(u => u.Login == login);
        if (user is null) return false;

        return BCrypt.Net.BCrypt.Verify(senha, user.SenhaHash);
    }

    public void CriarUsuario(string login, string senha)
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(senha);
        _db.Users.Add(new UserModel { Login = login, SenhaHash = hash });
        _db.SaveChanges();
    }
}
