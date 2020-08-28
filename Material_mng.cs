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
    public partial class Material_mng : Form
    {
        MySqlConnection mySqlConnection = new MySqlConnection
      ("datasource=localhost;port=3306;Database=MES;username=root;password=1213");

        MySqlCommand mySqlCommand;
        MySqlDataAdapter mySqlDataAdapter;
        DataTable dataTable = new DataTable();

        public Material_mng()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            MySqlCommand mySqlCommand;
            MySqlDataAdapter mySqlDataAdapter;
            DataTable dataTable = new DataTable();

            mySqlConnection.Open(); // 데이터 베이스 오픈
            
            // 데이터 베이스 접속 상태 체크 
            if(mySqlConnection.State == ConnectionState.Open)
                MessageBox.Show("DB 접속 성공");
            else
                MessageBox.Show("DB 접속 실패");

            // 데이터 베이스에 명령어 내리기 
            string SQL = "SELECT * FROM MATERIAL_ORDER_HEAD";
            mySqlDataAdapter = new MySqlDataAdapter(SQL, mySqlConnection);
            mySqlDataAdapter.Fill(dataTable); // dat가 sql 명령문을 실행해서 그 결과를 dt에 가득 채운다.

            dataGridView1.DataSource = dataTable;

            #region 헤더 헤더명 변경
            dataGridView1.Columns[0].HeaderText = "발주번호";
            dataGridView1.Columns[1].HeaderText = "발주일자";
            dataGridView1.Columns[2].HeaderText = "입고예정일자";
            dataGridView1.Columns[3].HeaderText = "발주담당자";
            dataGridView1.Columns[4].HeaderText = "발주양";
            dataGridView1.Columns[5].HeaderText = "발주금액";
            dataGridView1.Columns[6].HeaderText = "특이사항";
            dataGridView1.Columns[7].HeaderText = "상태";
            dataGridView1.Columns[8].HeaderText = "작성자";
            dataGridView1.Columns[9].HeaderText = "작성일자";
            dataGridView1.Columns[10].HeaderText = "수정자";
            dataGridView1.Columns[11].HeaderText = "수정일자";
            #endregion

            mySqlConnection.Close(); 

        }

        // 셀 클릭시 
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 선택한 행의 첫번째 값을 가져온다. 여기선 ORDER_NO의 값
            string matOrderNum = dataGridView1.CurrentRow.Cells[0].Value.ToString(); //발주번호

            MySqlCommand mySqlCommand;
            MySqlDataAdapter mySqlDataAdapter;
            DataTable dataTable = new DataTable();

            mySqlConnection.Open(); // 데이터 베이스 오픈


            string SQL = "SELECT * FROM material_order_body where mat_order_no ='" + matOrderNum +"'";
            mySqlDataAdapter = new MySqlDataAdapter(SQL, mySqlConnection);
            mySqlDataAdapter.Fill(dataTable); // dat가 sql 명령문을 실행해서 그 결과를 dt에 가득 채운다.

            dataGridView2.DataSource = dataTable;

            #region 바디 헤더명 변경
            dataGridView2.Columns[0].HeaderText = "데이터아이디";
            dataGridView2.Columns[1].HeaderText = "발주번호";
            dataGridView2.Columns[2].HeaderText = "자재구분";
            dataGridView2.Columns[3].HeaderText = "자재코드";
            dataGridView2.Columns[4].HeaderText = "자재명";
            dataGridView2.Columns[5].HeaderText = "단위";
            dataGridView2.Columns[6].HeaderText = "수량";
            dataGridView2.Columns[7].HeaderText = "단가";
            dataGridView2.Columns[8].HeaderText = "금액";
            dataGridView2.Columns[9].HeaderText = "HS코드";
            dataGridView2.Columns[10].HeaderText = "발주처담당자";
            dataGridView2.Columns[11].HeaderText = "발주처번호";
            dataGridView2.Columns[12].HeaderText = "비고";
            dataGridView2.Columns[13].HeaderText = "상태";
            dataGridView2.Columns[14].HeaderText = "작성자";
            dataGridView2.Columns[15].HeaderText = "작성일자";
            dataGridView2.Columns[16].HeaderText = "수정자";
            dataGridView2.Columns[16].HeaderText = "수정일자";
            #endregion


            mySqlConnection.Close();

        }


        // 그리드뷰 갱신
        public void GridView_Refresh()
        {
            //dataGridView1.Rows.Clear(); // 일단 지금 표에 있는건 다지워

            MySqlCommand mySqlCommand;
            MySqlDataAdapter mySqlDataAdapter;
            DataTable dataTable = new DataTable();

            mySqlConnection.Open(); // 데이터 베이스 오픈

            string SQL = "SELECT * FROM material_order_head";
            mySqlDataAdapter = new MySqlDataAdapter(SQL, mySqlConnection);
            mySqlDataAdapter.Fill(dataTable); // dat가 sql 명령문을 실행해서 그 결과를 dt에 가득 채운다.

            dataGridView1.DataSource = dataTable;

            mySqlConnection.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        //신규버튼 클릭
      


        //상단 새로고침 버튼
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GridView_Refresh();
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

        
        // 신규버튼 클릭
        private void button2_Click(object sender, EventArgs e)
        {
            Material_CMD mc = new Material_CMD(this);
            mc.Show();
        }

    }
}
