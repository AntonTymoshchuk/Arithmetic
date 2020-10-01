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

namespace Arithmetic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BackgroundGradient.GradientStops[1].Color = Color.FromRgb(52, 152, 219);
            GetLastSymbol();
        }

        private string GetTagOf(string Content)
        {
            for (int i = 0; i < WorkPanel.Children.Count; i++)
            {
                if ((WorkPanel.Children[i] as Button).Content.ToString() == Content)
                    return (WorkPanel.Children[i] as Button).Tag.ToString();
            }
            return null;
        }

        private string GetLastSymbol()
        {
            return Display.Text.Split(' ').Last();
        }

        private bool IsNumber(string Tag)
        {
            switch (Tag)
            {
                case "One": return true;
                case "Two": return true;
                case "Three": return true;
                case "Four": return true;
                case "Five": return true;
                case "Six": return true;
                case "Seven": return true;
                case "Eight": return true;
                case "Nine": return true;
                default: return false;
            }
        }

        private bool IsCommand(string Tag)
        {
            switch (Tag)
            {
                case "Plus": return true;
                case "Minus": return true;
                case "Multiply": return true;
                case "Divide": return true;
                case "Left Bracket": return true;
                case "Right Bracket": return true;
                default: return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch((sender as Button).Tag.ToString())
            {
                case "One":
                    switch (GetTagOf(GetLastSymbol()))
                    {
                        case "Right bracket": return;
                        default:
                            if (IsNumber(GetTagOf(GetLastSymbol())) == true)
                                Display.Text += "1";
                            break;
                    }
                    Display.Text += (sender as Button).Content.ToString();
                    break;
            }
        }
    }
}
