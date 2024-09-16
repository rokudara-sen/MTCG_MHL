namespace MTCG_MHL.Game.Logic;

public class SearchController
{
    public SearchController(string uid, string username)
    {
        SearchUser(uid, username);
    }

    public SearchController(string uid)
    {
        SearchUser(uid);
    }

    private void SearchUser(string uid = null, string username = null)
    {
        
    }
}