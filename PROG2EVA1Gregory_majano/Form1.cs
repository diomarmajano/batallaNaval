using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG2EVA1Gregory_majano
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\Users\httpd\Music\trompetas.wav");
            player.Play();
           
            for (int i = 0; i < tableroJugador.GetLength(0); i++)
            {
                for (int j = 0; j < tableroJugador.GetLength(1); j++)
                {
                    tableroJugador[i, j] = "null";
                    tableroPc[i, j] = "null";
                }
            }
            btnatacar.Enabled= false;
            btnpuntos.Enabled= false;
            
        }
        string[,] tableroJugador = new string[6, 6];
        string[,] tableroPc = new string[6, 6];

        int[] coordenadaPc1 = new int[2];
        int[] coordenadaPc2 = new int[2];
        int[] coordenadaPc3 = new int[2];
        int[] coordenadaPc4 = new int[2];
        int[] coordenadaPc5 = new int[2];
        int[] coordenadaPc6 = new int[2];
        int[] coordenadaPc7 = new int[2];
        int[] coordenadaPc8 = new int[2];
        int[] coordenadaDeAtaque = new int[2];

        string coordenada1;
        string coordenada2;
        string coordenada3;
        string coordenada4;
        string coordenada5;
        string coordenada6;
        string coordenada7;
        string coordenada8;
        string coordenadaAtaque;
        int contadorCLic = 0;
        int contadorTurnos = 0; 
        int contadorAtaques = 0;
        int puntosJugador = 0;
        int puntosPc = 0;
        int valor;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void clic_jugador(object sender, EventArgs e)
        {
            //La interaccion del jugador en su tablero
            //Al seleccionar la imagen cambia su estado de true a false para mostrar las imagenes que se encuentan debajo
            
            if(contadorCLic <= 7)
            {
                var picture = (PictureBox)sender;
                picture.Visible = false;
                contadorCLic++;
            }
            else
            {
                var picture = (PictureBox)sender;
                picture.Click += block_fichas;
                //Bloquea las fichas al llegar al maximo de posiciones
            }
            
        }
        private void clic_pc(object sender, EventArgs e)
        {
            //utilizamos clic_pc para ir seleccionando la posicion de ataque de nuestro enemigo
            //EL jugador interactua con el tablero enemigo, para descubrir que esconde cada posicion
            var picture = (PictureBox)sender;
            if (contadorTurnos < valor)
            {
                picture.Visible = false; //El pictureBox seleccionado se oculta y revela la seleccion
                contadorTurnos++;
                
                if (valor > contadorTurnos)
                {
                    for (int i = 0; i < tableroPc.GetLength(0); i++)
                    {
                        for (int j = 0; j < tableroPc.GetLength(1); j++)
                        {
                            //En caso de que la coordenada aleatoria coincida con la posicion que elegimos, el picture seleccionado
                            //se oculta y deja a la vista el barco atacado
                            if (tableroPc[i, j] == coordenada1)
                            {
                                string pcname = "chek" + coordenada1;
                                PictureBox pcBom = (PictureBox)Controls[pcname];
                            }
                            if (tableroPc[i, j] == coordenada2)
                            {
                                string pcname = "chek" + coordenada2;
                                PictureBox pcBom = (PictureBox)Controls[pcname];
                                pcBom.Visible = false;
                            }
                            if (tableroPc[i, j] == coordenada3)
                            {
                                string pcname = "chek" + coordenada3;
                                PictureBox pcBom = (PictureBox)Controls[pcname];
                                pcBom.Visible = false;
                            }
                            if (tableroPc[i, j] == coordenada4)
                            {
                                string pcname = "chek" + coordenada4;
                                PictureBox pcBom = (PictureBox)Controls[pcname];
                                pcBom.Visible = false;  
                            }
                            if (tableroPc[i, j] == coordenada5)
                            {
                                string pcname = "chek" + coordenada5;
                                PictureBox pcBom = (PictureBox)Controls[pcname];
                                pcBom.Visible = false; 
                            }
                            if (tableroPc[i, j] == coordenada6)
                            {
                                string pcname = "chek" + coordenada6;
                                PictureBox pcBom = (PictureBox)Controls[pcname];
                                pcBom.Visible = false;
                            }
                            if (tableroPc[i, j] == coordenada7)
                            {
                                string pcname = "chek" + coordenada7;
                                PictureBox pcBom = (PictureBox)Controls[pcname];
                                pcBom.Visible = false; 
                            }
                            if (tableroPc[i, j] == coordenada8)
                            {
                                string pcname = "chek" + coordenada8;
                                PictureBox pcBom = (PictureBox)Controls[pcname];
                                pcBom.Visible = false; 
                            }
                        }
                    }
                }
            }
            else if(contadorTurnos > valor)
            {

                MessageBox.Show("Se han terminado tus turnos");
                picture.Click += block_fichas; //Se asigna a cada pictureBox un evento click sin funcion, parra evitar que se sigan seleccionando fichas
            }
            btnatacar.Enabled = true;
        } 
        private void posicionar_Click(object sender, EventArgs e)
        { 
            if (contadorCLic == 8)
            {
                imgblock.Visible = false;
                trackBar1.Hide();
                btnreinicio.Visible = true;
               
                //Despues de ubicar los barcos se compueba la posicion de los picturesBox seleccionados que pasan a falso
                //y para mostrar el picture box del barco
                //Si el pictureBox es falso, se almacena la coordenada correspondiente en la matriz
                if (inij00.Visible == false) { tableroJugador[0, 0] = "00"; }
                if (inij01.Visible == false) { tableroJugador[0, 1] = "01"; }
                if (inij02.Visible == false) { tableroJugador[0, 2] = "02"; }
                if (inij03.Visible == false) { tableroJugador[0, 3] = "03"; }
                if (inij04.Visible == false) { tableroJugador[0, 4] = "04"; }
                if (inij05.Visible == false) { tableroJugador[0, 5] = "05"; }
                if (inij10.Visible == false) { tableroJugador[1, 0] = "10"; }
                if (inij11.Visible == false) { tableroJugador[1, 1] = "11"; }
                if (inij12.Visible == false) { tableroJugador[1, 2] = "12"; }
                if (inij13.Visible == false) { tableroJugador[1, 3] = "13"; }
                if (inij14.Visible == false) { tableroJugador[1, 4] = "14"; }
                if (inij15.Visible == false) { tableroJugador[1, 5] = "15"; }
                if (inij20.Visible == false) { tableroJugador[2, 0] = "20"; }
                if (inij21.Visible == false) { tableroJugador[2, 1] = "21"; }
                if (inij22.Visible == false) { tableroJugador[2, 2] = "22"; }
                if (inij23.Visible == false) { tableroJugador[2, 3] = "23"; }
                if (inij24.Visible == false) { tableroJugador[2, 4] = "24"; }
                if (inij25.Visible == false) { tableroJugador[2, 5] = "25"; }
                if (inij30.Visible == false) { tableroJugador[3, 0] = "30"; }
                if (inij31.Visible == false) { tableroJugador[3, 1] = "31"; }
                if (inij32.Visible == false) { tableroJugador[3, 2] = "32"; }
                if (inij33.Visible == false) { tableroJugador[3, 3] = "33"; }
                if (inij34.Visible == false) { tableroJugador[3, 4] = "34"; }
                if (inij35.Visible == false) { tableroJugador[3, 5] = "35"; }
                if (inij40.Visible == false) { tableroJugador[4, 0] = "40"; }
                if (inij41.Visible == false) { tableroJugador[4, 1] = "41"; }
                if (inij42.Visible == false) { tableroJugador[4, 2] = "42"; }
                if (inij43.Visible == false) { tableroJugador[4, 3] = "43"; }
                if (inij44.Visible == false) { tableroJugador[4, 4] = "44"; }
                if (inij45.Visible == false) { tableroJugador[4, 5] = "45"; }
                if (inij50.Visible == false) { tableroJugador[5, 0] = "50"; }
                if (inij51.Visible == false) { tableroJugador[5, 0] = "51"; }
                if (inij52.Visible == false) { tableroJugador[5, 0] = "52"; }
                if (inij53.Visible == false) { tableroJugador[5, 0] = "53"; }
                if (inij54.Visible == false) { tableroJugador[5, 0] = "54"; }
                if (inij55.Visible == false) { tableroJugador[5, 0] = "55"; }

                //Se estan generando coordenadas aleatorias en las que el pc posicionara sus barcos
                Random posicion = new Random();
                coordenadaPc1[0] = posicion.Next(0, 6);
                coordenadaPc1[1] = posicion.Next(0, 6);
                coordenadaPc2[0] = posicion.Next(0, 6);
                coordenadaPc2[1] = posicion.Next(0, 6);
                coordenadaPc3[0] = posicion.Next(0, 6);
                coordenadaPc3[1] = posicion.Next(0, 6);
                coordenadaPc4[0] = posicion.Next(0, 6);
                coordenadaPc4[1] = posicion.Next(0, 6);
                coordenadaPc5[0] = posicion.Next(0, 6);
                coordenadaPc5[1] = posicion.Next(0, 6);
                coordenadaPc6[0] = posicion.Next(0, 6);
                coordenadaPc6[1] = posicion.Next(0, 6);
                coordenadaPc7[0] = posicion.Next(0, 6);
                coordenadaPc7[1] = posicion.Next(0, 6);
                coordenadaPc8[0] = posicion.Next(0, 6);
                coordenadaPc8[1] = posicion.Next(0, 6);

                coordenada1 = coordenadaPc1[0].ToString() + coordenadaPc1[1];
                coordenada2 = coordenadaPc2[0].ToString() + coordenadaPc2[1];
                coordenada3 = coordenadaPc3[0].ToString() + coordenadaPc3[1];
                coordenada4 = coordenadaPc4[0].ToString() + coordenadaPc4[1];
                coordenada5 = coordenadaPc5[0].ToString() + coordenadaPc5[1];
                coordenada6 = coordenadaPc6[0].ToString() + coordenadaPc6[1];
                coordenada7 = coordenadaPc7[0].ToString() + coordenadaPc7[1];
                coordenada8 = coordenadaPc8[0].ToString() + coordenadaPc8[1];

                tableroPc[coordenadaPc1[0], coordenadaPc1[1]] = coordenada1;
                tableroPc[coordenadaPc2[0], coordenadaPc2[1]] = coordenada2;
                tableroPc[coordenadaPc3[0], coordenadaPc3[1]] = coordenada3;
                tableroPc[coordenadaPc4[0], coordenadaPc4[1]] = coordenada4;
                tableroPc[coordenadaPc5[0], coordenadaPc5[1]] = coordenada5;
                tableroPc[coordenadaPc6[0], coordenadaPc6[1]] = coordenada6;
                tableroPc[coordenadaPc7[0], coordenadaPc7[1]] = coordenada7;
                tableroPc[coordenadaPc8[0], coordenadaPc8[1]] = coordenada8;
                btnposicionar.Enabled = false;
                btnatacar.Enabled = true;  
            }
            else if (contadorCLic < 8)
            {
                MessageBox.Show("Debe completar sus posiciones");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Boton de ataque, el computador genera coordenadas random, para comparar, coincidencia de coordenadas con la matriz
            //y en caso de coincidir el barco en la posicion es atacado y se incrementa un punto al pc
            contadorAtaques++;
            label4.Text = contadorAtaques.ToString();
            if (valor >= contadorAtaques)
            {
                Random ataque = new Random();
                coordenadaDeAtaque[0] = ataque.Next(0, 6);
                coordenadaDeAtaque[1] = ataque.Next(0, 6);
                coordenadaAtaque = coordenadaDeAtaque[0].ToString() + coordenadaDeAtaque[1].ToString();
                for (int i = 0; i < tableroJugador.GetLength(0); i++)
                {
                    for (int j = 0; j < tableroJugador.GetLength(1); j++)
                    {
                        if (tableroJugador[i, j] == coordenadaAtaque)
                        {
                            string pictureBarco = "bar" + coordenadaAtaque;
                            PictureBox newPicture = (PictureBox)Controls[pictureBarco];
                            newPicture.Visible = false;
                            string pictureSelec = "selec" + coordenadaAtaque;
                            PictureBox newPictureSelec = (PictureBox)Controls[pictureSelec];
                            newPictureSelec.Visible = false;
                            puntosPc++;
                        }
                    }

                }
            }
            
            if(contadorAtaques>=valor)
            {

                MessageBox.Show("Se han terminado tus turnos");
                btnatacar.Enabled = false;
                btnpuntos.Enabled = true;
            }
            btnatacar.Enabled = false;
        }
        private void block_fichas(object sender, EventArgs e)
        {
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            valor = trackBar1.Value;
            label3.Text =valor.ToString();
           
            
        }

        private void btnreinicio_Click(object sender, EventArgs e)
        {
            btnreinicio.Visible = false;
            Form1 fm = new Form1();
            this.Hide();
            fm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Comprobor si Se ha atacado un barco enemigo e incrementar un punto al jugador
            //Se verifica si ambas imagenes visible son igual a false, ya que al seleccionar cada imagen por el jugador
            //esta pasa a estado visible = false, y si no hay barco queda visible solo la imagen check, en caso contrario
            //se revela el ataque del barco y la imagen check pasa a false
            if (inip00.Visible == false && chek00.Visible == false) { puntosJugador++; }
            if (inip01.Visible == false && chek01.Visible == false) { puntosJugador++; }
            if (inip02.Visible == false && chek02.Visible == false) { puntosJugador++; }
            if (inip03.Visible == false && chek03.Visible == false) { puntosJugador++; }
            if (inip04.Visible == false && chek04.Visible == false) { puntosJugador++; }
            if (inip05.Visible == false && chek05.Visible == false) { puntosJugador++; }
            if (inip10.Visible == false && chek10.Visible == false) { puntosJugador++; }
            if (inip11.Visible == false && chek11.Visible == false) { puntosJugador++; }
            if (inip12.Visible == false && chek12.Visible == false) { puntosJugador++; }
            if (inip13.Visible == false && chek13.Visible == false) { puntosJugador++; }
            if (inip14.Visible == false && chek14.Visible == false) { puntosJugador++; }
            if (inip15.Visible == false && chek15.Visible == false) { puntosJugador++; }
            if (inip20.Visible == false && chek20.Visible == false) { puntosJugador++; }
            if (inip21.Visible == false && chek21.Visible == false) { puntosJugador++; }
            if (inip22.Visible == false && chek22.Visible == false) { puntosJugador++; }
            if (inip23.Visible == false && chek23.Visible == false) { puntosJugador++; }
            if (inip24.Visible == false && chek24.Visible == false) { puntosJugador++; }
            if (inip25.Visible == false && chek25.Visible == false) { puntosJugador++; }
            if (inip30.Visible == false && chek30.Visible == false) { puntosJugador++; }
            if (inip31.Visible == false && chek31.Visible == false) { puntosJugador++; }
            if (inip32.Visible == false && chek32.Visible == false) { puntosJugador++; }
            if (inip33.Visible == false && chek33.Visible == false) { puntosJugador++; }
            if (inip34.Visible == false && chek34.Visible == false) { puntosJugador++; }
            if (inip35.Visible == false && chek35.Visible == false) { puntosJugador++; }
            if (inip40.Visible == false && chek40.Visible == false) { puntosJugador++; }
            if (inip41.Visible == false && chek41.Visible == false) { puntosJugador++; }
            if (inip42.Visible == false && chek42.Visible == false) { puntosJugador++; }
            if (inip43.Visible == false && chek43.Visible == false) { puntosJugador++; }
            if (inip44.Visible == false && chek44.Visible == false) { puntosJugador++; }
            if (inip45.Visible == false && chek45.Visible == false) { puntosJugador++; }
            if (inip50.Visible == false && chek50.Visible == false) { puntosJugador++; }
            if (inip51.Visible == false && chek51.Visible == false) { puntosJugador++; }
            if (inip52.Visible == false && chek52.Visible == false) { puntosJugador++; }
            if (inip53.Visible == false && chek53.Visible == false) { puntosJugador++; }
            if (inip54.Visible == false && chek54.Visible == false) { puntosJugador++; }
            if (inip55.Visible == false && chek55.Visible == false) { puntosJugador++; }
            MessageBox.Show("PUNTUACION\n" + "Jugador: " + puntosJugador.ToString() + ": Pc: " + puntosPc.ToString());
            if(puntosJugador>puntosPc)
            {
                MessageBox.Show("Ganador\n Usuario 🎇🎇🎇");
            }
            else if(puntosPc== puntosJugador)
            {
                MessageBox.Show("EMPATE\n Ve ha por una revancha 💣💣💣");
            }
            else
            {
                MessageBox.Show("Ganador\n PC ️🖱️");
                
            }
            btnpuntos.Enabled =false;

        }
    }
}
