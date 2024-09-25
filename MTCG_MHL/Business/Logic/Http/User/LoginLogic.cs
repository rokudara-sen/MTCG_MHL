using System.Text.Json;
using MTCG_MHL.Models.Player;
using MTCG_MHL.DataAccess.Repositories;

namespace MTCG_MHL.Business.Logic.Http.User;

public class LoginLogic
{
    public string LoginUser(string? requestBody, UserRepository userRepository)
    {
        if (string.IsNullOrEmpty(requestBody)) return JsonSerializer.Serialize(new { error = "Empty request body" });

        var user = JsonSerializer.Deserialize<Models.Player.User>(requestBody);

        if (user != null && userRepository.ValidateUser(user.Username, user.Password))
        {
            var token = $"{user.Username}-mtcgToken";
            return JsonSerializer.Serialize(new { message = "Login successful", token });
        }

        return JsonSerializer.Serialize(new { error = "Invalid username or password" });
    }
}