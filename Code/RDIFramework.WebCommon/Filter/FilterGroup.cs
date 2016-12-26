﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDIFramework.WebCommon
{
    public class FilterGroup
    {
        /// <summary>
        /// 筛选条件组合方式 and or
        /// </summary>
        public GropuOp groupOp { get; set; }
        public IList<FilterRule> Rules { get; set; }
        public IList<FilterGroup> Groups { get; set; }
    }

    public enum GropuOp
    { 
        AND,
        OR
    }
}
