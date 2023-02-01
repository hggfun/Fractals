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
    /// Получаем от пользователя значения, для отрисовки Множества Кантора.
    /// </summary>
    public partial class Kantor : Window
    {
        public Kantor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// По нажатию кнопки, сохраняем значения в статические поля основного окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Fractal.itteration = (int)OrderNum.Value;
            Fractal.delta = (double)Delta.Value;
            this.Close();
        }
    }
}
