using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataModel
{
    public enum EFunctionalTag
    {
        ///<summary> Полный доступ к функциональности </summary>
        All = 0,
        /// <summary>
        /// Разрешение функционала добавления нового ролика в эфир
        /// </summary>
        AllowVideoAdd = 1,
        /// <summary>
        /// Разрешение на удаление видео ролика из эфира канала если пользователь является его владельцам 
        /// </summary>
        AllowVideoDeletionIfOwner = 2,
        /// <summary>
        /// Разрешение на удаление любого видео ролика из эфира канала
        /// </summary>
        AllowVideoDeletionAll = 3,
        /// <summary>
        /// разрешение на создание вариантов сетки вещания
        /// </summary>
        AllowTvLayoutCreation = 4,
        /// <summary>
        /// Разрешение на перемещение видео внутри плейлиста
        /// </summary>
        AllowTvVideoslayoutManipulate = 5,
        /// <summary>
        /// Разрешение на преобразование лейаута в эфирный лист
        /// </summary>
        AllowLayoutToPlayListConvert = 6,
        /// <summary>
        /// разрешение на перемещение видео между блоками плейлиста
        /// </summary>
        AllowPlayListVideosManipulate = 7,
        /// <summary>
        /// Разрешение на удаление видео из плей листа
        /// </summary>
        AllowPlayListVideosDeletions = 8,
        /// <summary>
        /// Разрешение изменять пользователей
        /// </summary>
        AllowUserManipalations = 9,
        /// <summary>
        /// Разрешение на создание новых пользователей
        /// </summary>
        AllowUserCreation = 10,
        /// <summary>
        /// разрешение на смену роли пользователей
        /// </summary>
        AllowuserChangeRole = 11,
        /// <summary>
        /// Разрешение на изменение функциональности роли
        /// </summary>
        AllowRoleFunctionalityChanges = 12

        


    }
}
