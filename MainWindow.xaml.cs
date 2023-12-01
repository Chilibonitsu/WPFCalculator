using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement el in GroupButton.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(Object sender, RoutedEventArgs e)
        {
            try
            {
                string textButton = ((Button)e.OriginalSource).Content.ToString();

                if (textButton == "C")
                {
                    text.Clear();
                }
                else if (textButton == "x")
                {
                    text.Text = text.Text.Substring(text.Text.Length - 1);
                }
                else if (textButton == "=")
                {
                    text.Text = new DataTable().Compute(text.Text, null).ToString();
                }
                else if (textButton == "About")
                {
                    MessageBox.Show("Calculator\nВерсия 1.0.0.0\nСилионов Илья М3О-109М");
                }
                else text.Text += textButton;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}