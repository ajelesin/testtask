using System;
using System.IO;

namespace TestLib
{

    public class FileStreamProvider : IStreamProvider
    {
        private string _inFilename, _outFilename;
        private StreamReader _streamReader;
        private StreamWriter _streamWriter;

        public FileStreamProvider() { }

        public void SetInFile(string filename)
        {
            _inFilename = filename;
            _streamReader = File.OpenText(_inFilename);
        }

        public void SetOutFile(string filename)
        {
            _outFilename = filename;
            _streamWriter = File.CreateText(_outFilename);
            _streamWriter.AutoFlush = true;
        }

        public FileStreamProvider(string inFilename, string outFilename)
        {
            _inFilename = inFilename;
            _outFilename = outFilename;
            _streamReader = File.OpenText(_inFilename);
            _streamWriter = File.CreateText(_outFilename);
            _streamWriter.AutoFlush = true;
        }

        public TextReader GetTextReader()
        {
            if (_streamReader == null)
                throw new InvalidOperationException("Don't set input filename!");

            return _streamReader;
        }

        public TextWriter GetTextWriter()
        {
            if (_streamWriter == null)
                throw new InvalidOperationException("Don't set output filename!");

            return _streamWriter;
        }
    }
}
