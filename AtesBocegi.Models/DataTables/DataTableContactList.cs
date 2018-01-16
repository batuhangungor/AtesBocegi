using System;
using System.Collections.Generic;
using System.Text;

namespace AtesBocegi.Models.DataTables
{
    public class DataTableContactList
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
        public bool IsReaded { get; set; }
    }
}
