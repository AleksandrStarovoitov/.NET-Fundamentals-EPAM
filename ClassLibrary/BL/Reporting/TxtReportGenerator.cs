﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.BL.Reporting
{
    public class TxtReportGenerator : IReportGenerator
    {
        public void GenerateReport<T>(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
