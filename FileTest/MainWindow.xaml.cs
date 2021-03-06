﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FileOperate.XML;
using System.Data;

namespace FileTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //实体对象转换到Xml
            BookModel book = new BookModel() { BookType = "文学", BookISBN = "tyewwufhewidw", BookAuthor = "lrsitod", BookName = "百年孤独", BookPrice = 100.0 };
            string xml = XmlUtil.Serializer(typeof(BookModel), book, "books.txt");
            //Xml转换到实体对象
            BookModel stu2 = XmlUtil.Deserialize(typeof(BookModel), "books.txt") as BookModel;

            //DataTable转换到Xml
            // 生成DataTable对象用于测试
            DataTable dt1 = new DataTable("mytable");   // 必须指明DataTable名称

            dt1.Columns.Add("Dosage", typeof(int));
            dt1.Columns.Add("Drug", typeof(string));
            dt1.Columns.Add("Patient", typeof(string));
            dt1.Columns.Add("Date", typeof(DateTime));

            // 添加行
            dt1.Rows.Add(25, "Indocin", "David", DateTime.Now);
            dt1.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            dt1.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            dt1.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            dt1.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);

            // 序列化
            xml = XmlUtil.Serializer(typeof(DataTable), dt1, "datatab.txt");

            //4. Xml转换到DataTable
 
            // 反序列化
            DataTable dt2 = XmlUtil.Deserialize(typeof(DataTable), "datatab.txt") as DataTable;

            // 输出测试结果
            foreach (DataRow dr in dt2.Rows)
            {
	            foreach (DataColumn col in dt2.Columns)
	            {
		            //Console.Write(dr[col].ToString() + " ");
	            }

	            //Console.Write("\r\n");
            }
            //5. List转换到Xml
 
            // 生成List对象用于测试
            List<Student> list1 = new List<Student>(3);

            list1.Add(new Student() { Name = "okbase", Age = 10 });
            list1.Add(new Student() { Name = "csdn", Age = 15 });
            // 序列化
            xml = XmlUtil.Serializer(typeof(List<Student>), list1, "liststudent.txt");
            //Console.Write(xml);

            //6. Xml转换到List

            List<Student> list2 = XmlUtil.Deserialize(typeof(List<Student>), "liststudent.txt") as List<Student>;
            foreach (Student stu in list2)
            {
	            //Console.WriteLine(stu.Name + "," + stu.Age.ToString());
            }
        }
    }
}
