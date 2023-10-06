using RobertMaxim.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.Domain.CorrelationService
{
    public abstract class BaseCorrelationService<T>
    {
        protected readonly SystemDataSet DataSet;

        //protected BaseCorrelationService(SystemDataSet dataSet)
        //{
        //    this.DataSet = dataSet;
        //}

        public abstract List<T> CorrelateData();
    }
}
