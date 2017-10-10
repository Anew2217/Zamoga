using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Dominio
{
    public class Transaction
    {
        public int? Id { get; set; }
        public string NameDest { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsFraud { get; set; }
    }
}