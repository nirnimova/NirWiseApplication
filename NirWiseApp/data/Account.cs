using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NirWiseApp.Data
{
    /// <summary>
    /// לקוח
    /// </summary>
    public class Account
    {
        /// <summary>
        /// מספר לקוח
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// שם פרטי
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// שם משפחה
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// ישוב
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// רחוב
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// מספר בית
        /// </summary>
        public int HouseNumber { get; set; }
    }
}   