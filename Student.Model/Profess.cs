using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student.Model
{
    /// <summary>
    /// 专业实体类
    /// </summary>
    public class Profess
    {
        private int pro_id;     //专业编号
        private int col_id;     //学院编号
        private string pro_name;//专业名称

        public int Pro_id { get => pro_id; set => pro_id = value; }
        public int Col_id { get => col_id; set => col_id = value; }
        public string Pro_name { get => pro_name; set => pro_name = value; }
    }
}
