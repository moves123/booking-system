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
using UserClasses;
using System.Windows.Shapes;
using BusinessLogic;

namespace Software
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FacilitiesManagement pt = new FacilitiesManagement("Dave","Lister","11-03-1995","#","dave","staffID","Nozzle Cleaner","dave@redd.com",1,"userDave");
       // Appointments appoinments;
     

        SqlInterfacing sqlInterfacing = new SqlInterfacing();


        private void ConvertDateTime(DateTime dateTime)
        {


            
            string a = dateTime.ToString();

            char[] y = a.ToCharArray();

            string [] b = a.Split('/');

            for(int i = 0; i < y.Length; i ++)
            {
                if(y[i] == '/')
                {
                    y[i] = '|';
                }
            }

 
        }


        public MainWindow()
        {
            InitializeComponent();

            #region randomTestStuff

            #endregion

            #region WindowLogic
            Home home = new Home();
            home.Show();
            this.Close();
            #endregion

        }
    }
}
