using System.Drawing.Text;

namespace JogoDaVelha
{
    public partial class Form1 : Form
    {

        int XPlayer = 0, OPlayer = 0, EmpatesPontos = 0, rondas = 0;
        bool turno = true, jogo_final = false;
        string[] texto = new string[9];
        // true = x || false = O
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        void Check(int CheckPlayer)
        {
            string suporte = "";

            if (CheckPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            } // fim Suporte



            //Check Horizontal
            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {
                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])

                    {
                        vencedor(CheckPlayer);
                        return;
                    } // final check horizontal
                }
            } // Fim Loop Horizontal


            //Check Vertical
            for (int vertical = 0; vertical < 2; vertical+= 3)
            {
                if (suporte == texto[vertical])
                {
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])

                    {
                        vencedor(CheckPlayer);
                        return;
                    } // final check Vertical
                }
            } // fim loop Vertical



            //Verificação Diagonal
            if (texto[0] == suporte)
            {
                if (texto[0] == texto[4] && texto[0] == texto[8])

                {
                    vencedor(CheckPlayer);
                    return;
                } // Diagonal principal
            }


            //Check Vertical
            for (int vertical = 0; vertical < 3; vertical++)
            {
                if (suporte == texto[vertical])
                {
                    if (texto[vertical] == texto[vertical + 4] && texto[vertical] == texto[vertical + 8])

                    {
                        MessageBox.Show("Vertical");
                        return;
                    } // final check Vertical
                }
            } // fim loop Vertical



            //Verificação Diagonal Secundaria
            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])

                {
                    vencedor(CheckPlayer);
                    return;
                }   // Diagonal Secundaria
            }

            if (rondas == 9 && jogo_final == false)
            {
                EmpatesPontos++;
                PontuacaoEmpates.Text = Convert.ToString(EmpatesPontos);
                MessageBox.Show("Empate!");
                jogo_final = true;
                return;
            }


        }



        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;

            if (btn.Text == "" && jogo_final == false)
            {
                if (turno)
                {
                    btn.Text = "X";
                    texto[buttonIndex] = btn.Text;
                    rondas++;
                    turno = !turno;
                    Check(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = btn.Text;
                    rondas++;
                    turno = !turno;
                    Check(2);
                }

                // fim estrutura criada
            }
        }   // fim método


        void vencedor(int PlayerVencedor)
        {
            jogo_final = true;
            if (PlayerVencedor == 1)
            {
                XPlayer++;
                PontuacaoX.Text = Convert.ToString(XPlayer);
                MessageBox.Show("Jogador X Venceu");
                turno = true;
            }
            else
            {
                OPlayer++;
                PontuacaoO.Text = Convert.ToString(OPlayer);
                MessageBox.Show("Jogador O Venceu");
                turno = false;
            }




            
         void btnclean_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                int buttonIndex = btn.TabIndex;
                btn.Text = "";
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                rondas = 0;
                jogo_final = false;
                for (int i = 0; i < 9; i++)
                {
                    texto[i] = "";
                }
            }

        }
    }
}