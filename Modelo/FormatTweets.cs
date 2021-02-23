/*
 * Enterprice Analysis
 * Programa desarrollado por Juan David Rosero Torres para la materia de Redes 1 de la Universidad Distrital Francisco Jose de caldas
 * Su uso se encuentra limitado al ambito academico y se proibe su distribución sin previa autorización.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAnalisys.Modelo
{
    static class FormatTweets
    {
        #region Metodos
        //Metodo para obtener el usuario que realizo el tweet
        public static string getUsuario(string tweet)
        {
            try
            {
                return tweet.Substring(tweet.IndexOf('@'), tweet.IndexOf(": ")-2);
            }
            catch (ArgumentOutOfRangeException)
            {
                return "Anonimo";
            }
        }
        //Metodo para obtener el tweet sin el usuario
        public static string getTweet(string tweet)
        {
            try
            {
                return tweet.Substring(tweet.IndexOf(": ") + 2);
            }
            catch (ArgumentOutOfRangeException)
            {
                return tweet;
            }
           
        }
        //Metodo para obtener el dispositivo de origen del tweet
        public static string getOrigenTweet(string tweet)
        {
            int inicio = tweet.IndexOf(">")+1;
            int fin = tweet.IndexOf("</a>") - inicio;
            return tweet.Substring(inicio, fin);
        }
        #endregion 
    }
}
