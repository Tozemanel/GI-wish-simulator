using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desocnt_manager
{
    public partial class Form1 : Form
    {
        int fives = 0, fours = 0, tres = 0, total = 0, pity1 = 0, pity2 = 0;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_roll_Click(object sender, EventArgs e)
        {
            
            if (cb_alwreset.Checked)
            {
                tres = 0;
                fours = 0;
                fives = 0;
                total = 0;
                pity1 = 0;
                pity2 = 0;
            }

            Random decider = new Random();
            float gota4 = float.Parse(txt_4star.Text) * 10, gota5 = float.Parse(txt_5star.Text) * 10;
            
            //pity calculator
            if (pity2 >= int.Parse(txt_5sp.Text)-1)
            {
                fives++;
                total++;
                pity2 = 0;
                pity1++;
            }
            else if (pity1 >= int.Parse(txt_4sp.Text) - 1)
            {
                fours++;
                total++;
                pity2++;
                pity1 = 0;
            }
            else
            {
                //generator propriamente dito
                if ((decider.Next(0, 1000) < gota5))
                {
                    fives++;
                    total++;
                    pity2 = 0;
                    pity1++;
                }

                else if (decider.Next(0, 1000) < (gota5 + gota4))
                {
                    fours++;
                    total++;
                    pity2++;
                    pity1 = 0;
                }
                else
                {
                    tres++;
                    total++;
                    pity2++;
                    pity1++;
                }
                
            }

            //update labels
            lbl_3s.Text = tres.ToString();
            lbl_4s.Text = fours.ToString();
            lbl_5s.Text = fives.ToString();
            lbl_total.Text = "Total Wishes: " + total.ToString();
            lbl_3sp.Text = (((double)tres) / ((double)total)).ToString("P2");
            lbl_4sp.Text = (((double)fours) / ((double)total)).ToString("P2");
            lbl_5sp.Text = (((double)fives) / ((double)total)).ToString("P2");

            
        }

        private void cb_hide_CheckedChanged(object sender, EventArgs e)
        {
            if (! cb_hide.Checked)
            {
                //showstuff
                btn_st.Visible = true;
                cb_custom.Visible = true;
                if (cb_custom.Checked)
                    txt_custom.Visible = true;
                else
                    txt_custom.Visible = false;
                this.Height = 375;
                
            }
            else
            {
                //Hidestuff
                btn_st.Visible = false;
                cb_custom.Visible = false;
                txt_custom.Visible = false;
                this.Height = 294;

                //stop the timered rolling
                if (timer_stater.Enabled)
                {
                    timer_stater.Stop();
                    btn_st.Text = "Start";
                    cb_alwreset.Enabled = true;
                }
            }
        }

        private void timer_stater_Tick(object sender, EventArgs e)
        {
            
            Random decider = new Random();
            float gota4 = float.Parse(txt_4star.Text) * 10, gota5 = float.Parse(txt_5star.Text) * 10;

            //pity calculator
            if (pity2 >= int.Parse(txt_5sp.Text) - 1)
            {
                fives++;
                total++;
                pity2 = 0;
                pity1++;
            }
            else if (pity1 >= int.Parse(txt_4sp.Text) - 1)
            {
                fours++;
                total++;
                pity2++;
                pity1 = 0;
            }
            else
            {
                //generator propriamente dito
                if ((decider.Next(0, 1000) < gota5))
                {
                    fives++;
                    total++;
                    pity2 = 0;
                    pity1++;
                }

                else if (decider.Next(0, 1000) < (gota5 + gota4))
                {
                    fours++;
                    total++;
                    pity2++;
                    pity1 = 0;
                }
                else
                {
                    tres++;
                    total++;
                    pity2++;
                    pity1++;
                }

            }

            //update labels
            lbl_3s.Text = tres.ToString();
            lbl_4s.Text = fours.ToString();
            lbl_5s.Text = fives.ToString();
            lbl_total.Text = "Total Wishes: " + total.ToString();
            lbl_3sp.Text = (((double)tres) / ((double)total)).ToString("P2");
            lbl_4sp.Text = (((double)fours) / ((double)total)).ToString("P2");
            lbl_5sp.Text = (((double)fives) / ((double)total)).ToString("P2");
        }

        private void txt_custom_TextChanged(object sender, EventArgs e)
        {
            int cahe = 0;
            if (txt_custom.Text == "" || !int.TryParse(txt_custom.Text, out cahe) && cahe < 1)
            {
                btn_st.Enabled = false;
                
            }
            else
                btn_st.Enabled = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = 294;
            this.ActiveControl = label1;
        }

        private void txt_4star_TextChanged(object sender, EventArgs e)
        {
            
            //stop the timered rolling
            if (timer_stater.Enabled)
            {
                timer_stater.Stop();
                btn_st.Text = "Start";
                cb_alwreset.Enabled = true;
            }
        }

        private void txt_5star_TextChanged(object sender, EventArgs e)
        {
            
            //stop the timered rolling
            if (timer_stater.Enabled)
            {
                timer_stater.Stop();
                btn_st.Text = "Start";
                cb_alwreset.Enabled = true;
            }
        }

        private void txt_5sp_TextChanged(object sender, EventArgs e)
        {
            //stop the timered rolling
            if (timer_stater.Enabled)
            {
                timer_stater.Stop();
                btn_st.Text = "Start";
                cb_alwreset.Enabled = true;
            }
        }

        private void txt_4sp_TextChanged(object sender, EventArgs e)
        {
            //stop the timered rolling
            if (timer_stater.Enabled)
            {
                timer_stater.Stop();
                btn_st.Text = "Start";
                cb_alwreset.Enabled = true;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is small Windows Form I made in C#, as a humble attempt to simulate GI's whishing system, particulary with the Statistical Mode. \n\nEssentially, I made this because I had to study for a pratical test and had no more exercices to solve, so I made my own, with the advantage of also possibly being of some use, to someone. \n\nEnjoy, and hopefully it shall indeed be as rewarding to you as wishing in game, eheh. \n\n Props to the M developer for the low rates. Stonks! \n\n\nMade by your fellow traveller, u/Tozemanel.", "About");
        }

        private void btn_pull_Click(object sender, EventArgs e)
        {
            Random decider = new Random();
            float gota4 = float.Parse(txt_4star.Text) * 10, gota5 = float.Parse(txt_5star.Text) * 10;
              
            if (cb_alwreset.Checked)
            {
                tres = 0;
                fours = 0;
                fives = 0;
                total = 0;
                pity1 = 0;
                pity2 = 0;
            }

            for (int i = 1; i <= 10; i++)
            {
                //pity calculator
                if (pity2 >= int.Parse(txt_5sp.Text) - 1)
                {
                    fives++;
                    total++;
                    pity2 = 0;
                    pity1++;
                }
                else if (pity1 >= int.Parse(txt_4sp.Text) - 1)
                {
                    fours++;
                    total++;
                    pity2++;
                    pity1 = 0;
                }
                else
                {
                    //generator propriamente dito
                    if ((decider.Next(0, 1000) < gota5))
                    {
                        fives++;
                        total++;
                        pity2 = 0;
                        pity1++;
                    }

                    else if (decider.Next(0, 1000) < (gota5 + gota4))
                    {
                        fours++;
                        total++;
                        pity2++;
                        pity1 = 0;
                    }
                    else
                    {
                        tres++;
                        total++;
                        pity2++;
                        pity1++;
                    }
                }
            }

            //uptade labels
            lbl_3s.Text = tres.ToString();
            lbl_4s.Text = fours.ToString();
            lbl_5s.Text = fives.ToString();
            lbl_total.Text = "Total Wishes: " + total.ToString();
            lbl_3sp.Text = (((double)tres) / ((double)total)).ToString("P2");
            lbl_4sp.Text = (((double)fours) / ((double)total)).ToString("P2");
            lbl_5sp.Text = (((double)fives) / ((double)total)).ToString("P2");

            
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            tres = 0;
            fours = 0;
            fives = 0;
            total = 0;
            pity1 = 0;
            pity2 = 0;
            lbl_3s.Text = tres.ToString();
            lbl_4s.Text = fours.ToString();
            lbl_5s.Text = fives.ToString();
            lbl_total.Text = "Total Wishes: " + total.ToString();
            lbl_3sp.Text = "0 %";
            lbl_4sp.Text = "0 %";
            lbl_5sp.Text = "0 %";
            txt_custom.Text = "";

            
        }

        private void btn_st_Click(object sender, EventArgs e)
        {
            //acting as start to a custom amount
            if (cb_custom.Checked)
            {
                if (cb_alwreset.Checked)
                {
                    tres = 0;
                    fours = 0;
                    fives = 0;
                    total = 0;
                    pity1 = 0;
                    pity2 = 0;
                }
                Random decider2 = new Random();
                float gota4 = float.Parse(txt_4star.Text) * 10, gota5 = float.Parse(txt_5star.Text) * 10;

                for (int i = 1; i <= int.Parse(txt_custom.Text); i++)
                {
                    //pity calculator
                    if (pity2 >= int.Parse(txt_5sp.Text) - 1)
                    {
                        fives++;
                        total++;
                        pity2 = 0;
                        pity1++;
                    }
                    else if (pity1 >= int.Parse(txt_4sp.Text) - 1)
                    {
                        fours++;
                        total++;
                        pity2++;
                        pity1 = 0;
                    }
                    else
                    {
                        //generator propriamente dito
                        if ((decider2.Next(0, 1000) < gota5))
                        {
                            fives++;
                            total++;
                            pity2 = 0;
                            pity1++;
                        }

                        else if (decider2.Next(0, 1000) < (gota5 + gota4))
                        {
                            fours++;
                            total++;
                            pity2++;
                            pity1 = 0;
                        }
                        else
                        {
                            tres++;
                            total++;
                            pity2++;
                            pity1++;
                        }
                    }
                }
                //uptade labels
                lbl_3s.Text = tres.ToString();
                lbl_4s.Text = fours.ToString();
                lbl_5s.Text = fives.ToString();
                lbl_total.Text = "Total Wishes: " + total.ToString();
                lbl_3sp.Text = (((double)tres) / ((double)total)).ToString("P2");
                lbl_4sp.Text = (((double)fours) / ((double)total)).ToString("P2");
                lbl_5sp.Text = (((double)fives) / ((double)total)).ToString("P2");

            }
            //acting as a start/stop for timered rolling
            else
            {
                if (btn_st.Text == "Start")
                {
                    timer_stater.Start();
                    btn_st.Text = "Stop";
                    cb_alwreset.Enabled = false;
                }
                else
                {
                    timer_stater.Stop();
                    btn_st.Text = "Start";
                    cb_alwreset.Enabled = true;
                }
            }
        
        }

        private void cb_custom_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_custom.Checked)
            {
                //stop the timered rolling
                timer_stater.Stop();
                btn_st.Text = "Start";
                cb_alwreset.Enabled = true;

                txt_custom.Visible = true;
                btn_st.Text = "Go";    
                          
                int cahe = 0;
                if (txt_custom.Text == "" || !int.TryParse(txt_custom.Text, out cahe) && cahe < 1)
                {
                    btn_st.Enabled = false;                    
                }

                else
                    btn_st.Enabled = true;
            }
            else
            {
                txt_custom.Visible = false;
                btn_st.Enabled = true;
                btn_st.Text = "Start";
                if (cb_alwreset.Checked)
                    btn_st.Enabled = false;
            }

        }

        private void cb_alwreset_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_alwreset.Checked)
            {
                lbl_total.Visible = false;

                //stop the timered rolling
                if (timer_stater.Enabled)
                {
                    timer_stater.Stop();
                    btn_st.Text = "Start";
                    cb_alwreset.Enabled = true;
                }

                if (! cb_custom.Checked)
                {
                    btn_st.Enabled = false;
                }
                

                tres = 0;
                fours = 0;
                fives = 0;
                total = 0;
                pity1 = 0;
                pity2 = 0;
                lbl_3s.Text = tres.ToString();
                lbl_4s.Text = fours.ToString();
                lbl_5s.Text = fives.ToString();
                lbl_total.Text = "Total Wishes: " + total.ToString();
                lbl_3sp.Text = "0 %";
                lbl_4sp.Text = "0 %";
                lbl_5sp.Text = "0 %";


            }
            else
            {
                lbl_total.Visible = true;
                if (! cb_custom.Checked)
                    btn_st.Enabled = true;
            }
        }
    }
}
