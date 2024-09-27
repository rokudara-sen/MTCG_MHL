using MTCG_MHL.Models.HTTP;

namespace MTCG_MHL.Interface;

public interface IEndpoint
{
    public void HandleRequest(Request request, Response response);
}