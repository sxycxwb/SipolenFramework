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
    public class DBConnection
    {
        public static bool Encrypt { get; set; }
        public DBConnection(bool encrypt)
        {
            Encrypt = encrypt;
        }
        public static string connectionString
        {
            get
            {
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["SipolenDbContext"].ConnectionString;
                if (Encrypt == true)
                {
                    return DESEncrypt.Decrypt(connection);
                }
                else
                {
                    return connection;
                }
            }
        }
    }
}
