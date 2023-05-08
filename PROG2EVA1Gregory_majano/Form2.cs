using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG2EVA1Gregory_majano
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            string sol = "#7ED8F6"; // You do need the hash
            string luna = "#6AA9FF"; // You do need the hash
            Color colorsol = System.Drawing.ColorTranslator.FromHtml(sol);
            Color colorluna = System.Drawing.ColorTranslator.FromHtml(luna);
            picsol.BackColor= colorsol;
            picluna.BackColor = colorluna;
        }

        //Numeros constantes para la multiplicacion de los digitos del rut
        public static readonly int[] operadores = new int[] { 3, 2, 7, 6, 5, 4, 3, 2 };

        //Variables para las operaciones
        int v0, v1, v2, v3, v4, v5, v6, v7;
        float operacionSuma;
        float restante_division;
        float operacionResta;

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panelBienvenida.BackColor = Color.DarkOliveGreen;
            this.BackColor = Color.DarkSlateGray;
            label2.ForeColor = Color.WhiteSmoke;
            label4.ForeColor= Color.WhiteSmoke;
            label5.ForeColor= Color.WhiteSmoke;
            this.txtrun.BackColor = System.Drawing.Color.DarkOliveGreen;
            txtrun.BackColor = Color.DarkOliveGreen;
            btningresar.BackColor = Color.DarkOliveGreen;
            picluna.Visible = false;
            picsol.Visible = true;
            
        }

        private void picsol_Click(object sender, EventArgs e)
        {
            panelBienvenida.BackColor = Color.Teal;
            this.BackColor = Color.White;
            label2.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            txtrun.BackColor = Color.Black;
            this.txtrun.BackColor = System.Drawing.Color.DarkCyan;
            btningresar.BackColor = Color.DarkCyan;
            picluna.Visible = true;
            picsol.Visible = false;
        }

        int digitoVerificador;
        float division_de_laSuma;
        int redondeo;
        String rutUser;
        Form3 frm = new Form3();
        private void button1_Click(object sender, EventArgs e)
        {
            //Captura del rut
            rutUser = txtrun.Text;

            if (rutUser.Length == 9)
            {
                rutUser = '0' + rutUser;
            }
            if (rutUser.Length == 10)
            {
                //Convertir y guardar los digitos del rut
                int[] digitosRut = new int[] { int.Parse(rutUser[0].ToString()), int.Parse(rutUser[1].ToString()),
                int.Parse(rutUser[2].ToString()),int.Parse(rutUser[3].ToString()),int.Parse(rutUser[4].ToString()),
                int.Parse(rutUser[5].ToString()),int.Parse(rutUser[6].ToString()), int.Parse(rutUser[7].ToString())};

                //Operacion con los digitos y las constantes

                v0 = digitosRut[0] * operadores[0];
                v1 = digitosRut[1] * operadores[1];
                v2 = digitosRut[2] * operadores[2];
                v3 = digitosRut[3] * operadores[3];
                v4 = digitosRut[4] * operadores[4];
                v5 = digitosRut[5] * operadores[5];
                v6 = digitosRut[6] * operadores[6];
                v7 = digitosRut[7] * operadores[7];


                //Suma de valores de la multiplicacion
                operacionSuma = v0 + v1 + v2 + v3 + v4 + v5 + v6 + v7;

                //Division
                division_de_laSuma = operacionSuma / 11;

                //Convertir a entero la operacion de la division
                redondeo = (int)division_de_laSuma;

                //Extraer solo los numeros despues de la , y operar
                restante_division = division_de_laSuma - redondeo;
                operacionResta = 11 - (11 * restante_division);

                //Obtener el digito verificador
                digitoVerificador = (int)operacionResta;

                //CONDICIONANDO DIGITO PARA 0 Y K 

                if (digitoVerificador == 10 && rutUser[9] == 'k')
                {
                    //MessageBox.Show("RUT VALIDO\n El digito verificador es: " + "k");
                    frm.Show();
                }
                else if (digitoVerificador == 11 && rutUser[9] == 0)
                {
                    //MessageBox.Show("RUT VALIDO \nEl digito verificador es: " + 0);
                    frm.Show();
                }
                else if (digitoVerificador.ToString() == rutUser[9].ToString())
                {
                    //MessageBox.Show("RUT VALIDO \nEl digito verificador es: " + digitoVerificador);
                    frm.Show();

                }
                else if (digitoVerificador.ToString() != rutUser[9].ToString())
                {
                    if (digitoVerificador == 10)
                    {
                        MessageBox.Show("RUT INVALIDO \nEl digito verificador es: " + "k");
                    }
                    else if (digitoVerificador == 11)
                    {
                        MessageBox.Show("RUT INVALIDO \nEl digito verificador es: " + "0");
                    }
                    else
                    {
                        MessageBox.Show("RUT INVALIDO \nEl digito verificador es: " + digitoVerificador);
                    }
                }

            }
            else
            {
                MessageBox.Show("No se puede ingrsar este rut");
               
            }
        }

       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

        }
    }
}
