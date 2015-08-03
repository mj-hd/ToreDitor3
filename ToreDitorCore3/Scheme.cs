using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ToreDitorCore
{
    [SerializableAttribute]
    public class Scheme
    {
        private DataTable DataTable;

        public Scheme()
        {
            this.DataTable = new DataTable("Static");
            this.DataTable.Columns.Add("path");
            this.DataTable.Columns.Add("name");
            this.DataTable.Columns.Add("data");
        }

        public void Regist(string path, string name, string data)
        {
            DataRow row = this.DataTable.NewRow();
            row["path"] = path;
            row["name"] = name;
            row["data"] = data;
            this.DataTable.Rows.Add(row);
        }

        public void Update(string path, string name, string data)
        {
            DataRow[] rows = this.DataTable.Select("path = " + path + " and name = " + name);
            rows[0]["data"] = data;
        }
    }
}
