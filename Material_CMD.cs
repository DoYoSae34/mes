using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MES_PROJECT
{
    public partial class Material_CMD : Form
    {
        Material_mng f1;

        public Material_CMD()
        {
            InitializeComponent();
        }

        public Material_CMD(Material_mng ff1)
        {
            InitializeComponent();
            f1 = ff1;
        }


        // 저장버튼
        private void button1_Click(object sender, EventArgs e)
        {

            string str = "Server=localhost;Database=mes;Uid=root;Pwd=1234";
            MySqlConnection Conn = new MySqlConnection(str);
            Conn.Open(); // 데이터 베이스 오픈


            // 데이터 베이스 접속 상태 체크 
            if (Conn.State == ConnectionState.Open)
                MessageBox.Show("저장 성공");
            else
                MessageBox.Show("저장 실패");

            // 데이터 베이스에 명령어 내리기 


            Random rnd = new Random();
            int Did = rnd.Next(10000, 100000);

            string SQL = "INSERT INTO MATERIAL_ORDER_HEAD(MAT_ORDER_NO, MAT_ORDER_DATE, MAT_IN_DATE, " +
                                                      "MAT_ORDER_PER, MAT_ORDER_QTY, MAT_ORDER_MONEY, MEMO, STATUS, CREATEUSER, UPDATEUSER)" +
                         "VALUES('" + textBox1.Text + "','" + textBox2.Text + "','"
                                    + textBox3.Text + "','" + textBox4.Text + "','"
                                    + textBox5.Text + "','" + textBox6.Text + "','"
                                    + textBox7.Text + "','" + textBox8.Text + "','"
                                    + textBox20.Text + "','" + textBox21.Text + "')";

            MySqlCommand cmd = new MySqlCommand(SQL, Conn);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO MATERIAL_ORDER_BODY(DATA_ID, MAT_ORDER_NO, MAT_ITEM_GUBUN, MAT_ITEM_CODE, MAT_ITEM_NAME, MAT_ITEM_UNIT, MAT_ITEM_QTY, " +
                                                      "MAT_ITEM_AMT, MAT_ITEM_MONEY, HS_CODE, MAT_ORDER_PER, MAT_ORDER_TEL, MEMO, STATUS, CREATEUSER, UPDATEUSER)" +
                         "VALUES(" + Did + ",'" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + comboBox2.Text + "','"
                                    + textBox16.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + comboBox3.Text + "','" + textBox25.Text + "','" + textBox24.Text + "','"
                                    + textBox23.Text + "','" + comboBox4.Text + "','" + textBox20.Text + "','" + textBox21.Text + "')";

            cmd.ExecuteNonQuery();

            Conn.Close();

            // 그리드뷰 리셋 
 //           f1.GridView_ReFresh();

            this.Close();



        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
