using EnterpriseAnalisys.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using OxyPlot.WindowsForms;
using EnterpriseAnalisys.Modelo;
using Tweetinvi.Models;
using OxyPlot.Series;
using OxyPlot;
using System.Threading.Tasks;
using OxyPlot.Axes;

namespace EnterpriseAnalisys.Vista
{
    public partial class Form1 : Form
    {
        #region Variables
        //Variables primitivas
        private string CPrincipal, CComparar, CComparar2, CComparar3;
        private int[] seguidores;
        //Variables especiales
        private Dictionary<string, float> puntajes;
        private Dictionary<string, int> origenes;
        //Objetos
        public Cargando cargando;
        private Contador contador;
        private PlotView pvPie, pvBarras, pvOrigen;
        private Twitter twitter;
        #endregion

        #region Constructor
        public Form1(Twitter twitter, string CPrincipal, string CComparar, string CComparar2, string CComparar3)
        {
            InitializeComponent();
            this.CPrincipal = CPrincipal;
            this.CComparar = CComparar;
            this.CComparar2 = CComparar2;
            this.CComparar3 = CComparar3;
            this.twitter = twitter;
            seguidores = new int[3];
            contador = new Contador();
            cargando = new Cargando();
        }
        #endregion
        #region Eventos
        private void Form1_Load(object sender, EventArgs e)
        {
            lblCuentaPrincipal.Text = twitter.getNombreUsuario(CPrincipal);
            pictureBox1.ImageLocation = twitter.getImagePerfilUrl(CPrincipal);
            lblCuentaPrincipal.Text = CPrincipal;
            generarPuntajesAsync();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #endregion
        #region Metodos
        //Metodo asincronico para obtener la informacion e insertarla en el formulario
        private async void generarPuntajesAsync()
        {
            string[] nombres = new string[4];
            nombres[0] = CPrincipal;
            nombres[1] = CComparar;
            nombres[2] = CComparar2;
            nombres[3] = CComparar3;
            seguidores = contador.getCountUsuarios(twitter.getFollowersFrom(CPrincipal), twitter.getFollowersFrom(CComparar),
                          twitter.getFollowersFrom(CComparar2), twitter.getFollowersFrom(CComparar3));
            puntajes = await contador.getScoresAsync(twitter.getTweetsBusqueda(CPrincipal));
            origenes = await contador.getCountOrigenAsync(twitter.getTweetsBusqueda(CPrincipal));
            pintarGraficas();
            lblRecPieChart.Text = Recomendacion.getRecomendacionSentimiento(puntajes["Positivo"], puntajes["Negativo"], puntajes["Neutral"]);
            lblRecCompetencia.Text = Recomendacion.getRecomendacionSeguidores(ref nombres,ref  seguidores);
            lblRecUbicacion.Text = Recomendacion.getRecomendacionOrigen(contador.getPrincipalFuente(origenes["Android"], origenes["Iphone"], origenes["PC"]));
            cargando.Close();
        }

        //Metodo para generar las graficas con OxyPlot
        private  void pintarGraficas()
        {
            try
            {
                pvPie = new PlotView();
                pvBarras = new PlotView();
                pvOrigen = new PlotView();
                pvPie.Location = new Point(283, 98);
                pvPie.Size = new Size(200, 130);
                pvBarras.Location = new Point(0, 253);
                pvBarras.Size = new Size(290, 130);
                pvOrigen.Location = new Point(475, 253);
                pvOrigen.Size = new Size(193, 121);
                this.Controls.Add(pvPie);
                this.Controls.Add(pvBarras);
                this.Controls.Add(pvOrigen);
                pvPie.Model = new OxyPlot.PlotModel
                {
                };
                //Series de Sentimiento
                dynamic seriesP1 = new PieSeries { StrokeThickness = 0.8, InsideLabelPosition = 0.6, AngleSpan = 360, StartAngle = 90 };
                seriesP1.Slices.Add(new PieSlice("Positivo", puntajes["Positivo"]) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
                seriesP1.Slices.Add(new PieSlice("Negativo", puntajes["Negativo"]) { IsExploded = true });
                seriesP1.Slices.Add(new PieSlice("Neutral", puntajes["Neutral"]) { IsExploded = true });
                pvPie.Model.Series.Add(seriesP1);

                //Series de Barras (Usar contador)
                pvBarras.Model = new PlotModel {
                   
                };
                var barSeries = new BarSeries
                {
                    ItemsSource = new List<BarItem>(new[]
                    {
                        new BarItem{ Value = (seguidores[0]/1000)},
                        new BarItem{ Value = (seguidores[1]/1000)},
                        new BarItem{ Value = (seguidores[2]/1000)},
                        new BarItem{ Value = (seguidores[3]/1000)},
                    }),
                    LabelPlacement = LabelPlacement.Inside,
                    LabelFormatString = "{0:.00} Ml"
                    
                };
                pvBarras.Model.Series.Add(barSeries);

                pvBarras.Model.Axes.Add(new CategoryAxis
                {
                    Position = AxisPosition.Left,
                    Key = "CakeAxis",
                    ItemsSource = new[]
                        {
                        CPrincipal,
                        CComparar,
                        CComparar2,
                        CComparar3,
                         }
                });
                //Series de Origen
                pvOrigen.Model = new OxyPlot.PlotModel
                {
                };
                dynamic seriesP2 = new PieSeries { StrokeThickness = 0.8, InsideLabelPosition = 0.6, AngleSpan = 360, StartAngle = 180 };
                seriesP2.Slices.Add(new PieSlice("Andorid", origenes["Android"]) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
                seriesP2.Slices.Add(new PieSlice("Iphone", origenes["Iphone"]) { IsExploded = true });
                seriesP2.Slices.Add(new PieSlice("PC", origenes["PC"]) { IsExploded = true });
                pvOrigen.Model.Series.Add(seriesP2);

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Por favor espere mietras se cargan los tweets", "Un momento", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        #endregion

    }
}
