using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Dicom;
using Dicom.Imaging;

namespace DicomViewer
{
    class DcmFileManager
    {
        private double _win_width;
        private double _win_center;
        private int _img_with;
        private int _img_height;
        private string _file_path;
        private DicomFile _dcm_file;
        private DicomImage _dcm_image;
        public DcmFileManager()
        {
            ImageManager.SetImplementation(WPFImageManager.Instance);
        }
        public double WinWidth
        {
            get
            {
                return _win_width;
            }
            set
            {
                _win_width = value;
            }
        }

        public double WinCenter
        {
            get
            {
                return _win_center;
            }
            set
            {
                _win_center = value;
            }
        }

        public int ImgWidth
        {
            get
            {
                return _img_with;
            }
        }

        public int ImgHeight
        {
            get
            {
                return _img_height;
            }
        }

        public string DcmFilePath
        {
            get { return _file_path; }
        }

        public void OpenDcmFile(string file_path)
        {
            _file_path = file_path;
            _dcm_file = DicomFile.Open(_file_path);
            _dcm_image = new DicomImage(_dcm_file.Dataset, 0);
            _img_with = _dcm_image.Width;
            _img_height = _dcm_image.Height;
            _win_width = _dcm_image.WindowWidth;
            _win_center = _dcm_image.WindowCenter;
        }

        public WriteableBitmap RendImage(double offsetX, double offsetY)
        { 
            _dcm_image.WindowWidth = _win_width + offsetX;
            _dcm_image.WindowCenter = _win_center + offsetY;
            if (_dcm_image == null)
            {
                return null;
            }

            WriteableBitmap renderedImage = _dcm_image.RenderImage().As<WriteableBitmap>();
            return renderedImage;
        }
    }
}
