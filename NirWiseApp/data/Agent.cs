using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NirWiseApp.Data
{
    /// <summary>
    /// סוכן
    /// </summary>
    public class Agent
    {
        /// <summary>
        /// מספר סוכן
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
    }
}