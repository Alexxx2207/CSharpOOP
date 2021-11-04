using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    class Image : IStreamble
    {
        public Image(int length, int bytesSent)
        {
            Length = length;
            BytesSent = bytesSent;
        }
    }
}
