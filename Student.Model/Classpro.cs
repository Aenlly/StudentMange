using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student.Model
{
    /// <summary>
    /// 班级实体类
    /// </summary>
    public class Classpro
    {
        private int cla_id;     //班级编号
        private string cla_name;//班级名称
        private int pro_id;     //专业编号
        private int tea_id;     //辅导员编号

        public int Cla_id { get => cla_id; set => cla_id = value; }
        public string Cla_name { get => cla_name; set => cla_name = value; }
        public int Pro_id { get => pro_id; set => pro_id = value; }
        public int Tea_id { get => tea_id; set => tea_id = value; }
    }
}
