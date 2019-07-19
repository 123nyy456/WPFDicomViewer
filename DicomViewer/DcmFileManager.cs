using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dicom;

namespace DicomViewer
{
    class DcmFileManager
    {
        private int win_width;
        private int win_location;
        private int img_with;
        private int img_height;
        public DcmFileManager()
        {

        }
        public int WinWidth
        {
            get
            {
                return win_width;
            }
            
            set
            {
                win_width = value;
            }
        }


        public void OpenDcmFile(string file_path)
        {

        }
    }
}
