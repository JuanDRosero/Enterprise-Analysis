
using EnterpriseAnalisys.Controlador;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace EnterpriseAnalisys.Modelo
{
   public class Contador
    {
        #region Variables
        private TextAnalisis ta;
        #endregion
        #region Constructor
        public Contador()
        {
            ta = new TextAnalisis();
        }
        #endregion
        #region Metodos
        //Metodo que retorna la puntacion de sentimiento de un grupo de tweets
        public async Task<Dictionary<string, float>> getScoresAsync(Task<ITweet[]> tweets)
        {
            Dictionary<string, float> puntajes = new Dictionary<string, float>();
            int count = 0;
            puntajes["Positivo"] = 0;
            puntajes["Negativo"] = 0;
            puntajes["Neutral"] = 0;

            float[] puntaje = new float[3];
            var lista = await tweets;
            foreach(var tweet in lista)
            {
                puntaje = ta.SentimentAnalysis(FormatTweets.getTweet(tweet.FullText));
                puntajes["Positivo"] = puntajes["Positivo"] + puntaje[0];
                puntajes["Negativo"] = puntajes["Negativo"] + puntaje[1];
                puntajes["Neutral"] = puntajes["Neutral"] + puntaje[2];
                count++;
            }
            puntajes["Positivo"] = puntajes["Positivo"] /count;
            puntajes["Negativo"] = puntajes["Negativo"] /count;
            puntajes["Neutral"] = puntajes["Neutral"] /count;
            return puntajes;
        }
        //Metodo que agrupa los seguidores de las distintas cuentas
        public int[] getCountUsuarios(int CPrincipal,int CCompara1, int CCompara2, int CCompara3)
        {
            int[] usuarios = new int[4];
            usuarios[0] = CPrincipal;
            usuarios[1] = CCompara1;
            usuarios[2] = CCompara2;
            usuarios[3] = CCompara3;
            return usuarios;
        }
        //Metodo que cuenta la cantidad de usuarios por plataformas (Android,Iphone,PC)
        public async Task<Dictionary<string, int>> getCountOrigenAsync(Task<ITweet[]> tweets)
        {
            var lista = await tweets;
            Dictionary<string, int> origenes = new Dictionary<string, int>();
            origenes["Android"] = 0;
            origenes["Iphone"] = 0;
            origenes["PC"] = 0;
            foreach(var tweet in lista)
            {
                if (FormatTweets.getOrigenTweet(tweet.Source) == "Twitter for Android")
                    origenes["Android"]++;
                else if (FormatTweets.getOrigenTweet(tweet.Source) == "Twitter for iPhone")
                    origenes["Iphone"]++;
                else
                    origenes["PC"]++;
            }
            return origenes;
        }

        //Metodo que retorna el nombre de la fuente con mas popularidad
        public string getPrincipalFuente( int usuariosA, int usuariosI, int usuariosP)
        {
            if (usuariosA >= usuariosI)
            {
                if (usuariosI >= usuariosP || (usuariosP > usuariosI && usuariosA >= usuariosP))
                    return "Android";
                else
                    return "PC";
            }
            else { 
                if (usuariosA > usuariosP || (usuariosP > usuariosA && usuariosI > usuariosP)) 
                return "Iphone";
                else
                    return "PC";
            }   
        }
        #endregion
    }
}
