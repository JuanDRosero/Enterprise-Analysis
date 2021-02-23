/*
 * Enterprice Analysis
 * Programa desarrollado por Juan David Rosero Torres para la materia de Redes 1 de la Universidad Distrital Francisco Jose de caldas
 * Su uso se encuentra limitado al ambito academico y se proibe su distribución sin previa autorización.
 */
namespace EnterpriseAnalisys.Vista
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCuentaPrincipal = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSentimetAnalysis = new System.Windows.Forms.Label();
            this.lblCompetencia = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.lblRecPieChart = new System.Windows.Forms.TextBox();
            this.lblRecCompetencia = new System.Windows.Forms.TextBox();
            this.lblRecUbicacion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCuentaPrincipal
            // 
            this.lblCuentaPrincipal.AutoSize = true;
            this.lblCuentaPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCuentaPrincipal.Location = new System.Drawing.Point(362, 9);
            this.lblCuentaPrincipal.Name = "lblCuentaPrincipal";
            this.lblCuentaPrincipal.Size = new System.Drawing.Size(66, 24);
            this.lblCuentaPrincipal.TabIndex = 0;
            this.lblCuentaPrincipal.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblSentimetAnalysis
            // 
            this.lblSentimetAnalysis.AutoSize = true;
            this.lblSentimetAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSentimetAnalysis.Location = new System.Drawing.Point(262, 51);
            this.lblSentimetAnalysis.Name = "lblSentimetAnalysis";
            this.lblSentimetAnalysis.Size = new System.Drawing.Size(192, 16);
            this.lblSentimetAnalysis.TabIndex = 0;
            this.lblSentimetAnalysis.Text = "Sentiment Analysis Tweets";
            // 
            // lblCompetencia
            // 
            this.lblCompetencia.AutoSize = true;
            this.lblCompetencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCompetencia.Location = new System.Drawing.Point(63, 220);
            this.lblCompetencia.Name = "lblCompetencia";
            this.lblCompetencia.Size = new System.Drawing.Size(98, 16);
            this.lblCompetencia.TabIndex = 0;
            this.lblCompetencia.Text = "Competencia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(236, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(662, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 0;
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOrigen.Location = new System.Drawing.Point(533, 220);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(70, 16);
            this.lblOrigen.TabIndex = 0;
            this.lblOrigen.Text = "Origenes";
            // 
            // lblRecPieChart
            // 
            this.lblRecPieChart.Cursor = System.Windows.Forms.Cursors.No;
            this.lblRecPieChart.Location = new System.Drawing.Point(545, 83);
            this.lblRecPieChart.Multiline = true;
            this.lblRecPieChart.Name = "lblRecPieChart";
            this.lblRecPieChart.ReadOnly = true;
            this.lblRecPieChart.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblRecPieChart.Size = new System.Drawing.Size(304, 116);
            this.lblRecPieChart.TabIndex = 2;
            // 
            // lblRecCompetencia
            // 
            this.lblRecCompetencia.Cursor = System.Windows.Forms.Cursors.No;
            this.lblRecCompetencia.Location = new System.Drawing.Point(284, 251);
            this.lblRecCompetencia.Multiline = true;
            this.lblRecCompetencia.Name = "lblRecCompetencia";
            this.lblRecCompetencia.ReadOnly = true;
            this.lblRecCompetencia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblRecCompetencia.Size = new System.Drawing.Size(191, 127);
            this.lblRecCompetencia.TabIndex = 2;
            // 
            // lblRecUbicacion
            // 
            this.lblRecUbicacion.Cursor = System.Windows.Forms.Cursors.No;
            this.lblRecUbicacion.Location = new System.Drawing.Point(668, 253);
            this.lblRecUbicacion.Multiline = true;
            this.lblRecUbicacion.Name = "lblRecUbicacion";
            this.lblRecUbicacion.ReadOnly = true;
            this.lblRecUbicacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblRecUbicacion.Size = new System.Drawing.Size(184, 127);
            this.lblRecUbicacion.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 441);
            this.Controls.Add(this.lblRecUbicacion);
            this.Controls.Add(this.lblRecCompetencia);
            this.Controls.Add(this.lblRecPieChart);
            this.Controls.Add(this.lblOrigen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCompetencia);
            this.Controls.Add(this.lblSentimetAnalysis);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCuentaPrincipal);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enterprice Analizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCuentaPrincipal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSentimetAnalysis;
        private System.Windows.Forms.Label lblCompetencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.TextBox lblRecPieChart;
        private System.Windows.Forms.TextBox lblRecCompetencia;
        private System.Windows.Forms.TextBox lblRecUbicacion;
    }
}