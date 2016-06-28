using SocialNetwork.Bll;

namespace SocialNetwork.PL.Console.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var logic = new UserLogic();
            logic.RemoveUser(0);
        }
    }
}