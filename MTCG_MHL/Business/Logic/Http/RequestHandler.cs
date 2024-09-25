using System.Text.Json;
using MTCG_MHL.Business.Logic.Http.User;
using MTCG_MHL.DataAccess.Repositories;

namespace MTCG_MHL.Business.Logic.Http;

public class RequestHandler
{
    private readonly UserRepository _userRepository; // Temporary in-memory storage for users
    private readonly RegisterLogic _registerLogic;
    private readonly LoginLogic _loginLogic;

    public RequestHandler()
    {
        _userRepository = new UserRepository();
        _registerLogic = new RegisterLogic();
        _loginLogic = new LoginLogic(); 
    }
    
    public string HandleRequest(string method, string path, string? requestBody)
    {
        if (method == "POST")
        {
            switch (path)
            {
                case "/users":
                    return _registerLogic.RegisterUser(requestBody, _userRepository);
                case "/sessions":
                    return _loginLogic.LoginUser(requestBody, _userRepository);
                case "/packages":
                    break;
                case "/cards":
                    break;
                case "/deck":
                    break;
            }
        }
        return JsonSerializer.Serialize(new { error = "Invalid request" });
    }
}