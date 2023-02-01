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

namespace peergrade5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 

        /// <summary>
        /// Инициализация.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Первая кнопка, отрисовка Дерева Пифагора.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            Fractal.clickNumber = 1;
            Canvas.Children.Clear();
            var rnd = new Random();
            //Метод для отрисоки конкретной палочки в дереве.
            void Create(int len, double x, double y, double angle, int itteration)
            {

                double x1 = x + len * Math.Sin(angle * Math.PI / 180.0);
                double y1 = y + len * Math.Cos(angle * Math.PI / 180.0);
                var line = new Line();
                line.X1 = x;
                line.X2 = x1;
                line.Y1 = Canvas.ActualHeight - y;
                line.Y2 = Canvas.ActualHeight - y1;
                Brush brush = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255)));
                line.Stroke = brush;
                Canvas.Children.Add(line);
                //Рекурсивный вызов этого же метода.
                if (itteration > 1)
                {
                    Create((int)(len * Fractal.ratio), x1, y1, angle + Fractal.angle1, itteration - 1);
                    Create((int)(len * Fractal.ratio), x1, y1, angle - Fractal.angle2, itteration - 1);
                }

            }
            //Вызов метода, параметры зависят от размеров окна.
            Create((int)Canvas.ActualHeight / 4, Canvas.ActualWidth / 2, 0, 0, Fractal.itteration);
        }

        //Вызов доп.формы для получения доп параметров.
        private void ButtonClick2(object sender, RoutedEventArgs e)
        {
            NewTree extraWindow = new NewTree();
            extraWindow.Show();
        }
        /// <summary>
        /// Кнопка для отрисовки Кривой Коха.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick3(object sender, RoutedEventArgs e)
        {
            Fractal.clickNumber = 3;
            Canvas.Children.Clear();
            var rnd = new Random();
            //Отрисовать более 7 рекурсивных вызовов сможет не каждый компьютер, поэтому поставим искусственное ограничение.
            if (Fractal.itteration > 7)
            {
                MessageBox.Show("Значение глубины рекурсии более 7 не приветствуется в данном фрактале. Теперь оно 7.");
                Fractal.itteration = 7;
            }
            //Метод отрисовки каждого "горбика" на отрезке.
            void Create(double x1, double y1, double x2, double y2, int itteration)
            {
                //Последний шаг рекурсии.
                if (itteration == 1)
                {
                    var line = new Line();
                    line.X1 = x1;
                    line.X2 = x2;
                    line.Y1 = y1;
                    line.Y2 = y2;
                    Brush brush = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255)));
                    line.Stroke = brush;
                    Canvas.Children.Add(line);
                }
                if (itteration > 1)
                {
                    double x4 = (x2 + 2 * x1) / 3;
                    double y4 = (y2 + 2 * y1) / 3;
                    double x5 = (2 * x2 + x1) / 3;
                    double y5 = (2 * y2 + y1) / 3;
                    double psx = x5 - x4;
                    double psy = y5 - y4;
                    double pnx = (psx + Math.Sqrt(3) * psy) / 2 + x4;
                    double pny = (psy - Math.Sqrt(3) * psx) / 2 + y4;
                    //рекурсивный вызов.
                    Create(x1, y1, x4, y4, itteration - 1);
                    Create(x4, y4, pnx, pny, itteration - 1);
                    Create(pnx, pny, x5, y5, itteration - 1);
                    Create(x5, y5, x2, y2, itteration - 1);
                }
            }
            //Первоначальный вызов метода, с параметрами, зависящими от размеров окна.
            Create(1, Canvas.ActualHeight - 5, Canvas.ActualWidth - 1, Canvas.ActualHeight - 5, Fractal.itteration);

        }

        /// <summary>
        /// Открытие допюформы для получения параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick4(object sender, RoutedEventArgs e)
        {
            Koha extraWindow1 = new Koha();
            extraWindow1.Show();
        }

        /// <summary>
        /// Кнопка отрисовки Ковра Серпинского.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick5(object sender, RoutedEventArgs e)
        {
            Fractal.clickNumber = 5;
            Canvas.Children.Clear();
            //Отрисовать более 5 рекурсивных вызовов сможет не каждый компьютер, поэтому поставим искусственное ограничение.
            if (Fractal.itteration > 5)
            {
                MessageBox.Show("Значение глубины рекурсии более 5 не приветствуется в данном фрактале. Теперь оно 5.");
                Fractal.itteration = 5;
            }
            double x;
            if (Canvas.ActualWidth > Canvas.ActualHeight)
                x = Canvas.ActualHeight;
            else x = Canvas.ActualWidth;
            var square = new Polygon();
            square.Points.Add(new Point(0, 0));
            square.Points.Add(new Point(0, x));
            square.Points.Add(new Point(x, x));
            square.Points.Add(new Point(x, 0));
            square.Fill = new SolidColorBrush(Colors.Blue);
            Canvas.Children.Add(square);
            void Create(double x1, double y1, double len, int itteration)
            {
                //Последний шаг рекурсии.
                if (itteration == 1)
                {
                    var whiteSquare = new Polygon();
                    whiteSquare.Points.Add(new Point(x1, y1));
                    whiteSquare.Points.Add(new Point(x1 + len, y1));
                    whiteSquare.Points.Add(new Point(x1 + len, y1 + len));
                    whiteSquare.Points.Add(new Point(x1, y1 + len));
                    whiteSquare.Fill = new SolidColorBrush(Colors.White);
                    Canvas.Children.Add(whiteSquare);
                }
                if (itteration > 1)
                {
                    var whiteSquare = new Polygon();
                    whiteSquare.Points.Add(new Point(x1, y1));
                    whiteSquare.Points.Add(new Point(x1 + len, y1));
                    whiteSquare.Points.Add(new Point(x1 + len, y1 + len));
                    whiteSquare.Points.Add(new Point(x1, y1 + len));
                    whiteSquare.Fill = new SolidColorBrush(Colors.White);
                    Canvas.Children.Add(whiteSquare);
                    //Рекурсивный вызов.
                    Create(x1 + len / 3, y1 - 2 * len / 3, len / 3, itteration - 1);
                    Create(x1 + 4 * len / 3, y1 + len / 3, len / 3, itteration - 1);
                    Create(x1 - 2 * len / 3, y1 + len / 3, len / 3, itteration - 1);
                    Create(x1 + 4 * len / 3, y1 - 2 * len / 3, len / 3, itteration - 1);
                    Create(x1 - 2 * len / 3, y1 - 2 * len / 3, len / 3, itteration - 1);
                    Create(x1 + len / 3, y1 + 4 * len / 3, len / 3, itteration - 1);
                    Create(x1 + 4 * len / 3, y1 + 4 * len / 3, len / 3, itteration - 1);
                    Create(x1 - 2 * len / 3, y1 + 4 * len / 3, len / 3, itteration - 1);
                }
            }
            Create(x / 3, x / 3, x / 3, Fractal.itteration);
        }

        /// <summary>
        /// Открытие доп.формы для получения параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick6(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Необходимо выбрать число до 6. Вы можете попробовать выбрать некорректное значение (6 или 7)");
            Koha extraWindow = new Koha();
            extraWindow.Show();
        }

        /// <summary>
        /// Кнопка отрисовки Треугольника Серпинского.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick7(object sender, RoutedEventArgs e)
        {
            Fractal.clickNumber = 7;
            //Отрисовать более 7 рекурсивных вызовов сможет не каждый компьютер, поэтому поставим искусственное ограничение.
            if (Fractal.itteration > 7)
            {
                MessageBox.Show("Значение глубины рекурсии более 7 не приветствуется в данном фрактале. Теперь оно 7.");
                Fractal.itteration = 7;
            }
            Canvas.Children.Clear();
            var rnd = new Random();
            Brush brush = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255)));
            double x;
            if (Canvas.ActualWidth > Canvas.ActualHeight)
                x = Canvas.ActualHeight;
            else x = Canvas.ActualWidth;
            //Рисуем первый треугольник.
            var triangle = new Polygon();
            triangle.Points.Add(new Point(0, Math.Sqrt(3) * x / 2));
            triangle.Points.Add(new Point(x, Math.Sqrt(3) * x / 2));
            triangle.Points.Add(new Point(x / 2, 0));
            triangle.Stroke = brush;
            Canvas.Children.Add(triangle);
            void Create(double x1, double y1, double x2, double y2, double x3, double y3, int itteration)
            {
                //Последний шаг рекурсии.
                if (itteration == 1)
                {
                    var triangle = new Polygon();
                    triangle.Points.Add(new Point((x1 + x2) / 2, (y1 + y2) / 2));
                    triangle.Points.Add(new Point((x1 + x3) / 2, (y1 + y3) / 2));
                    triangle.Points.Add(new Point((x3 + x2) / 2, (y3 + y2) / 2));
                    triangle.Stroke = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255)));
                    Canvas.Children.Add(triangle);
                }
                if (itteration > 1)
                {
                    var triangle = new Polygon();
                    triangle.Points.Add(new Point((x1 + x2) / 2, (y1 + y2) / 2));
                    triangle.Points.Add(new Point((x1 + x3) / 2, (y1 + y3) / 2));
                    triangle.Points.Add(new Point((x3 + x2) / 2, (y3 + y2) / 2));
                    triangle.Stroke = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255)));
                    Canvas.Children.Add(triangle);
                    //Рекурсивный вызов.
                    Create(x1, y1, (x1 + x2) / 2, (y1 + y2) / 2, (x1 + x3) / 2, (y1 + y3) / 2, itteration - 1);
                    Create(x2, y2, (x1 + x2) / 2, (y1 + y2) / 2, (x2 + x3) / 2, (y2 + y3) / 2, itteration - 1);
                    Create(x3, y3, (x3 + x2) / 2, (y3 + y2) / 2, (x1 + x3) / 2, (y1 + y3) / 2, itteration - 1);
                }
            }
            Create(0, Math.Sqrt(3) * x / 2, x, Math.Sqrt(3) * x / 2, x / 2, 0, Fractal.itteration);
        }

        /// <summary>
        /// Открытие доп.формы для получения параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick8(object sender, RoutedEventArgs e)
        {
            Koha extraWindow = new Koha();
            extraWindow.Show();
        }

        /// <summary>
        /// Обработчик кнопки отрисовки Множества Кантора.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick9(object sender, RoutedEventArgs e)
        {
            Canvas.Children.Clear();
            var rnd = new Random();
            double x = Canvas.ActualWidth;
            Fractal.clickNumber = 9;
            void Create(double x1, double x2, double y, int itteration)
            {
                //Последний шаг рекурсии.
                if (itteration == 1)
                {
                    var line = new Polygon();
                    line.Points.Add(new Point(x1, y));
                    line.Points.Add(new Point(x2, y));
                    line.Points.Add(new Point(x2, y + 5));
                    line.Points.Add(new Point(x1, y + 5));
                    line.Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255)));
                    Canvas.Children.Add(line);
                }
                if (itteration > 1)
                {
                    var line = new Polygon();
                    line.Points.Add(new Point(x1, y));
                    line.Points.Add(new Point(x2, y));
                    line.Points.Add(new Point(x2, y + 5));
                    line.Points.Add(new Point(x1, y + 5));
                    line.Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255)));
                    Canvas.Children.Add(line);
                    //Рекурсивный вызов.
                    Create(x1, (2 * x1 + x2) / 3, y + Fractal.delta, itteration - 1);
                    Create((2 * x2 + x1) / 3, x2, y + Fractal.delta, itteration - 1);
                }
            }
            Create(0, x, 0, Fractal.itteration);
        }

        /// <summary>
        /// Открытие доп.формы для получения параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick10(object sender, RoutedEventArgs e)
        {
            Kantor extraWindow = new Kantor();
            extraWindow.Show();
        }

        /// <summary>
        /// Если меняется размер окна, то метод заново отрисовывает последний нарисованный фрактал.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Canvas.Children.Clear();
            switch (Fractal.clickNumber)
            {
                case 1: ButtonClick1(sender, e); break;
                case 3: ButtonClick3(sender, e); break;
                case 5: ButtonClick5(sender, e); break;
                case 7: ButtonClick7(sender, e); break;
                case 9: ButtonClick9(sender, e); break;
            }
        }


        /// <summary>
        /// Увеличивает глубину рекурсии на 1, и заново перерисовывает последний нарисованный фрактал.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick11(object sender, RoutedEventArgs e)
        {
            if (Fractal.itteration < 10)
            {
                Fractal.itteration++;
                Canvas.Children.Clear();
                switch (Fractal.clickNumber)
                {
                    case 1: ButtonClick1(sender, e); break;
                    case 3: ButtonClick3(sender, e); break;
                    case 5: ButtonClick5(sender, e); break;
                    case 7: ButtonClick7(sender, e); break;
                    case 9: ButtonClick9(sender, e); break;
                }
            }
            else
                MessageBox.Show("достигнуто максимaльное значение");
        }

        /// <summary>
        /// Уменьшаеет глубину рекурсии на 1, и заново перерисовывает последний нарисованный фрактал.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick12(object sender, RoutedEventArgs e)
        {
            if (Fractal.itteration > 1)
            { 
                Fractal.itteration--;
                Canvas.Children.Clear();
                switch (Fractal.clickNumber)
                {
                    case 1: ButtonClick1(sender, e); break;
                    case 3: ButtonClick3(sender, e); break;
                    case 5: ButtonClick5(sender, e); break;
                    case 7: ButtonClick7(sender, e); break;
                    case 9: ButtonClick9(sender, e); break;
                }
            }
            else
                MessageBox.Show("достигнуто минимальное значение");
        }
    }
}
