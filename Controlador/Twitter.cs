/*
 * Enterprice Analysis
 * Programa desarrollado por Juan David Rosero Torres para la materia de Redes 1 de la Universidad Distrital Francisco Jose de caldas
 * Su uso se encuentra limitado al ambito academico y se proibe su distribución sin previa autorización.
 */

using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace EnterpriseAnalisys.Controlador
{
    public class Twitter
    {
        #region Variables
        private TwitterClient userClient;
        #endregion
        #region Conatructor
        public Twitter()
        {
            userClient = new TwitterClient("oPqzxxcGtqA9VicxlidV7BtS6", "0mTAMed1KmNvSqGgxisaBgfv6KXR5QstbBB4C4nTe5qJjzJb4K",
               "1228081760270987265-ldDSw0HYiRXfbgcpg66NaGa1mBRjI8", "xKqyXH7ptXhhAHFORxeKxF3xdjh9UkhTnNZvaTR78osaX");
        }
        #endregion
        #region Métodos
        //Metodo para obtener tweets dependiendo de un parametro de busquedas
        public Task<ITweet[]> getTweetsBusqueda(string busqueda)
        {
            // litro de lenguaje
            var Tweets = userClient.Search.SearchTweetsAsync(new SearchTweetsParameters(busqueda)
            {
                Lang = LanguageFilter.Spanish,


            });
            return Tweets;
        }

        //Metodo para obtener una lista de usuarios
        public Task<IUser[]> getUsuarioBusqueda(string busqueda)
        {
            var usuario = userClient.Search.SearchUsersAsync(busqueda);
            return usuario;
        }

        //Metodo para obtner el numero de usuarios de una cuenta
        public int getFollowersFrom(string busqueda)
        {
            var user = userClient.Users.GetUserAsync(busqueda);
            var followers = user.Result.FollowersCount;
            return followers;
        }

        //Metodo para obteer  la imagen de perfil de una cuenta
        public string getImagePerfilUrl(string busqueda)
        {
            var user = userClient.Users.GetUserAsync(busqueda);
            var img = user.Result.ProfileImageUrl400x400;
            return img;
        }
        //  
        public string getNombreUsuario(string nombre)
        {
            return userClient.Users.GetUserAsync(nombre).Result.Name;
        }
        #endregion
    }
}
