using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Models
{
    public class TransactionModel
    {
        public int? Id { get; set; }
        public string NameDest { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsFraud { get; set; }
    }
}