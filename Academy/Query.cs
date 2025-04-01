﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    class Query
    {
        public string Colums { get; }
        public string Tables { get; }
        public string Condition { get; set; }
        public string Group_by { get; }
        public Query(string colums, string tables, string condition = "", string group_by = "")
        {
            Colums = colums;
            Tables = tables;
            Condition = condition;
            Group_by = group_by;
        }
        public Query(Query other)
        {
            this.Colums = other.Colums;
            this.Tables = other.Tables;
            this.Condition = other.Condition;
            this.Group_by = other.Group_by;
        }
    }
}
