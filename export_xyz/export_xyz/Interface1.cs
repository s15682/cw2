using System;
using System.Collections.Generic;
using System.Text;

namespace export_xyz
{
    public interface IOutputFileCreator
    {
        public void CreateOutputFile(ICollection<Student> students);
    }
}
