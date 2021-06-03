using DATA_CHECKER.util;
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

namespace DATA_CHECKER
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            RobotIp.Text = "127.0.0.1";
            RobotPort.Text = ":9000";
            ElementType.Text = "R";
            ElenentNumber.Text = "4";


        }


        public void GetElements(object sender, RoutedEventArgs e)
        {
            program_data.Text = "";
            RobotUtil.RobotIpAdress = RobotIp.Text;
            RobotUtil.RobotPort = RobotPort.Text;
            RobotUtil.ElementType = ElementType.Text;
            RobotUtil.ElementNumber = ElenentNumber.Text;
            string Element = RobotUtil.ElementType + "[" + RobotUtil.ElementNumber + "]";

            List<string> ProgramNames = RobotUtil.GetLSProgramNames();

            foreach (string ProgramName in ProgramNames)
            {
                string data = RobotUtil.GetProgramCode(ProgramName);

                string program = ProgramUtil.DataTruncate(data);
 
                IEnumerable<string> strings1 = ProgramUtil.FindProgramElementByCollection(program, Element);
                
                if (strings1.Count() > 0)
                    program_data.Text += "\n element " + Element + " used in " + ProgramName + " " + strings1.Count() + " times";
               
                foreach (string elem in strings1) {
                    program_data.Text += elem + " ";
                }

            }


        }
    }
}
