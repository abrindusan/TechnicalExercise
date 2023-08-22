using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreiBrindusan.DataModel
{
    // this extra class because I want to use the same DataSet all across my files
    public class SystemDataSetSingleton
    {
        private static readonly SystemDataSet instance = new SystemDataSet();
        public static SystemDataSet Instance => instance;
    }
}
