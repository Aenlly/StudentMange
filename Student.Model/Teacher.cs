using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student.Model
{
    /// <summary>
    /// 辅导员实体类
    /// </summary>
    public class Teacher
    {
        private int tea_id;     //辅导员编号
        private string tea_name;    //辅导员姓名
        private string tea_tel;     //手机号
        private string tea_address;     //地址
        private int col_id;     //学院名称

        public int Tea_id { get => tea_id; set => tea_id = value; }
        public string Tea_name { get => tea_name; set => tea_name = value; }
        public string Tea_tel { get => tea_tel; set => tea_tel = value; }
        public string Tea_address { get => tea_address; set => tea_address = value; }
        public int Col_id { get => col_id; set => col_id = value; }
    }
}
