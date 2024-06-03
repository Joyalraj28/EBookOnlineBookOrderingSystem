using AdminDashboard.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace AdminDashboard.Service
{
    public static class CustomImageConverter
    {
        public static byte[] ImageToByteArray(string imagePath)
        {
            using (Image image = Image.FromFile(imagePath))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return stream.ToArray();
                }
            }
        }

        public static byte[] ImageToByteArray(HttpPostedFileBase ImageFile)
        {
            using (Stream inputStream = ImageFile.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                return memoryStream.ToArray();
            }
        }


        

        public static Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray != null)
            {
                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    return Image.FromStream(stream);
                }
            }

            return null;
        }
    }
    }

