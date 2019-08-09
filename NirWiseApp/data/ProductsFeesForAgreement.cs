using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NirWiseApp.data
{
    public class ProductsFeesForAgreement
    {
        public int AgreementId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Fee { get; set; }
    }
}