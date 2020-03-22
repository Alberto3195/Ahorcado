using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form1 : Form
    {
        //Almacena la palabra a adivinar
        string palabraOculta = "";
        //Variable que almacena el numero de fallos
        int numeroFallos = 0;
        //Booleano que indica que la partida no esta finalizada
        Boolean partidaTerminada = false;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.ahorcado_0;
            palabraOculta = Palabra();
            String auxiliar = "";
            for (int i = 0; i < palabraOculta.Length; i++)
            {
                auxiliar = auxiliar + "_ ";
            }
            label1.Text = auxiliar;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            string letra = boton.Text;
            letra = letra.ToUpper();
            //Chequear si la letra se encuentra en la palabra oculta
            if (!partidaTerminada)
            {
                if (palabraOculta.Contains(letra))
                {
                    for (int i = 0; i < palabraOculta.Length; i++)//Ponemos la letra en los huecos correspondientes
                    {
                        if (palabraOculta[i] == letra[0])
                        {
                         //Si esta la palabra la ponemos donde los guiones
                         //quita el guión bajo de la letra que corresponda
                            label1.Text = label1.Text.Substring(0, 2 * i)
                                    + letra
                                    + label1.Text.Substring(2 * i + 1);
                        }
                    }
                    int posicion = palabraOculta.IndexOf(letra);
                    label1.Text = label1.Text.Remove(2 * posicion, 1).Insert(2 * posicion, letra);

                }
                else
                {
                    numeroFallos++;
                }
                boton.Enabled = false;
            }
            if (!label1.Text.Contains('_'))
            {
                numeroFallos = -100;
            }
            switch (numeroFallos)
            {
                case 0: pictureBox1.Image = Properties.Resources.ahorcado_0; break;
                case 1: pictureBox1.Image = Properties.Resources.ahorcado_1; break;
                case 2: pictureBox1.Image = Properties.Resources.ahorcado_2; break;
                case 3: pictureBox1.Image = Properties.Resources.ahorcado_3; break;
                case 4: pictureBox1.Image = Properties.Resources.ahorcado_4; break;
                case 5: pictureBox1.Image = Properties.Resources.ahorcado_5; break;
                case 6: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
                case -100: pictureBox1.Image = Properties.Resources.acertasteTodo; break;
                default: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
            }
        }
        public string Palabra()
        {
            String[] listaPalabras = { "HOLA", "HALAMADRID", "FRAXITO", 
                "PUEBLEO", "BABYYODA", "NIKONE", "CANON", "ANDROID", "HUAWEI" };
            Random aleatorio = new Random();
            int pos = aleatorio.Next(listaPalabras.Length);
            return listaPalabras[pos].ToUpper();
        }
    }
}
