using FinancialManagment.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Infrastructure.FileStore
{
    public class FileWrapper : IFileWrapper
    {
        public void WriteAllBytes(string outputFile, byte[] content)
        {
            File.WriteAllBytes(outputFile, content);
        }
    }
}
