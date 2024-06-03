using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AdminDashboard.Models.CustomModel
{
    public class MemoryPostedFile : HttpPostedFileBase
    {
        private Stream _stream;
        private string _contentType;
        private string _fileName;

        public MemoryPostedFile(Stream stream, string contentType, string fileName)
        {
            _stream = stream;
            _contentType = contentType;
            _fileName = fileName;
        }

        public override int ContentLength
        {
            get { return (int)_stream.Length; }
        }

        public override string ContentType
        {
            get { return _contentType; }
        }

        public override string FileName
        {
            get { return _fileName; }
        }

        public override Stream InputStream
        {
            get { return _stream; }
        }

        public override void SaveAs(string filename)
        {
            using (var file = File.Create(filename))
            {
                _stream.CopyTo(file);
            }
        }
    }
}