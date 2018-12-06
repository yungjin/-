using DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20181123
{
    public class MainView
    {
        private MYsql db;
        private Commons comm;
        private Panel head, contents;
        private Button btn1, btn2, btn3;
        private Form parentForm, tagetForm;
        private Hashtable hashtable;

        public MainView(Form parentForm)
        {
            this.parentForm = parentForm;
            db = new MYsql();
            comm = new Commons();

            ViewData();
        }



        //private void getView()
        //{
        //    hashtable = new Hashtable();
        //    hashtable.Add("size", new Size(1000, 100));
        //    hashtable.Add("point", new Point(0, 0));
        //    hashtable.Add("color", Color.Silver);
        //    hashtable.Add("name", "head");
        //    head = comm.getPanel(hashtable, parentForm);

        //    hashtable = new Hashtable();
        //    hashtable.Add("size", new Size(1000, 700));
        //    hashtable.Add("point", new Point(0, 100));
        //    hashtable.Add("color", Color.Yellow);
        //    hashtable.Add("name", "contents");
        //    contents = comm.getPanel(hashtable, parentForm);

        //    hashtable = new Hashtable();
        //    hashtable.Add("size", new Size(200, 80));
        //    hashtable.Add("point", new Point(100, 10));
        //    hashtable.Add("color", Color.White);
        //    hashtable.Add("name", "btn1");
        //    hashtable.Add("text", "Member");
        //    hashtable.Add("click", (EventHandler)btn1_click);
        //    btn1 = comm.getButton(hashtable, head);

        //    hashtable = new Hashtable();
        //    hashtable.Add("size", new Size(200, 80));
        //    hashtable.Add("point", new Point(400, 10));
        //    hashtable.Add("color", Color.White);
        //    hashtable.Add("name", "btn2");
        //    hashtable.Add("text", "Rule");
        //    hashtable.Add("click", (EventHandler)btn2_click);
        //    btn2 = comm.getButton(hashtable, head);

        //    hashtable = new Hashtable();
        //    hashtable.Add("size", new Size(200, 80));
        //    hashtable.Add("point", new Point(700, 10));
        //    hashtable.Add("color", Color.White);
        //    hashtable.Add("name", "btn3");
        //    hashtable.Add("text", "Mapping");
        //    hashtable.Add("click", (EventHandler)btn3_click);
        //    btn3 = comm.getButton(hashtable, head);
        //}

        private void btn1_click(object o, EventArgs a)
        {
            // form 초기화
            if (tagetForm != null) tagetForm.Dispose();
            // form 호출
            tagetForm = comm.getMdiForm(parentForm, new UserForm(db), contents);
            tagetForm.Show();
        }

        private void btn2_click(object o, EventArgs a)
        {
            // form 초기화
            if (tagetForm != null) tagetForm.Dispose();
            // form 호출
            tagetForm = comm.getMdiForm(parentForm, new RuleForm(db), contents);
            tagetForm.Show();
        }

        private void btn3_click(object o, EventArgs a)
        {
            // form 초기화
            if (tagetForm != null) tagetForm.Dispose();
            // form 호출
            tagetForm = comm.getMdiForm(parentForm, new MappingForm(db), contents);
            tagetForm.Show();
        }

        private void ViewData()
        {
            string sql = "select vNo,vcName,vcText,sizeX,sizeY,pointX,pointY,color,EVENT from ViewControl where vNo = 1;";
            MySqlDataReader sdr = db.Reader(sql);
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];

                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                    if (arr[i] == "head")
                    {
                       
                        hashtable = new Hashtable();
                        hashtable.Add("size", new Size((int)sdr["sizeX"], (int)sdr["sizeY"]));
                        hashtable.Add("point", new Point((int)sdr["pointX"], (int)sdr["pointX"]));
                        hashtable.Add("color", Color.Blue);
                        hashtable.Add("name", sdr["vcName"]);
                        head = comm.getPanel(hashtable, parentForm);
                    }
                    else if (arr[i] == "contents")
                    {
                        hashtable = new Hashtable();
                        hashtable.Add("size", new Size((int)sdr["sizeX"], (int)sdr["sizeY"]));
                        hashtable.Add("point", new Point((int)sdr["pointX"], (int)sdr["pointX"]));
                        hashtable.Add("color", Color.Silver);
                        hashtable.Add("name", sdr["vcName"]);
                        contents = comm.getPanel(hashtable, parentForm);
                    }
                    else if (arr[i] == "btn1")
                    {
                        hashtable = new Hashtable();
                        hashtable.Add("size", new Size((int)sdr["sizeX"], (int)sdr["sizeY"]));
                        hashtable.Add("point", new Point((int)sdr["pointX"], (int)sdr["pointX"]));
                        hashtable.Add("color", Color.Silver);
                        hashtable.Add("name", sdr["vcName"]);
                        hashtable.Add("text", sdr["vcText"]);
                        //hashtable.Add("click", (int)sdr["EVENT"]); 
                         btn1 = comm.getButton(hashtable, head);
                    }
                    else if (arr[i] == "btn2")
                    {
                        hashtable = new Hashtable();
                        hashtable.Add("size", new Size((int)sdr["sizeX"], (int)sdr["sizeY"]));
                        hashtable.Add("point", new Point((int)sdr["pointX"], (int)sdr["pointX"]));
                        hashtable.Add("color", Color.Silver);
                        hashtable.Add("name", sdr["vcName"]);
                        hashtable.Add("text", sdr["vcText"]);
                        //hashtable.Add("click", (int)sdr["EVENT"]);
                        btn2 = comm.getButton(hashtable, head);
                    }
                    else if (arr[i] == "btn3")
                    {
                        hashtable = new Hashtable();
                        hashtable.Add("size", new Size((int)sdr["sizeX"], (int)sdr["sizeY"]));
                        hashtable.Add("point", new Point((int)sdr["pointX"], (int)sdr["pointX"]));
                        hashtable.Add("color", Color.Silver);
                        hashtable.Add("name", sdr["vcName"]);
                        hashtable.Add("text", sdr["vcText"]);
                        //hashtable.Add("click", (int)sdr["EVENT"]);
                        btn3 = comm.getButton(hashtable, head);
                    }

                }
            }
            db.ReaderClose(sdr);
        }

        //public void Kolor(int i)
        //{
            
        //    Color col = new Color();

        //    switch (i)
        //    {
        //        case 1:
                     
        //            break;
        //        case 2:
        //            break;

        //        case 3:
        //            break;
        //    }

        //    return col;
        //}
    }

}
