using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using System.Xml.Linq;

namespace EnglishPremierLeague
{
    public partial class Form1 : Form
    {
        static string server = "localhost";
        static string database = "premierleaguedata";
        static string uid = "root";
        static string password = "";
        string constring = "Server=" + server + "; database=" + database + "; uid=" + uid + "; pwd=" + password + "; Allow Zero Datetime=True;";
        int menu = 1;

        DataTable dbdataset = new DataTable();

        public Form1()
        {
            InitializeComponent();
            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;
            menu1();
        }

        public void menu1()
        {
            menu = 1;
            panel1.Controls.Clear();
            label1.Text = "Select Team";
            label2.Text = "Select Player";
            get_team();
        }

        public void menu2()
        {
            menu = 2;
            panel1.Controls.Clear();
            label1.Text = "Pick Team";
            label2.Text = "Select Match";
            get_team();
        }

        public void get_team()
        {
            MySqlConnection con = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT team_name FROM player_data", con);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                dbdataset.Clear();
                sda.SelectCommand = cmd;
                sda.Fill(dbdataset);
                comboBox1.Items.Clear();
                for (int i = 0; i < dbdataset.Rows.Count; i++)
                {
                    comboBox1.Items.Add(dbdataset.Rows[i]["team_name"].ToString());
                }
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        public void getdata_player(String team)
        {
            MySqlConnection con = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM player_data", con);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                dbdataset.Clear();
                sda.SelectCommand = cmd;
                sda.Fill(dbdataset);

                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if(menu == 1) 
            {
                ComboBox cmb = (ComboBox)sender;
                string selectedValue = cmb.SelectedItem.ToString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand("SELECT name FROM player_data WHERE team_name='" + selectedValue + "'", con);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    dbdataset.Clear();
                    sda.SelectCommand = cmd;
                    sda.Fill(dbdataset);
                    comboBox2.Items.Clear();
                    for (int i = 0; i < dbdataset.Rows.Count; i++)
                    {
                        comboBox2.Items.Add(dbdataset.Rows[i]["name"].ToString());
                    }
                    sda.Update(dbdataset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(menu == 2)
            {
                ComboBox cmb = (ComboBox)sender;
                string selectedValue = cmb.SelectedItem.ToString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT home_team, away_team FROM match_data WHERE home_team='" + selectedValue + "'", con);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    dbdataset.Clear();
                    sda.SelectCommand = cmd;
                    sda.Fill(dbdataset);
                    comboBox2.Items.Clear();
                    for (int i = 0; i < dbdataset.Rows.Count; i++)
                    {
                        comboBox2.Items.Add(dbdataset.Rows[i]["home_team"].ToString() + " vs " + dbdataset.Rows[i]["away_team"].ToString());
                    }
                    sda.Update(dbdataset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menu == 1)
            {
                ComboBox cmb = (ComboBox)sender;
                string selectedValue = cmb.SelectedItem.ToString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM player_data WHERE name='" + selectedValue + "'", con);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    dbdataset.Clear();
                    sda.SelectCommand = cmd;
                    sda.Fill(dbdataset);
                    panel1.Controls.Clear();
                    for (int i = 0; i < dbdataset.Rows.Count; i++)
                    {
                        String name = dbdataset.Rows[i]["name"].ToString();
                        String pos = dbdataset.Rows[i]["position"].ToString();
                        String play_pos = dbdataset.Rows[i]["playing_position"].ToString();
                        String team_name = dbdataset.Rows[i]["team_name"].ToString();
                        String nationality = dbdataset.Rows[i]["nationality"].ToString();
                        String YC = dbdataset.Rows[i]["yellow_card"].ToString();
                        String RC = dbdataset.Rows[i]["red_card"].ToString();
                        String GS = dbdataset.Rows[i]["goal_score"].ToString();
                        String PM = dbdataset.Rows[i]["penalty_missed"].ToString();

                        int y = 5;
                        Label lb1 = new Label();
                        lb1.Text = "Name : " + name;
                        lb1.Location = new Point(5, y);
                        lb1.Width = 600;
                        lb1.Height = 20;
                        lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        panel1.Controls.Add(lb1);
                        y += 25;

                        Label lb2 = new Label();
                        lb2.Text = "Position : " + pos;
                        lb2.Location = new Point(5, y);
                        lb2.Width = 600;
                        lb2.Height = 20;
                        lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        panel1.Controls.Add(lb2);
                        y += 25;

                        Label lb3 = new Label();
                        lb3.Text = "Playing Position : " + play_pos;
                        lb3.Location = new Point(5, y);
                        lb3.Width = 600;
                        lb3.Height = 20;
                        lb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        panel1.Controls.Add(lb3);
                        y += 25;

                        Label lb4 = new Label();
                        lb4.Text = "Team Name : " + team_name;
                        lb4.Location = new Point(5, y);
                        lb4.Width = 600;
                        lb4.Height = 20;
                        lb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        panel1.Controls.Add(lb4);
                        y += 25;

                        Label lb5 = new Label();
                        lb5.Text = "Nationality : " + nationality;
                        lb5.Location = new Point(5, y);
                        lb5.Width = 600;
                        lb5.Height = 20;
                        lb5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        panel1.Controls.Add(lb5);
                        y += 25;

                        Label lb6 = new Label();
                        lb6.Text = "Yellow Card : " + YC;
                        lb6.Location = new Point(5, y);
                        lb6.Width = 600;
                        lb6.Height = 20;
                        lb6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        panel1.Controls.Add(lb6);
                        y += 25;

                        Label lb7 = new Label();
                        lb7.Text = "Red Card : " + RC;
                        lb7.Location = new Point(5, y);
                        lb7.Width = 600;
                        lb7.Height = 20;
                        lb7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        panel1.Controls.Add(lb7);
                        y += 25;

                        Label lb8 = new Label();
                        lb8.Text = "Goal Score : " + GS;
                        lb8.Location = new Point(5, y);
                        lb8.Width = 600;
                        lb8.Height = 20;
                        lb8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        panel1.Controls.Add(lb8);
                        y += 25;

                        Label lb9 = new Label();
                        lb9.Text = "Penalty Missed : " + PM;
                        lb9.Location = new Point(5, y);
                        lb9.Width = 600;
                        lb9.Height = 20;
                        lb9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        panel1.Controls.Add(lb9);
                        y += 25;
                    }
                    sda.Update(dbdataset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if(menu == 2)
            {
                ComboBox cmb = (ComboBox)sender;
                string selectedValue = cmb.SelectedItem.ToString();
                string home_team = selectedValue.Substring(0, selectedValue.IndexOf("vs")-1);
                string away_team = selectedValue.Substring(selectedValue.IndexOf("vs")+3, selectedValue.Length - selectedValue.IndexOf("vs") - 3);

                Label lb = new Label();
                lb.Text = "Home Team : ";
                lb.Location = new Point(5, 5);
                lb.Width = 300;
                lb.Height = 20;
                lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                panel1.Controls.Add(lb);

                lb = new Label();
                lb.Text = "Away Team : ";
                lb.Location = new Point(305, 5);
                lb.Width = 300;
                lb.Height = 20;
                lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                panel1.Controls.Add(lb);

                show_team(home_team, 0);
                show_team(away_team, 300);

                Label lb1 = new Label();
                lb1.Text = "Minute";
                lb1.Location = new Point(5, 350);
                lb1.Width = 30;
                lb1.Height = 20;
                lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                panel1.Controls.Add(lb1);

                Label lb2 = new Label();
                lb2.Text = "Team Name";
                lb2.Location = new Point(40, 350);
                lb2.Width = 110;
                lb2.Height = 20;
                lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                panel1.Controls.Add(lb2);

                Label lb3 = new Label();
                lb3.Text = "Player Name";
                lb3.Location = new Point(150, 350);
                lb3.Width = 100;
                lb3.Height = 20;
                lb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                panel1.Controls.Add(lb3);

                Label lb4 = new Label();
                lb4.Text = "Type";
                lb4.Location = new Point(250, 350);
                lb4.Width = 100;
                lb4.Height = 20;
                lb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                panel1.Controls.Add(lb4);

                show_log(home_team, away_team);
            }
        }

        public void show_team(string home_team, int x)
        {
            MySqlConnection con = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("SELECT team_name,name,playing_position FROM player_data WHERE team_name='" + home_team + "'", con);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                dbdataset.Clear();
                sda.SelectCommand = cmd;
                sda.Fill(dbdataset);

                int y = 25;

                for (int i = 0; i < dbdataset.Rows.Count; i++)
                {
                    String name = dbdataset.Rows[i]["name"].ToString();
                    String team_name = dbdataset.Rows[i]["team_name"].ToString();
                    String pos = dbdataset.Rows[i]["playing_position"].ToString();

                    Label lb1 = new Label();
                    lb1.Text = name;
                    lb1.Location = new Point(x+5, y);
                    lb1.Width = 100;
                    lb1.Height = 20;
                    lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panel1.Controls.Add(lb1);

                    Label lb2 = new Label();
                    lb2.Text = team_name;
                    lb2.Location = new Point(x+110, y);
                    lb2.Width = 100;
                    lb2.Height = 20;
                    lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panel1.Controls.Add(lb2);

                    Label lb3 = new Label();
                    lb3.Text = pos;
                    lb3.Location = new Point(x + 210, y);
                    lb3.Width = 70;
                    lb3.Height = 20;
                    lb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panel1.Controls.Add(lb3);
                    y += 20;
                }
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void show_log(string home_team, string away_team)
        {
            MySqlConnection con = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM match_data WHERE home_team='" + home_team + "' AND away_team='" + away_team + "' ORDER BY minute", con);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                dbdataset.Clear();
                sda.SelectCommand = cmd;
                sda.Fill(dbdataset);

                int y = 370;

                for (int i = 0; i < dbdataset.Rows.Count; i++)
                {
                    string minute = dbdataset.Rows[i]["minute"].ToString();
                    string team_name = dbdataset.Rows[i]["team_name"].ToString();
                    string player_name = dbdataset.Rows[i]["player_name"].ToString();
                    string type = dbdataset.Rows[i]["type"].ToString();

                    Label lb1 = new Label();
                    lb1.Text = minute;
                    lb1.Location = new Point(5, y);
                    lb1.Width = 30;
                    lb1.Height = 20;
                    lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panel1.Controls.Add(lb1);

                    Label lb2 = new Label();
                    lb2.Text = team_name;
                    lb2.Location = new Point(40, y);
                    lb2.Width = 110;
                    lb2.Height = 20;
                    lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panel1.Controls.Add(lb2);

                    Label lb3 = new Label();
                    lb3.Text = player_name;
                    lb3.Location = new Point(150, y);
                    lb3.Width = 100;
                    lb3.Height = 20;
                    lb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panel1.Controls.Add(lb3);

                    Label lb4 = new Label();
                    lb4.Text = type;
                    lb4.Location = new Point(250, y);
                    lb4.Width = 100;
                    lb4.Height = 20;
                    lb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if(type == "Yellow Card")
                    {
                        lb4.BackColor = Color.Yellow;
                    }
                    else if(type == "Red Card")
                    {
                        lb4.BackColor = Color.Red;
                    }
                    else if(type == "Goal")
                    {
                        lb4.BackColor = Color.Black;
                        lb4.ForeColor= Color.White;
                    }
                    panel1.Controls.Add(lb4);
                    y += 20;
                }
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void playerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu1();
        }

        private void matchDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu2();
        }
    }
}
