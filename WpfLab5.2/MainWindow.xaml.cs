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
using Microsoft.Win32;
using System.IO;
using System.Windows.Ink;

namespace WpfLab5._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Графические файлы (*.jpg) | *.jpg|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                StrokeCollection strokes = new StrokeCollection(fs);
                InkCanvas1.Strokes = strokes;
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Графические файлы (*.jpg) | *.jpg|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                var fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                InkCanvas1.Strokes.Save(fs);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InkCanvas1.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            InkCanvas1.EditingMode = InkCanvasEditingMode.Ink;
            //InkCanvas1.DefaultDrawingAttributes.Color = Color.FromRgb(0, 0, 0);
        }
    }
}
