using NirWiseApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NirWiseApp.data
{
    public class TopAccount
    {
        public Account Account { get; set; }
        public int TopResults { get; set; }
    }
}