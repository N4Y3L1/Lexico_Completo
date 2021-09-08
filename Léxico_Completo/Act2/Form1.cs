
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Act2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string frase = original.Text;
            int indice = 0;
            int estado = 0;
            int estadoFinal = -1;
            string lexema = "";
            string token;
           
            tabla.Columns.Add("ID", "ID");
            tabla.Columns.Add("Lexema", "Lexema");
            tabla.Columns.Add("Token", "Token");

            while ((indice <= (frase.Length - 1)) && (estadoFinal == -1))
            {
                lexema = " ";
                token = "error";
                while ((indice <= (frase.Length - 1)) && (estadoFinal != 25))
                {
                    if (estadoFinal == -1)
                    {
                        if (char.IsWhiteSpace(frase[indice]))
                        {
                            estadoFinal = -1;
                        }
                        else if (char.IsLetter(frase[indice]) || frase[indice] == '_')
                        {
                            estado = 0;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "identificador";
                        }
                        else if (char.IsDigit(frase[indice]))
                        {
                            estado = 1;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "entero";
                        }
                        else if (frase[indice] == '+' || frase[indice] == '-')
                        {
                            estado = 5;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "opSuma";
                        }
                        else if (frase[indice] == '/' || frase[indice] == '*')
                        {
                            estado = 6;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "opMultiplicación";
                        }
                        else if (frase[indice] == '<' || frase[indice] == '>')
                        {
                            estado = 7;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "opRelacional";
                        }
                        else if (frase[indice] == '|')
                        {
                            estado = 8;

                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "error";
                        }
                        else if (frase[indice] == '&')
                        {
                            estado = 9;

                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "error";
                        }
                        else if (frase[indice] == '!')
                        {
                            estado = 10;

                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "opNot";
                        }
                        else if (frase[indice] == '=')
                        {
                            estado = 18;

                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "igual";
                        }
                        else if (frase[indice] == ';')
                        {
                            estado = 12;
                            estadoFinal = estado;

                            lexema += frase[indice];
                            token = "punto y coma";
                        }
                        else if (frase[indice] == ',')
                        {
                            estado = 13;
                            estadoFinal = estado;

                            lexema += frase[indice];
                            token = "coma";
                        }
                        else if (frase[indice] == '(')
                        {
                            estado = 14;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "parentesis izquierdo";
                        }
                        else if (frase[indice] == ')')
                        {
                            estado = 15;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "parentesis derecho";
                        }
                        else if (frase[indice] == '{')
                        {
                            estado = 16;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "corchete izquierdo";
                        }
                        else if (frase[indice] == '}')
                        {
                            estado = 17;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "corchete derecho";
                        }
                        else if (frase[indice] == '$')
                        {
                            estado = 23;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "pesos";
                        }
                        else
                        {
                            estadoFinal = 25;
                            lexema = frase[indice].ToString();
                            token = "error";
                        }
                        indice++;
                    }
                    else if (estadoFinal == -1)
                    {
                        estadoFinal = 25; 
                    }
                    else if (estadoFinal == 0)
                    {
                        if (char.IsLetter(frase[indice]) || frase[indice] == '_')
                        {
                            estado = 0;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "identificador";
                            indice++;
                        }
                        else if (char.IsDigit(frase[indice]))
                        {
                            estado = 0;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "identificador";
                            indice++;
                        }
                        else
                        {
                            estadoFinal = 25;
                        }
                    }
                    else if (estadoFinal == 1)
                    {
                        if (char.IsDigit(frase[indice]))
                        {
                            estado = 1;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "entero";
                            indice++;
                        }
                        else if (frase[indice] == '.')
                        {
                            estado = 24;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "error";
                            indice++;
                        }
                        else
                        {
                            estadoFinal = 25;
                        }
                    }
                    else if(estadoFinal == 5)
                    {
                        estadoFinal = 25;   
                    }
                    else if (estadoFinal == 6)
                    {
                        estadoFinal = 25;
                    }
                    else if (estadoFinal == 7)
                    {
                        if (frase[indice] == '=')
                        {
                            estado = 7;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "opRelacional";
                            indice++;
                        }
                        else
                        {
                            estadoFinal = 25;

                        }
                    }
                    else if (estadoFinal == 8)
                    {
                        if (frase[indice] == '|')
                        {
                            estado = 8;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "opOr";
                            indice++;
                        }
                        else
                        {
                            estadoFinal = 25;

                        }
                    }
                    else if (estadoFinal == 9)
                    {
                        if (frase[indice] == '&')
                        {
                            estado = 9;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "opAnd";
                            indice++;
                        }
                        else
                        {
                            estadoFinal = 25;

                        }
                    }
                    else if (estadoFinal == 10)
                    {
                        if (frase[indice] == '=')
                        {
                            estado = 9;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "opIgualdad";
                            indice++;
                        }
                        else
                        {
                            estadoFinal = 25;
                        }
                    }
                    else if (estadoFinal == 18)
                    {
                        if (frase[indice] == '=')
                        {
                            estado = 9;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "opIgualdad";
                            indice++;
                        }
                        else
                        {
                            estadoFinal = 25;
                        }
                    }
                    else if (estadoFinal == 12)
                    {
                        estadoFinal = 25;
                    }
                    else if (estadoFinal == 13)
                    {
                        estadoFinal = 25;
                    }
                    else if (estadoFinal == 14)
                    {
                        estadoFinal = 25;
                    }
                    else if (estadoFinal == 15)
                    {
                        estadoFinal = 25;
                    }
                    else if (estadoFinal == 16)
                    {
                        if (char.IsLetter(frase[indice]) || frase[indice] == '_')
                        {
                            estado = 1;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "id";
                            indice++;

                        }
                        else
                        {
                            estadoFinal = 25;
                        }
                    }
                    else if (estadoFinal == 17)
                    {
                        estadoFinal = 25;
                    }
                    else if (estadoFinal == 23)
                    {
                        estadoFinal = 25;
                    }
                    else if (estadoFinal == 24)
                    {
                        if (char.IsDigit(frase[indice]))
                        {
                            estado = 1;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "Numero real";
                            indice++;
                        }
                        else
                        {
                            estadoFinal = 25;
                        }
                    }

                }

                if (lexema == " if")
                {
                    estado = 19;
                    estadoFinal = estado;
                    token = "IF";
                    indice++;
                }
                else if (lexema == " while")
                {
                    estado = 20;
                    estadoFinal = estado;
                    token = "While";
                    indice++;
                }
                else if (lexema == " return")
                {
                    estado = 21;
                    estadoFinal = estado;
                    token = "Return";
                    indice++;
                }
                else if (lexema == " else")
                {
                    estado = 22;
                    estadoFinal = estado;
                    token = "Else";
                    indice++;
                }
                else if ((lexema == " int") || (lexema == " float") || (lexema == " void"))
                {
                    estado = 4;
                    token = "Tipo de Dato";
                    indice++;
                }

                tabla.Rows.Add(estado, lexema, token);
                estadoFinal = -1;
            }
        }
    }
}
















/* Pruebas:

int main(){

int isla = 0;

if (a==b){
  cout<<"Hola, Mundo$"<<endl;
}else{
  cout<<"Adios, Mundo$"<<endl;
}

while( (a==b) && (c==d) ){
  cout<<"Ciclo"<<endl;
  a = b+c;
  a = b-c;
  a = b*c;
  a = b/c;
}

}
return 0;
}*/
