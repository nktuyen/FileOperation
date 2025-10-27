using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class MyFileInfo
    {
        public string DirectoryName { get; set; }
        public string Name { get;set; }
        public string Extension { get; set; }
        public long Length { get; set; }
        public DateTime CreationTime { get; set; }


        internal MyFileInfo(System.IO.FileInfo fi)
        {
            this.DirectoryName = fi.DirectoryName;
            this.Name = fi.Name;
            this.Extension = fi.Extension;
            this.Length = fi.Length;
            this.CreationTime = fi.CreationTime;
        }
    }
}
