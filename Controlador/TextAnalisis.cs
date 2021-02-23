
using Azure;
using Azure.AI.TextAnalytics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAnalisys.Controlador
{
    public  class  TextAnalisis
    {
        #region Variables
        //Variables de conección a los servición de Azure
        private static readonly AzureKeyCredential credentials = new AzureKeyCredential("61efb057b7c2410d879e5c27fb978c16");
        private static readonly Uri endpoint = new Uri("https://analizadorsentimientor1.cognitiveservices.azure.com/");
        private TextAnalyticsClient cliente;
        #endregion
        #region Constructor
        public TextAnalisis()
        {
            //Objeto cliente para utilizar el analizador de sentimiento
            cliente = new TextAnalyticsClient(endpoint, credentials);
        }
        #endregion
        #region Metodos
        //método por analizar sentimiento de una frase
        public float[] SentimentAnalysis(string frase)
        {
            float[] puntajes = new float[3];
            DocumentSentiment documentSentiment = cliente.AnalyzeSentiment(frase);
            Console.WriteLine($"Document sentiment: {documentSentiment.Sentiment}\n");

            foreach (var sentence in documentSentiment.Sentences)
            {
                puntajes[0] = (float)sentence.ConfidenceScores.Positive;
                puntajes[1] = (float) sentence.ConfidenceScores.Negative;
                puntajes[2] = (float) sentence.ConfidenceScores.Neutral;
            }
            //0 Positive score, 1 Negative Score, 2 Neutral score
            return puntajes;
        }

        //Mineria de opiniones
        //Descripción detallada de los sentimientos de la oración
        public void SentimentAnalysisOP(string frase)
        {
            var documents = new List<string>
            {
                frase
            };

            AnalyzeSentimentResultCollection reviews = cliente.AnalyzeSentimentBatch(documents, options: new AnalyzeSentimentOptions()
            {
                AdditionalSentimentAnalyses = AdditionalSentimentAnalyses.OpinionMining
            });

            foreach (AnalyzeSentimentResult review in reviews)
            {
                Console.WriteLine($"Sentimiento del documento: {review.DocumentSentiment.Sentiment}\n");
                Console.WriteLine($"\tPuntaje positivo: {review.DocumentSentiment.ConfidenceScores.Positive:0.00}");
                Console.WriteLine($"\tPuntaje negativo: {review.DocumentSentiment.ConfidenceScores.Negative:0.00}");
                Console.WriteLine($"\tPuntaje neutral: {review.DocumentSentiment.ConfidenceScores.Neutral:0.00}\n");
                foreach (SentenceSentiment sentence in review.DocumentSentiment.Sentences)
                {
                    Console.WriteLine($"\tTexto: \"{sentence.Text}\"");
                    Console.WriteLine($"\tSentimiento de la oración: {sentence.Sentiment}");
                    Console.WriteLine($"\tPuntuación positiva de la oración: {sentence.ConfidenceScores.Positive:0.00}");
                    Console.WriteLine($"\tPuntuación negativa de la oración : {sentence.ConfidenceScores.Negative:0.00}");
                    Console.WriteLine($"\tPuntuación neutral de la oración: {sentence.ConfidenceScores.Neutral:0.00}\n");

                    foreach (MinedOpinion minedOpinion in sentence.MinedOpinions)
                    {
                        Console.WriteLine($"\tAspecto: {minedOpinion.Aspect.Text}, Valor: {minedOpinion.Aspect.Sentiment}");
                        Console.WriteLine($"\tPuntaje positivo de aspecto: {minedOpinion.Aspect.ConfidenceScores.Positive:0.00}");
                        Console.WriteLine($"\tPuntaje negativo del aspecto: {minedOpinion.Aspect.ConfidenceScores.Negative:0.00}");
                        foreach (OpinionSentiment opinion in minedOpinion.Opinions)
                        {
                            Console.WriteLine($"\t\tOpinion relacionada: {opinion.Text}, Valor: {opinion.Sentiment}");
                            Console.WriteLine($"\t\tPuntaje positivo de la opinion relacionada: {opinion.ConfidenceScores.Positive:0.00}");
                            Console.WriteLine($"\t\tPuntaje negativo de la opinion relacionada: {opinion.ConfidenceScores.Negative:0.00}");
                        }
                    }
                }
                Console.WriteLine($"\n");
            }
        }

        //Deteción de idioma
        public void LanguageDetection(string frase)
        {
            DetectedLanguage detectedLanguage = cliente.DetectLanguage(frase);
            Console.WriteLine("Languaje:");
            Console.WriteLine($"\t{detectedLanguage.Name},\tISO-6391: {detectedLanguage.Iso6391Name}\n");
        }

        //Reconocimiento de entidades con nombre
        public void EntityRecognition(string frase)
        {
            var response = cliente.RecognizeEntities(frase);
            Console.WriteLine("Nombre entidades:");
            foreach (var entity in response.Value)
            {
                Console.WriteLine($"\tTexto: {entity.Text},\tCategoria: {entity.Category},\tSub-Categoria: {entity.SubCategory}");
                Console.WriteLine($"\t\tPuntaje: {entity.ConfidenceScore:F2},\tOffset: {entity.Offset}\n");
            }
        }
        //Función para obtener información acerda de las entidades de un parrafo
        public void EntityLinking(string frases) //Ver el ejemplo de abajo
        {
            var response = cliente.RecognizeLinkedEntities(
                "Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, " +
                "to develop and sell BASIC interpreters for the Altair 8800. " +
                "During his career at Microsoft, Gates held the positions of chairman, " +
                "chief executive officer, president and chief software architect, " +
                "while also being the largest individual shareholder until May 2014.");
            Console.WriteLine("Linked Entities:");
            foreach (var entity in response.Value)
            {
                Console.WriteLine($"\tNombre: {entity.Name},\tID: {entity.DataSourceEntityId},\tURL: {entity.Url}\tOrigen de los datos : {entity.DataSource}");
                Console.WriteLine("\tCoincidencias:");
                foreach (var match in entity.Matches)
                {
                    Console.WriteLine($"\t\tTexto: {match.Text}");
                    Console.WriteLine($"\t\tPuntuación: {match.ConfidenceScore:F2}");
                    Console.WriteLine($"\t\tOffset: {match.Offset}\n");
                }
            }
        }
        //Función que retorna la lista de las entidades de información de identificación personal detectadas
        public void RecognizePII(string frase)
        {
            //string document = "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs.";

            PiiEntityCollection entities = cliente.RecognizePiiEntities(frase).Value;

            Console.WriteLine($"Texto destacado: {entities.RedactedText}");
            if (entities.Count > 0)
            {
                Console.WriteLine($"Reconocidas {entities.Count} PII entit{(entities.Count > 1 ? "ies" : "y")}:");
                foreach (PiiEntity entity in entities)
                {
                    Console.WriteLine($"Texto: {entity.Text}, Categoria: {entity.Category}, SubCategoria: {entity.SubCategory}, Puntaje de confiabilidad: {entity.ConfidenceScore}");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron entidades.");
            }
        }

        //Extracción de frases clave
        public void KeyPhraseExtraction(string frase)
        {
            var response = cliente.ExtractKeyPhrases(frase);

            // Printing key phrases
            Console.WriteLine("Frases claves:");

            foreach (string keyphrase in response.Value)
            {
                Console.WriteLine($"\t{keyphrase}");
            }
        }
    }
    #endregion
}
