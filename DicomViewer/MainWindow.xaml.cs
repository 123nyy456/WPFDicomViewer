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

namespace DicomViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DcmFileManager _dcm_file_mgr;
        private Point _ptDown;
        public MainWindow()
        {
            InitializeComponent();
            _dcm_file_mgr = new DcmFileManager();
        }

        private void Btn_OpenImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择Dicom文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            dialog.InitialDirectory = "D:\\";
            string dcmFileName = "";
            if (dialog.ShowDialog() == true)
            {
                dcmFileName = dialog.FileName;
            }
            _dcm_file_mgr.OpenDcmFile(dcmFileName);
            Update_Image();
        }

        private void Img_LeftButtonDown(object sender, MouseEventArgs e)
        {
            _ptDown = e.GetPosition(img);
        }

        private void Img_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point ptCurrent = e.GetPosition(img);
                Update_Image(ptCurrent.X - _ptDown.X, ptCurrent.Y - _ptDown.Y);
            }
        }

        private void Img_LeftButtonUp(object sender, MouseEventArgs e)
        {
            Point ptCurrent = e.GetPosition(img);
            _dcm_file_mgr.WinWidth += ptCurrent.X - _ptDown.X;
            _dcm_file_mgr.WinCenter += ptCurrent.Y - _ptDown.Y;
            Update_Image();
        }

        private void Update_Image(double offsetX = 0, double offsetY = 0)
        {
             img.Source = _dcm_file_mgr.RendImage(offsetX, offsetY);
        }
    }
}
