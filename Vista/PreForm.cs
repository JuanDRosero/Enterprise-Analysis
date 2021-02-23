using EnterpriseAnalisys.Controlador;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnterpriseAnalisys.Vista
{
    public partial class PreForm : Form
    {
        #region Variables
        private string CPrincipal, CComparar, CComparar2, CComparar3;
        private Form1 formulario;
        private Twitter twitter;
        #endregion
        #region Constructor
        public PreForm()
        {
            InitializeComponent();
            twitter = new Twitter();
        }
        #endregion
        #region Eventos
        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            borrarComboBox(CBoxPrincipal);
          agregarElementosAsync(CBoxPrincipal, txtCPrincipal);
        }

        private void btnComparar1_Click(object sender, EventArgs e)
        {
            borrarComboBox(CBoxComparar1);
            agregarElementosAsync(CBoxComparar1, txtCuentaComparar1);
        }

        private void btnComparar2_Click(object sender, EventArgs e)
        {
            borrarComboBox(CBoxComparar2);
           agregarElementosAsync(CBoxComparar2, txtCComparar2);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            var opcion=MessageBox.Show("Los elementos seleccionados en las listas son los que usaran para el análisis," +
                " ¿Desea continuar con estos valores?", "¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (opcion == DialogResult.Yes)
            {
                try
                {
                    //Se obtienen los valores de los comboBox y se pasan al siguiente formulario
                    CPrincipal = CBoxPrincipal.SelectedItem.ToString();
                    CComparar = CBoxComparar1.SelectedItem.ToString();
                    CComparar2 = CBoxComparar2.SelectedItem.ToString();
                    CComparar3 = CBoxComparar3.SelectedItem.ToString();
                    iniciarFormCarga();
                    /*
                    Task onTask = new Task(iniciarFormCarga);
                    onTask.Start();
                    this.Close();
                    */


                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            } else if (opcion == DialogResult.No)
            {

            }
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            borrarComboBox(CBoxComparar3);
           agregarElementosAsync(CBoxComparar3, txtCComparar3);
        }
        #endregion
        #region Metodos
        //Metodo que limpia el comboBox
        private void borrarComboBox(ComboBox cb)
        {
            cb.Items.Clear();
        }
        //Metodo que agrega los usuarios al ComboBox
        private async void agregarElementosAsync(ComboBox cb, TextBox tb)
        {
            if (!tb.Text.Equals(null) && !tb.Text.Equals(""))
            {
                var users = await twitter.getUsuarioBusqueda(tb.Text);
                foreach (var user in users)
                {
                    cb.Items.Add("@"+user.ToString());
                }

            }else
            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void iniciarFormCarga()
        {
            formulario = new Form1(twitter, CPrincipal, CComparar, CComparar2, CComparar3);
            formulario.Show();
            formulario.cargando.Show();
        }
        #endregion
    }
}
