using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NirWiseApp.Data
{
    /// <summary>
    /// הסכם עמלות
    /// </summary>
    public class FeeAgreement
    {
        public int Id { get; set; }

        /// <summary>
        /// מספר לקוח
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// מספר מוצר
        /// </summary>
        public int ProductId { get; set; }
        
        /// <summary>
        /// מספר סוכן
        /// </summary>
        public int AgentId { get; set; }

        /// <summary>
        /// עמלה למוצר
        /// </summary>
        public decimal Fee { get; set; }
    }
}