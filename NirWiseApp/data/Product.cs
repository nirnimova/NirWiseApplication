using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NirWiseApp.Data
{
    /// <summary>
    /// מוצר
    /// </summary>
    public class Product
    {
        /// <summary>
        /// מספר מוצר
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// שם \ סוג
        /// </summary>
        public string Name { get; set; }
    }
}