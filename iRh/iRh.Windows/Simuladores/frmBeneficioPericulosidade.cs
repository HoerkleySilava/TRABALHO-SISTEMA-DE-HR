﻿using iRh.Windows.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRh.Windows.Simuladores
{
    public partial class frmBeneficioPericulosidade : Form
    {
        public frmBeneficioPericulosidade()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSalarioPericulodidade.Text))
            {
                MessageBox.Show("Informe as horaspor favor!!!", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSalarioPericulodidade.Focus();
                return;
            }

            try
            {
                var salario = double.Parse(txtSalarioPericulodidade.Text);
                var horas = double.Parse(txtHorasPericulosidade.Text);

                var inss = Inss.Calcula(salario);
                var irrf = Irrf.Calcula(salario);
               
                var valorPericulosidade = Periculosidade.Calcula(salario, horas);

               
                var totalReceber = valorPericulosidade + inss + irrf;

                lblResultado.Text = ("o total que irá receber é: ") + totalReceber.ToString("C");
                panelResultado.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Informe um valor valido por favor!!!, ex: 3500", "erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSalarioPericulodidade_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

            }
        }
    }
}
