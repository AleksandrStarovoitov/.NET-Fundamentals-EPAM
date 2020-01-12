using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.BL
{
    public interface IReportGenerator
    {
        //TODO Predicate?
        void GenerateReport<T>(Predicate<T> predicate); 
    }
}
