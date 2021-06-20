using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student.Model
{
    //学生小程序实体类
    public class Student
    {
        private string stu_id;     //学号
        private string stu_head;    //头像
        private string stu_name;    //姓名
        private string stu_sex;     //性别
        private string stu_birth;     //出生日期
        private string stu_edu;     //学历
        private string stu_tel;     //手机号
        private string stu_pwd;     //密码
        private string stu_address;     //地址
        private string stu_origin;     //生源地
        private string stu_time;     //入学年份
        private int col_id;     //学院
        private int pro_id;     //专业
        private int cla_id;     //班级

        public string Stu_id { get => stu_id; set => stu_id = value; }
        public string Stu_head { get => stu_head; set => stu_head = value; }
        public string Stu_name { get => stu_name; set => stu_name = value; }
        public string Stu_sex { get => stu_sex; set => stu_sex = value; }
        public string Stu_birth { get => stu_birth; set => stu_birth = value; }
        public string Stu_edu { get => stu_edu; set => stu_edu = value; }
        public string Stu_tel { get => stu_tel; set => stu_tel = value; }
        public string Stu_pwd { get => stu_pwd; set => stu_pwd = value; }
        public string Stu_address { get => stu_address; set => stu_address = value; }
        public string Stu_origin { get => stu_origin; set => stu_origin = value; }
        public string Stu_time { get => stu_time; set => stu_time = value; }
        public int Col_id { get => col_id; set => col_id = value; }
        public int Pro_id { get => pro_id; set => pro_id = value; }
        public int Cla_id { get => cla_id; set => cla_id = value; }
    }
}
