
using TestEtsy.Pages;

namespace TestEtsy
{
    public static class NavigateTo
    {
        public static void Register()
        {
            Index paginaIndex = new Index();
            paginaIndex.linkRegister.Click();
        }

        public static void Login()
        {
            Index paginaIndex = new Index();
            paginaIndex.btnSignIn.Click();
        }

    }
}
