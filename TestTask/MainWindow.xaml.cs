using System;
using System.Windows;


namespace TestTask
{
    /// &lt;summary&gt;
    /// Interaction logic for MainWindow.xaml
    /// &lt;/summary&gt;
    public partial class MainWindow : Window
    {
        Test[] myTest = new Test[10];

        int i, k;
        public static int pv;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (myTest[i - 1].PV == pv)
                k++;
            /* if (i-1 == 0 &amp;&amp; Rb2.IsChecked == true)
            k++;
            if (i-1 == 1 &amp;&amp; Rb1.IsChecked == true)
            k++;
            if (i-1 == 2 &amp;&amp; Rb1.IsChecked == true)
            k++;*/

            MethodNext(i);
            if (i >= 4)
{
                btnNext.IsEnabled = false;
                MessageBox.Show(k.ToString());
            }
            i++;
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            pv = 0;
            for (i = 0; i < 10; i++)
{
                myTest[i] = new Test();
            }
            myTest[0].Q = "2+2=?"; ;
            myTest[0].V1 = "5"; ;
            myTest[0].V2 = "4";
            myTest[0].V3 = "6";
            myTest[0].PV = 2;
            myTest[1].Q = "9 + 3 =?";
            myTest[1].V1 = "12";
            myTest[1].V2 = "14";
            myTest[1].V3 = "16";
            myTest[1].PV = 1;
            myTest[2].Q = "3 + 5 =?";
            myTest[2].V1 = "6";
            myTest[2].V2 = "9";
            myTest[2].V3 = "8";
            myTest[2].PV = 3;
            myTest[3] = new Test("5 + 16 =?", "25", "31","32", 2);
            i = 1;
            k = 0;
            MethodNext(0);
        }
        private void Rb1_Checked(object sender, RoutedEventArgs e)
        {
            pv = 1;
        }
        private void Rb2_Checked(object sender, RoutedEventArgs e)
        {
            pv = 2;
        }
        private void Rb3_Checked(object sender, RoutedEventArgs e)
        {
            pv = 3;
        }
        private void MethodNext(int i)
        {
            lbl1.Content = myTest[i].Q;
            Rb1.Content = myTest[i].V1;
            Rb2.Content = myTest[i].V2;
            Rb3.Content = myTest[i].V3;
        }
    }
}