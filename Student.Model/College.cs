using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student.Model
{
    /// <summary>
    /// 学院实体类
    /// </summary>
    public class College
    {
        private int col_id;     //学院编号
        private string col_names;    //学院名称

        public int Col_id { get => col_id; set => col_id = value; }
        public string Col_names { get => col_names; set => col_names = value; }
    }
}
