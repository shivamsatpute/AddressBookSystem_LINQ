using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AddressBookService_LINQ
{
    class AddressBookTable
    {
      public void CreateAddressBookDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(int));
            table.Columns.Add("PhoneNumber", typeof(long));
            table.Columns.Add("Email", typeof(string));
        }
    }
}
