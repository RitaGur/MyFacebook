using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class ImageID
    {
        private Image m_Image;
        private int m_ImageID;

        public ImageID(Image i_Image, int i_Index)
        {
            m_Image = i_Image;
            m_ImageID = i_Index;
        }

        public Image CardImage
        {
            get { return m_Image; }
            set { m_Image = value; }
        }

        public int ImageIndex
        {
            get { return m_ImageID; }
            set { m_ImageID = value; }
        }
    }
}
