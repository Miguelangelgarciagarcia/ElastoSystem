using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Produccion_ReporteHorarioEspecial : Form
    {
        public Produccion_ReporteHorarioEspecial()
        {
            InitializeComponent();
        }

        private void txbHoraInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            TextBox txt = (TextBox)sender;

            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 5)
            {
                e.Handled = true;
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                if (txt.SelectionStart == 2 && !txt.Text.Contains(":"))
                {
                    txt.Text += ":";
                    txt.SelectionStart = txt.Text.Length;
                }
            }
        }

        private void txbHoraFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            TextBox txt = (TextBox)sender;

            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 5)
            {
                e.Handled = true;
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                if (txt.SelectionStart == 2 && !txt.Text.Contains(":"))
                {
                    txt.Text += ":";
                    txt.SelectionStart = txt.Text.Length;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string horaInicio = txbHoraInicio.Text.Trim();
            string horaFinal = txbHoraFinal.Text.Trim();

            if(string.IsNullOrEmpty(horaInicio) || string.IsNullOrEmpty(horaFinal))
            {
                MessageBox.Show("Por favor, llena ambos campos de hora.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(horaInicio.Length != 5 || horaFinal.Length != 5)
            {
                MessageBox.Show("Usa el formato HH:mm (por ejemplo, 07:30).", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!System.Text.RegularExpressions.Regex.IsMatch(horaInicio, @"^(?:[01]\d|2[0-3]):[0-5]\d$") ||
                !System.Text.RegularExpressions.Regex.IsMatch(horaFinal, @"^(?:[01]\d|2[0-3]):[0-5]\d$"))
            {
                MessageBox.Show("Formato de hora inválido. Usa el formato 24 horas (00:00 a 23:59).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TimeSpan inicio = TimeSpan.Parse(horaInicio);
            TimeSpan final = TimeSpan.Parse(horaFinal);

            if(final <= inicio)
            {
                MessageBox.Show("La hota final debe ser mayor que la hora de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CalcularHoras();
        }

        private void CalcularHoras()
        {
            try
            {
                TimeSpan inicio = TimeSpan.Parse(txbHoraInicio.Text);
                TimeSpan final = TimeSpan.Parse(txbHoraFinal.Text);

                inicio = RedondearMediaHora(inicio);
                final = RedondearMediaHora(final);

                double horasTotales = (final - inicio).TotalHours;

                MessageBox.Show("" + horasTotales);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al calcular horas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TimeSpan RedondearMediaHora(TimeSpan hora)
        {
            int minutos = hora.Minutes;

            if (minutos == 0)
                return new TimeSpan(hora.Hours, 0, 0);
            else if (minutos > 0 && minutos <= 15)
                return new TimeSpan(hora.Hours, 30, 0);
            else if (minutos > 15 && minutos <= 45)
                return new TimeSpan(hora.Hours, 30, 0);
            else
            {
                int nuevaHora = hora.Hours + 1;
                if(nuevaHora == 24) nuevaHora = 0;
                return new TimeSpan(nuevaHora, 0, 0);
            }
        }
    }
}
