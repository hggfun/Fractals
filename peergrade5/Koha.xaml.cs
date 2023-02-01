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
    /// Получаем от пользователя параметры для Кривой Кохи, Ковра и Треугольника Серпинского.
    /// </summary>
    public partial class Koha : Window
    {
        public Koha()
        {
            InitializeComponent();
        }

        /// <summary>
        /// По нажатию кнопки, сохраняем значения в статические поля в основном окне.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Fractal.itteration = (int)OrderNum.Value;
            this.Close();
        }
    }
}
