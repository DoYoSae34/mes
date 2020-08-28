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
    public partial class Order_CMD : Form
    {
        //폼1을 사용하기 위해 추가
        Order_mng frm1;

        public Order_CMD()
        {
            InitializeComponent();
        }

        // 폼2에서 폼1을 제어하기 위해 생성자 추가
        public Order_CMD(Order_mng f1)
        {
            InitializeComponent();
            frm1 = f1;
        }


        // 확인버튼
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

            string SQL = "INSERT INTO ORDER_INFO_HEAD(ORDER_NO, ORDER_GUBUN, ORDER_DATE, " +
                                                      "CUST_NO, MEMO, CREATEUSER, UPDATEUSER)" +
                         "VALUES('" + txtOdNum.Text + "','" + txtGuBun.Text + "','" 
                                    +txtOderDate.Text + "','" + txtCusNum.Text + "','" 
                                    + txtBIGO.Text + "','" + txtCreUser.Text +"','"
                                    + txtUpuser.Text + "')";

            MySqlCommand cmd = new MySqlCommand(SQL, Conn);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO ORDER_INFO_BODY(DATA_ID, ORDER_NO, ITEM_NO, ITEM_NAME, ITEM_CAPACITY, ITEM_QTY, SCHEDUL_DATE, " +
                                                      "RECIPIENT, RECIPIENT_TEL, RECIPIENT_ZIP, RECIPIENT_ADDRES, MEMO, STATUS, CREATEUSER, UPDATEUSER)" +
                         "VALUES(" + Did + ",'" + txtOdNum.Text + "','" + txt_ProdCode.Text + "','" + txt_ProName.Text + "','" + txt_Capa.Text +"','" + txt_QTY.Text + "','"
                                    + dateTimePicker1.Value.Date.ToShortDateString()+ "','" + txt_RECIPIENT.Text + "','" + txt_TEL.Text + "','" + txt_ZIP.Text + "','" + txt_ADDR.Text + "','" + txt_MEMO.Text + "','" 
                                    + comboBox1.Text + "','" + txtCreUser.Text + "','" + txtUpuser.Text + "')";

            cmd.ExecuteNonQuery();

            Conn.Close();

            // 그리드뷰 새로고침 
            frm1.GridView_ReFresh();

            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Order_CMD_Load(object sender, EventArgs e)
        {

        }
    }
}
