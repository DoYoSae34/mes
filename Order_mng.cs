﻿using System;
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
    public partial class Order_mng : Form
    {
        
        MySqlConnection mySqlConnection = new MySqlConnection
      ("datasource=localhost;port=3306;Database=MES;username=root;password=1213");

        MySqlDataAdapter mySqlDataAdapter;
        DataTable dataTable;

        public Order_mng()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            mySqlConnection.Open(); // 데이터 베이스 오픈
            
            // 데이터 베이스 접속 상태 체크 
            if(mySqlConnection.State == ConnectionState.Open)
                MessageBox.Show("DB 접속 성공");
            else
                MessageBox.Show("DB 접속 실패");

            // 데이터 베이스에 명령어 내리기 
            string SQL = "SELECT * FROM order_info_head";

            mySqlDataAdapter = new MySqlDataAdapter(SQL, mySqlConnection);
            mySqlDataAdapter.Fill(dataTable); // dat가 sql 명령문을 실행해서 그 결과를 dt에 가득 채운다.

            dataGridView1.DataSource = dataTable;

            #region 헤더 헤더명 변경
            dataGridView1.Columns[0].HeaderText = "수주번호";
            dataGridView1.Columns[1].HeaderText = "수주구분";
            dataGridView1.Columns[2].HeaderText = "수주일자";
            dataGridView1.Columns[3].HeaderText = "발주처번호";
            dataGridView1.Columns[4].HeaderText = "비고";
            dataGridView1.Columns[5].HeaderText = "작성자";
            dataGridView1.Columns[6].HeaderText = "작성시간";
            dataGridView1.Columns[7].HeaderText = "수정자";
            dataGridView1.Columns[8].HeaderText = "수정일자";
            #endregion

            mySqlConnection.Close(); 
        }

        // 셀 클릭시 
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 선택한 행의 첫번째 값을 가져온다. 여기선 ORDER_NO의 값
            string OrderNum = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            DataTable dataTable = new DataTable();

            mySqlConnection.Open(); // 데이터 베이스 오픈

            string SQL = "SELECT * FROM order_info_body where order_no ='" + OrderNum +"'";

            mySqlDataAdapter = new MySqlDataAdapter(SQL, mySqlConnection);

            mySqlDataAdapter.Fill(dataTable); // dat가 sql 명령문을 실행해서 그 결과를 dt에 가득 채운다.

            dataGridView2.DataSource = dataTable;

            #region 바디 헤더명 변경
            dataGridView2.Columns[0].HeaderText = "데이터아이디";
            dataGridView2.Columns[1].HeaderText = "수주번호";
            dataGridView2.Columns[2].HeaderText = "제품코드";
            dataGridView2.Columns[3].HeaderText = "제품명";
            dataGridView2.Columns[4].HeaderText = "용량";
            dataGridView2.Columns[5].HeaderText = "수량";
            dataGridView2.Columns[6].HeaderText = "납품예정일";
            dataGridView2.Columns[7].HeaderText = "수취인명";
            dataGridView2.Columns[8].HeaderText = "수취인 연락처";
            dataGridView2.Columns[9].HeaderText = "수취인 우편번호";
            dataGridView2.Columns[10].HeaderText = "수취인 주소";
            dataGridView2.Columns[11].HeaderText = "비고";
            dataGridView2.Columns[12].HeaderText = "상태";
            dataGridView2.Columns[13].HeaderText = "작성자";
            dataGridView2.Columns[14].HeaderText = "작성일자";
            dataGridView2.Columns[15].HeaderText = "수정자";
            dataGridView2.Columns[16].HeaderText = "수정일자";
            #endregion


            mySqlConnection.Close();

        }


        // 그리드뷰 갱신
        public void GridView_ReFresh()
        {
            // 표 데이터 삭제
            dataGridView2.DataSource = 0;

            DataTable dataTable = new DataTable();

            mySqlConnection.Open(); // 데이터 베이스 오픈

            string SQL = "SELECT * FROM order_info_head";

            mySqlDataAdapter = new MySqlDataAdapter(SQL, mySqlConnection);

            mySqlDataAdapter.Fill(dataTable); // dat가 sql 명령문을 실행해서 그 결과를 dt에 가득 채운다.

            dataGridView1.DataSource = dataTable;

            mySqlConnection.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        //신규버튼 클릭
        private void button2_Click(object sender, EventArgs e)
        {
            Order_CMD order = new Order_CMD(this);
            order.Show();
        }


        //상단 새로고침 버튼
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GridView_ReFresh();
        }


        // 그리드뷰 행번호 출력
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            using (Brush brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                                       e.InheritedRowStyle.Font,
                                       brush,
                                       e.RowBounds.Location.X + 30,
                                       e.RowBounds.Location.Y + 4, sf);
            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            using (Brush brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                                       e.InheritedRowStyle.Font,
                                       brush,
                                       e.RowBounds.Location.X + 30,
                                       e.RowBounds.Location.Y + 4, sf);
            }
        }



        // 수정 버튼 클릭시 
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    DataTable originDt = (DataTable)dataGridView1.DataSource;
        //    DataTable modifyDt;

        //    string str = "Server=localhost;Database=mes;Uid=root;Pwd=1234";
        //    MySqlConnection Conn = new MySqlConnection(str);
        //    Conn.Open(); // 데이터 베이스 오픈

        //    MySqlCommand cmd = new MySqlCommand("", Conn);

        //    modifyDt = originDt.GetChanges(DataRowState.Modified);
        //    if(modifyDt != null)
        //    {
        //        for(int i=0; i<modifyDt.Rows.Count; i++)
        //        {
        //            cmd.CommandText = "UPDATE ORDER_INFO_HEAD" +
        //                "SET ORDER_GUN = '" + modifyDt.Rows[i]["ORDER_GUBUN"] + "'" +
        //                "WHERE ORDER_NO = '" + modifyDt.Rows[i]["ORDER_NO"] + "'";
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    Conn.Close();

        //    // 이부분에 그리드뷰 리셋하는게 들어가면 된다.

        //}
    }
}
