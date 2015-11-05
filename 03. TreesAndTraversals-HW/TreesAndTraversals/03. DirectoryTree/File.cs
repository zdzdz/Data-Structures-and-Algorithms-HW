using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryTree
{
    public class File
    {
        public File(string name, int size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name { get; set; }
        public int Size { get; set; }
    }
}
