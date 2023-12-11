using BusinessWorkManagementSystem.DataAccess;
using BusinessWorkManagementSystem.DataAccess.Models;

namespace BusinessWorkManagementSystem.TestingHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserData user = new UserData();

            Console.WriteLine("\n Enter user id : ");
            int userId = int.Parse(Console.ReadLine());

            var singleUser = user.GetSingleUserById(userId);

            if (singleUser != null) {
                Console.WriteLine(" ******** User Details ********");
                Console.WriteLine("\nFirst name: {0}", singleUser.UserFirstName);
                Console.WriteLine("\nLast name: {0}", singleUser.UserLastName);
                Console.WriteLine("\nEmail: {0}", singleUser.UserEmailAddress);
            }

            else { Console.WriteLine(" User not available. \n"); }


            Console.WriteLine("\n******** Display all users detail ********");

            var allUsers = user.GetUserList();


            Console.WriteLine("\n User Id | First Name | Last Name | Mobile Number | Email address ");

            foreach (UserModel singleUserItem in allUsers)
            {
                Console.WriteLine("\n     {0} |   {1} |   {2} |   {3} |   {4} ",
                    singleUserItem.UserId,
                    singleUserItem.UserFirstName,
                    singleUserItem.UserLastName,
                    singleUserItem.UserMobileNumber,
                    singleUserItem.UserEmailAddress);
            }

            Console.ReadKey();
        }
    }
}