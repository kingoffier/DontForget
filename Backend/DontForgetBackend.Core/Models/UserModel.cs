using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontForgetBackend.Core.Models
{
    public class UserModel
    {
        private UserModel(int id, string? email, string? firstName, string? secondName, string? password, string? login)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            SecondName = secondName;
            Password = password;
            Login = login;
        }

        public int Id { get; set; }

        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public string? Password { get; set; }

        public string? Login { get; set; }

        public static (UserModel? UserModel, string Error) Create(int id,string? email, string? fname, string? sname, string? pass, string? login)
        {
            var error = String.Empty;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                error = "Вы не заполнили поле 'Логин' или 'Пароль'";
            }

            var user = new UserModel(id, email, fname, sname, pass, login);

            return (user, error);
        }
    }
}
