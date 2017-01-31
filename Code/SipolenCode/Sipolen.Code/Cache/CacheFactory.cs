/*******************************************************************************
 * Copyright © 2016 Sipolen.Framework 版权所有
 * Author: Sipolen
 * Description: Sipolen快速开发平台
 * Website：http://www.Sipolen.cn
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipolen.Code
{
    public class CacheFactory
    {
        public static ICache Cache()
        {
            return new Cache();
        }
    }
}
