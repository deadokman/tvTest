using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace UserDataModel
{
    [DataContract]
    public class RoleVariantModelData
    {

        /// <summary>
        /// Идентификатор роли
        /// </summary>
        [DataMember]
        public long RoleId { get; private set; }
        /// <summary>
        /// название роли
        /// </summary>
        [DataMember]
        public string RoleName { get; private set; }
        
        /// <summary>
        /// Список функционалов, которые доступны для роли
        /// </summary>
        [DataMember]
        public Dictionary<EFunctionalTag, FunctionalModelData> RoleFuncUsages { get; private set; }

        public RoleVariantModelData(long roleId, string roleName)
        {
            RoleId = roleId;
            RoleName = roleName;
            RoleFuncUsages = new Dictionary<EFunctionalTag, FunctionalModelData>();
        }
        /// <summary>
        /// Добавить функционал к роли
        /// </summary>
        /// <param name="newFunc">Модель функционала</param>
        public void AddRoleFunctional(FunctionalModelData fmd)
        {
            RoleFuncUsages.Add(fmd.Tag, fmd);
        }

        /// <summary>
        /// Удалить функционал роли
        /// </summary>
        public void RemoveRoleFunctional(FunctionalModelData fmd)
        {
            RoleFuncUsages.Remove(fmd.Tag);
        }

    }
}
