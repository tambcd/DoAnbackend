﻿using Microsoft.Extensions.Configuration;
using QuanLyLopHocCommon.Entity;
using QuanLyLopHocDL.IReponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocDL.ImplementReponsitory
{
    public class MessageDL : BaseDL<message>, IMessageDL
    {
        public MessageDL(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
