using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;

namespace Tvm.Service
{
    public static class DataQuerys
    {
        public const string UserMainTab = "TV_USERS";
        public const string UserDataTab = "TV_USERS_DATA";
        public const string UserRolesTab = "TV_USERS_ROLES";
        public const string UserFunctionalsTab = "TV_AVAILABLE_FUNCTIONALITY";

        public static SelectQuery UsersQuery()
        {
            string[] cols = new string[] { "LOGIN", "PASS", "DATE_START", "DATE_FINISH", "ROLE_ID", "USER_DATA_ID", "CREATION_DATE" };
            return new SelectQuery(UserMainTab, cols, null);
        }

        public static SelectQuery UsersDataQuery()
        {
            string[] cols = new string[] { "USER_DATA_ID", "NAME", "SURNAME", "LASTNAME" };
            return new SelectQuery(UserDataTab, cols, null);
        }

        public static SelectQuery UsersRolesQuery()
        {
            string[] cols = new string[] { "ROLE_ID", "ROLE_NAME", "FUNCTIONALITY_ACCESs" };
            return new SelectQuery(UserRolesTab, cols, null);
        }

        public static SelectQuery UsersFunctionalityQuery()
        {
            string[] cols = new string[] { "FUNC_ID", "FUNC_TAG", "IS_AVAILEBLE", "FUNC_VALUE" };
            return new SelectQuery(UserFunctionalsTab, cols, null);
        }

        public static List<SelectQuery> UserDataQuerys()
        {
            return new List<SelectQuery>(new [] {  UsersQuery(), UsersDataQuery(), UsersRolesQuery(), UsersFunctionalityQuery() });
        }

    }
}
