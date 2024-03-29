﻿using QuanLyLopHocCommon.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocDL.IReponsitory
{
    public interface IAccountDL : IBaseDL<account>
    {
        public account Login(string username, string password); 

        public int InsertAccount(AccountUser account);

    }
}
