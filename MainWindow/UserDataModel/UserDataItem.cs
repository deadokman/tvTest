using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataModel
{
    public class UserDataItem
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public ulong UserId;

        /// <summary>
        /// Роль содержащая список доступных для пользователя функционалов
        /// </summary>
        public RoleVariantModelData UserRole;

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname;

        /// <summary>
        /// Отчество
        /// </summary>
        public string LastName;

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login;

        /// <summary>
        /// Дата с которой действительна учетная запись пользователя
        /// </summary>
        public DateTime DateStart;

        /// <summary>
        /// Дата до которой действительна учетная запись пользователя
        /// </summary>
        public DateTime DateFinish;


        public UserDataItem(ulong userId, RoleVariantModelData role, string name, string surname, string lastName, string login, DateTime dateStart, DateTime dateFinish)
        {
            UserId = userId;
            UserRole = role;
            Name = name;
            Surname = surname;
            LastName = lastName;
            Login = login;
            DateStart = dateStart;
            DateFinish = dateFinish;
        }

    }
}
