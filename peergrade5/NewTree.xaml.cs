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

namespace peergrade5
{
    /// <summary>
    /// Получаем от пользователя параметры для отрисовки дерева пифагора.
    /// </summary>
    public partial class NewTree : Window
    {
        public NewTree()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        /// <summary>
        /// По нажатию кнопки, сохраняем значения в статические поля основного окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Fractal.itteration = (int)Number.Value;
            Fractal.angle1 = (double)Angle1.Value;
            Fractal.angle2 = (double)Angle2.Value;
            Fractal.ratio = (double)Comparison.Value;
            this.Close();
        }

        private void Comparison_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
