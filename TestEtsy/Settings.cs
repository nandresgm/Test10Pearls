

namespace TestEtsy
{
    public static class Settings
    {
        //Url base
        public static string URL = "https://www.etsy.com/";
        //Path of excel where are the users
        public static string pathUsers = @"..\TestEtsy\TestEtsy\Files\Users.xlsx";
        //Path where the result of login with excel is saved
        public static string pathLog = @"..\TestEtsy\TestEtsy\Files\log.txt";

        //Account to register
        public static class AccountRegister
        {
            public static string email = "elizabeth19993@outlook.es";
            public static string nombre = "Nelson Andres Giraldo Montoya";
            public static string password = "Nandresgm*";
        }

        //Account to register using gmail
        public static class GmailAccount
        {
            public static string email = "giraldonn@gmail.com";
            public static string password = "Leoina123*";
        }

        //Scenarios for test the login
        public static class InvalidCredentials
        {
            public static string withoutEmail = "";
            public static string withoutPassword = "";
            public static string invalidEmail = "andres_201295@hotmail.com";
            public static string invalidPassword = "123";
        }
        public static class ValidCrentials
        {
            public static string email = "andres_201294@hotmail.com";
            public static string password = "Leoina123*";
        }

        //Error messages in the login
        public static class ErrorMessages
        {
            public static string emptyField = "No puede estar vacío.";
            public static string invalidEmail = "La dirección de correo no es válida.";
            public static string invalidPassword = "La contraseña es incorrecta.";
        }
    }
}
