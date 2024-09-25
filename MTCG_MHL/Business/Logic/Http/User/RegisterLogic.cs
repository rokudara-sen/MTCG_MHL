using System.Text.Json;
using MTCG_MHL.DataAccess.Repositories;

namespace MTCG_MHL.Business.Logic.Http.User;

public class RegisterLogic
{
    public string RegisterUser(string? requestBody, UserRepository userRepository)
    {
        if (string.IsNullOrEmpty(requestBody)) return JsonSerializer.Serialize(new { error = "Empty request body" });

        var user = JsonSerializer.Deserialize<Models.Player.User>(requestBody);

        if (user != null && userRepository.AddUser(user))
        {
            return JsonSerializer.Serialize(new { message = "User created successfully" });
        }

        return JsonSerializer.Serialize(new { error = "User already exists" });
    }
}