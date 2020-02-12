using Calculadora.BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Media;

namespace Calculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        Operadora calc = new Operadora();


        public MainWindow()
        {
            InitializeComponent();

            ValoresBotones();

            Operaciones();


            txtNumero.Focus();

        }


      


        public void Operaciones()
        {

            

            btnIgual.Click += delegate
            {
                if (!txtNumero.Text.Equals(""))
                { 

                    if(calc.Numero1 != 0)
                        calc.Numero2 = Convert.ToDouble(txtNumero.Text);
                    else
                    {
                        calc.Numero1 = Convert.ToDouble(txtNumero.Text);

                        txtTotal.Text = txtNumero.Text;
                    }



                    if (ValidarOperador(txtCadena.Text))
                    {
                        txtCadena.Text += calc.Operacion;
                        calc.Numero1 = Convert.ToDouble(txtTotal.Text);
                        txtTotal.Text = txtNumero.Text;
                    }
                    else
                    {
                        if(txtCadena.Text.Length > 0)
                        {
                            txtCadena.Text = remplazar(txtCadena.Text, calc.Operacion)+"";
                            txtTotal.Text = txtNumero.Text;
                        }
                            
                       
                    }
                        
                    txtCadena.Text += txtNumero.Text;

                    if(!calc.Operacion.Equals(""))
                        txtTotal.Text = calc.operacion() + "";


                    txtNumero.Text = "";

                    Console.WriteLine(calc.Numero1);
                    Console.WriteLine(calc.Numero2);
                    Console.WriteLine(calc.Operacion);
                    Console.WriteLine(calc.operacion());
                }
   
            };



            btnSuma.Click += delegate
            {
                if (!txtNumero.Text.Equals(""))
                {
                    if (txtTotal.Text.Equals(""))
                    {
                        if (!txtNumero.Text.Equals(""))
                        {
                            calc.Numero1 = Convert.ToDouble(txtNumero.Text);

                            txtCadena.Text += txtNumero.Text + " +";
                        }

                        if (calc.Numero1 == 0)
                        {
                            txtCadena.Text = remplazar(txtCadena.Text, "+");
                        }

                        calc.Operacion = "+";

                        txtNumero.Text = "";
                    }
                    else
                    {

                        calc.Numero1 = Convert.ToDouble(txtTotal.Text);

                        if (ValidarOperador(txtCadena.Text))
                            txtCadena.Text += " +";

                        if (calc.Numero1 == 0)
                        {
                            txtCadena.Text = remplazar(txtCadena.Text, "+");
                        }
                        calc.Operacion = "+";

                        txtNumero.Text = "";
                    }
                }
               

            };




            btnResta.Click += delegate
            {
                if (!txtNumero.Text.Equals(""))
                {
                    if (txtTotal.Text.Equals(""))
                    {
                        if (!txtNumero.Text.Equals(""))
                        {
                            calc.Numero1 = Convert.ToDouble(txtNumero.Text);

                            txtCadena.Text += txtNumero.Text + " -";
                        }
                        txtCadena.Text = remplazar(txtCadena.Text, "-");

                        calc.Operacion = "-";

                        txtNumero.Text = "";
                    }
                    else
                    {

                        calc.Numero1 = Convert.ToDouble(txtTotal.Text);

                        if (ValidarOperador(txtCadena.Text))
                            txtCadena.Text += " -";

                        txtCadena.Text = remplazar(txtCadena.Text, "-");

                        calc.Operacion = "-";

                        txtNumero.Text = "";
                    }
                }
               

            };

            btnMult.Click += delegate
            {
                if (!txtNumero.Text.Equals(""))
                {
                    if (txtTotal.Text.Equals(""))
                    {
                        if (!txtNumero.Text.Equals(""))
                        {
                            calc.Numero1 = Convert.ToDouble(txtNumero.Text);

                            txtCadena.Text += txtNumero.Text + " *";
                        }
                        txtCadena.Text = remplazar(txtCadena.Text, "*");

                        calc.Operacion = "*";

                        txtNumero.Text = "";
                    }
                    else
                    {

                        calc.Numero1 = Convert.ToDouble(txtTotal.Text);

                        if (ValidarOperador(txtCadena.Text))
                            txtCadena.Text += " *";

                        txtCadena.Text = remplazar(txtCadena.Text, "*");

                        calc.Operacion = "*";

                        txtNumero.Text = "";
                    }
                }
                    

            };

            btnDiv.Click += delegate
            {
                if (!txtNumero.Text.Equals(""))
                {
                    if (txtTotal.Text.Equals(""))
                    {
                        if (!txtNumero.Text.Equals(""))
                        {
                            calc.Numero1 = Convert.ToDouble(txtNumero.Text);

                            txtCadena.Text += txtNumero.Text + " /";
                        }
                        txtCadena.Text = remplazar(txtCadena.Text, "/");

                        calc.Operacion = "/";

                        txtNumero.Text = "";
                    }
                    else
                    {

                        calc.Numero1 = Convert.ToDouble(txtTotal.Text);

                        if (ValidarOperador(txtCadena.Text))
                            txtCadena.Text += " /";

                        txtCadena.Text = remplazar(txtCadena.Text, "/");

                        calc.Operacion = "/";

                        txtNumero.Text = "";
                    }

                }
                   
            };
        }

        public string remplazar(string cadena, string operador)
        {
           

            char[] cadChar = cadena.ToCharArray();

            int cad = cadChar.Length;

            cadena = cadena.Substring(0, cad - 1) + operador;

            return cadena;
        }

        public Boolean ValidarOperador(string cadena)
        {
            Boolean ban = true;
            if (cadena.Equals(""))
            {
                ban = false;
            }
            else
            { 
                char[] cadChar = cadena.ToCharArray();

                int cad = cadChar.Length;

                if ((cadChar[cad - 1] == '+') || (cadChar[cad - 1] == '-') || (cadChar[cad - 1] == '*') || (cadChar[cad - 1] == '/'))
                {
                    ban = false;
                }
            }

            return ban;
        }




        public void ValoresBotones()
        {
            btn0.Click += delegate
            {
                txtNumero.Text += "0";
            };
            btn1.Click += delegate
            {
                txtNumero.Text += "1"; 
            };
            btn2.Click += delegate
            {
                txtNumero.Text += "2";
            };
            btn3.Click += delegate
            {
                txtNumero.Text += "3";
            };
            btn4.Click += delegate
            {
                txtNumero.Text += "4";
            };
            btn5.Click += delegate
            {
                txtNumero.Text += "5";
            };
            btn6.Click += delegate
            {
                txtNumero.Text += "6";
            };
            btn7.Click += delegate
            {
                txtNumero.Text += "7";
            };
            btn8.Click += delegate
            {
                txtNumero.Text += "8";
            };
            btn9.Click += delegate
            {
                txtNumero.Text += "9";
            };
            btnPunto.Click += delegate
            {
                txtNumero.Text += ".";
            };
            btnBorrarTodo.Click += delegate
            {
                txtNumero.Text = "";
                txtTotal.Text = "";
                txtCadena.Text = "";
            };
            btnBorrarCasilla.Click += delegate
            {
                txtNumero.Text = "";

                
            };
            btnBorrar1.Click += delegate
            {
                char[] num =  txtNumero.Text.ToCharArray();
                int numCar = num.Length;
                numCar--;
                txtNumero.Text = "";
                for (int i =0; i<numCar; i++)
                {
                    txtNumero.Text += num[i];
                }
            };

        }

        private void OnGotFocusHandler(object sender, RoutedEventArgs e)
        {
            Button tb = e.Source as Button;
            tb.Foreground = Brushes.Black;
        }
        // Raised when Button losses focus. 
        // Changes the color of the Button back to white.
        private void OnLostFocusHandler(object sender, RoutedEventArgs e)
        {
            Button tb = e.Source as Button;
            tb.Foreground = Brushes.White;
        }

        private void txtNumero_TextChanged(object sender, TextChangedEventArgs e)
        {
            string numero = txtNumero.Text;

            try
            {
                double num = Convert.ToDouble(numero);
                
            }
            catch(Exception ex)
            {
                string texto = txtNumero.Text;
                char[] cadChar = texto.ToCharArray();

                int cad = cadChar.Length;

                Console.WriteLine(cad);

                if (cad > 0)
                {
                    texto = texto.Substring(0, cad - 1);

                    txtNumero.Text = texto;
                }

                txtNumero.Focus();
            }
        }
    }
}
