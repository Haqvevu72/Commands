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
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public ICommand _calculate { get; set; }
        public MainView()
        {
            InitializeComponent();
            DataContext = this;
            _calculate = new Calculate(Calculate,CanCalculate);
        }
        public void Calculate(object? parameter) 
        {
            int number_1 = int.Parse(first_number.Text.ToString());
            int number_2 = int.Parse((second_number.Text.ToString()));
            string selectedOperator = _operator.SelectedItem?.ToString();
            if (selectedOperator=="+") 
            {
                _result.Text = (number_1+number_2).ToString();
            }
            else if (selectedOperator == "-")
            {
                _result.Text = (number_1 - number_2).ToString();
            }
            else if (selectedOperator == "*")
            {
                _result.Text = (number_1 * number_2).ToString();
            }
            else if (selectedOperator == "/")
            {
                _result.Text = (number_1 / number_2).ToString();
            }
        }
        public bool CanCalculate(object? parameter) 
        {
            if (first_number.Text != "" && second_number.Text!="" && _operator.SelectedItem!=null) { return true; };
            return false;
        }
    }
}
