namespace EaApplicationTest.Interfaces
{
    public interface IRegisterPage
    {
        Task ClickRegisterBtn();
        Task EnterConfirmPass(string password);
        Task EnterEmail(string email);
        Task EnterPassword(string password);
        Task EnterUserName(string userName);
    }
}