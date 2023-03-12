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

namespace SidStarCreator
{
    public partial class MainWindow : Window
    {
        int i = 1;
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void add_Click(object sender, RoutedEventArgs e)
        {
            String main;

            main = name.Text + " " + lat.Text + " " + lon.Text;

            list.Items.Add(main);

            name.Text = "";
            lat.Text = "";
            lon.Text = "";

            
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            name.Text = "";
            lat.Text = "";
            lon.Text = "";
            list.Items.Remove(list.SelectedItem);
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                name.Text = "";
                lat.Text = "";
                lon.Text = "";
                String main;
                main = list.SelectedItem.ToString();
                MessageBox.Show(main);
                String[] mains = main.Split(' ');
                name.Text = mains[0];
                lat.Text = mains[1];
                lon.Text = mains[2];
                
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show("Bitte Objekt auswählen!");

            }
            
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String main;

                main = name.Text + " " + lat.Text + " " + lon.Text;

                int i = list.SelectedIndex;

                list.Items.Insert(i, main);
                list.Items.RemoveAt(i + 1);


                name.Text = "";
                lat.Text = "";
                lon.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void goout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                name.Text = "";
                lat.Text = "";
                lon.Text = "";
                String splitt;
                splitt = list.SelectedItem.ToString();
                String[] splitted = splitt.Split(' ');
                String na = splitted[0];
                String la = splitted[1];
                String lo = splitted[2];
                String art = "";
                if (sidr.IsChecked == true)
                {
                    art = "Sid";
                }
                else if (starr.IsChecked == true)
                {
                    art = "Star";
                }
                else if (apprr.IsChecked == true)
                {
                    art = "App";
                }
                String main;
                main = $"\n<{art}_Waypoint ID=\"{i}\">\r\n                <Name>{na}</Name>\r\n                <Type>Normal</Type>\r\n                <Latitude>{la}</Latitude>\r\n                <Longitude>{lo}</Longitude>\r\n                <Speed>0</Speed>\r\n                <Altitude>0</Altitude>\r\n                <AltitudeCons>0</AltitudeCons>\r\n                <AltitudeRestriction>at</AltitudeRestriction>\r\n</{art}_Waypoint>";
                output.Text += main;
                i++;

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Bitte Objekt auswählen!");

            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            output.Clear();
            i = 1;
        }

        private void clearlist_Click(object sender, RoutedEventArgs e)
        {
            list.Items.Clear();
        }

        private void convertlat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String all = converter.Text;
                String[] alla = all.Split(' ');
                String[] sseca = alla[2].Split('.');
                String ssec = sseca[0] + "," + sseca[1];
                decimal sec = Convert.ToDecimal(ssec);
                int min = Convert.ToInt32(alla[1]);
                int deg = Convert.ToInt32(alla[0]);

                decimal con = (((sec / 60) + min) / 60) + deg;
                con = Math.Round(con, 6);
                String scon = Convert.ToString(con);
                String[] scona = scon.Split(",");
                String sconf = scona[0] + "." + scona[1];
                lat.Text = sconf;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }

        private void convertlon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String all = converter.Text;
                String[] alla = all.Split(' ');
                String[] sseca = alla[2].Split('.');
                String ssec = sseca[0] + "," + sseca[1];
                decimal sec = Convert.ToDecimal(ssec);
                int min = Convert.ToInt32(alla[1]);
                int deg = Convert.ToInt32(alla[0]);

                decimal con = (((sec / 60) + min) / 60) + deg;
                con = Math.Round(con, 6);
                String scon = Convert.ToString(con);
                String[] scona = scon.Split(",");
                String sconf = scona[0] + "." + scona[1];
                lon.Text = sconf;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
