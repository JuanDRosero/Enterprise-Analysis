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
    static class Recomendacion
    {
        #region Metodos
        //Metodo para obtener la recomendación en base al sentimiento
        public static string getRecomendacionSentimiento(float positivo, float negativo, float neutral)
        {
            string recomendacion="";
            if (neutral >= positivo)
            {
                if (positivo >= negativo)
                {
                    //Neutral>Positivo>Negativo
                    recomendacion = "Aunque las opiniones positivas son superiores a las negativas se reocmienda lanzar nuevos productos " +
                        "o interactuar con los usuarios para mejorar la opinion social";
                }
                else
                {
                    if (negativo >= neutral)
                    {
                        //Negativo>Neutral>Positivo
                        recomendacion = "Es indispensable que cambia el modelo de negocio de manera inmediata, se recomienda revisar constantemente " +
                            "las opiniones de los usuarios para poder mejorar su opinion";
                    }else
                    {
                        //Neutral>negativo>positivo
                        recomendacion = "Aunque la opinion popular de la empresa se ecnuentra neutral, es preoupante que la puntuación negativa " +
                            "supera a la positiva, por lo que se recomienda entablar comunicación con los clientes de manera ocacional";
                    }
                    
                }
            }
            else
            {
                if (neutral >= negativo)
                {
                    //Positivo>Neutral>negativo
                    recomendacion = "La opinion positiva es superior a la neutral y a la negativa, la empresa se encunetra en perfectas " +
                        "condiciones y si continua así podra generar grandes ganacias y monopolizar el mercado";
                }
                else
                {
                    if (positivo >= negativo)
                    {
                        //positivo>negativo>Neutral
                        recomendacion = "Su modelo de negocio se encuentra muy bien, se recomienda continuar de la misma manera.";
                    }
                    else
                    {
                        //Negativo>Positivo>Neutral
                        recomendacion = "Es indispensable que cambia el modelo de negocio de manera inmediata, se recomienda revisar constantemente " +
                            "las opiniones de los usuarios para poder mejorar su opinion";
                    }
                    
                }
            }
            return recomendacion;
        }
        //Metodo para pbteer la recomendacion en base al numero de seguidores
        public static string getRecomendacionSeguidores( ref string[] nombres,ref int [] arreglo)
        {
            var principal = nombres[0];
            string recomendacion;
            ordenarArreglo(ref nombres, ref arreglo);
            if (nombres[0]==principal)//Si la CPrincipal tiene el mayor numero de seguidores
            {
                recomendacion = String.Format("Como {0} tiene mas seguidores, se reocmienda continuar con el modelo de negocio actual ya que este demuestra " +
                    "mayor popularidad, sin embargo es importante tener cuidado con {1} ya que posee una popularidad cercana",nombres[0],nombres[1]);
            }
            else
            {
                recomendacion = String.Format("Es importante replantear el modelo de negocio y revisar a {0} para determinar la razón por la que " +
                    "se encuentra en la primera posición.",nombres[0]);
            }
            return recomendacion;
        }
        //Metodo para obtener la recomendación en base al dispositivo de origen
        public static string getRecomendacionOrigen(string principal)
        {
            return string.Format("Ya que la mayoria de los clientes se encuentran en {0} , es recomendable prestar iportante a este mercado " +
                "sin dejar de lado los otros dos. De ser posible se recomienda desarollar una aplicación para {0} que permita interactura mas con los " +
                "usuarios.", principal);
        }
        //Metodo para ordenar dos arreglos
        private static void ordenarArreglo( ref string[] nombres, ref int [] arreglo)
        {

            int reserva;
            string res;
            for(int i = 0; i < 4; i++)
            {
                for(int j = i + 1; j < 4;j++)
                {
                    if (arreglo[j] > arreglo[i])
                    {
                        reserva = arreglo[i];
                        res = nombres[i];
                        arreglo[i] = arreglo[j];
                        arreglo[j] = reserva;
                        nombres[i] = nombres[j];
                        nombres[j] = res;
                    }
                }
            }
        }
        #endregion
    }
}
