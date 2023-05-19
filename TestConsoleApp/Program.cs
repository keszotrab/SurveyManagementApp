namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////////////////////////////////////////////////
            //   AKTUALNIE SLUZY TYLKO DO SPRAWDZANIA JAK WYGLADA HASH HASLA   //
            /////////////////////////////////////////////////////////////////////



            // Nawet nie myśl tego ruszać Mareczek 




            string username = "admin";
            string password = "admin";

            Console.WriteLine("Admin: \n"+"Username: "+username+"\nPassword: "+password);

            Infrastructure.Utility.PasswordHashResult HashedPassword = Infrastructure.Utility.PasswordHasher.HashPassword(password);
            Console.WriteLine("Admin: \nSalt: " + HashedPassword.Salt +"\nHashedPassword: "+HashedPassword.HashedPassword);

            Console.WriteLine();


            string ClinetUsername = "client";
            string ClientPassword = "client";

            Console.WriteLine("Client: \n" + "Username: " + ClinetUsername + "\nPassword: " + ClientPassword);

            Infrastructure.Utility.PasswordHashResult ClientHashedPassword = Infrastructure.Utility.PasswordHasher.HashPassword(ClientPassword);
            Console.WriteLine("Client: \nSalt: " + ClientHashedPassword.Salt + "\nHashedPassword: " + ClientHashedPassword.HashedPassword);



        }
    }
}