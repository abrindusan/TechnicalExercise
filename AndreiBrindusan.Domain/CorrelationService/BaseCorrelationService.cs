using AndreiBrindusan.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreiBrindusan.Domain.CorrelationService
{

    public abstract class BaseCorellationService<T>
    {

        protected readonly SystemDataSet DataSet;

        protected BaseCorellationService(SystemDataSet dataSet)
        {
            this.DataSet = dataSet;
        }

        public abstract T CorrelateData();
    }
}

