using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;

namespace QLDSV
{
    public partial class formMonHoc : DevExpress.XtraEditors.XtraForm
    {
        public formMonHoc()
        {
            InitializeComponent();
        }

        Boolean isCleared = false;
        public Stack st = new Stack();
        public class ObjectUndo
        {
            int type;//thêm = 1, xóa =2 , sửa =3
            String lenh;//lệnh SP

            public ObjectUndo(int t, String l)
            {
                this.type = t;
                this.lenh = l;
            }

            public int getType()
            {
                return type;
            }
            public String getLenh()
            {
                return lenh;
            }
        }

        public String maMH;
        public String tenMH;

        private void handleDuLieuFocus()
        {
            maMH = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAMH").ToString().Trim();
            tenMH = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TENMH").ToString().Trim();

        }

        public void validationButton()
        {
            if (Program.mGroup == "KHOA")
            {
               // txtMaMH.ReadOnly = true;
                txtTenMH.ReadOnly = true;
                btnThemMonHoc.Visible = false;
                btnSuaMonHoc.Visible = false;
                btnXoaMonHoc.Visible = false;
                btnClearMonHoc.Visible = false;
                btnPhucHoiMonHoc.Visible = false;
                gridView1.OptionsBehavior.ReadOnly = true;
            }
        }
        private void FormMonHoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSVROOT.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.qLDSVROOT.MONHOC);

            txtMaMH.ReadOnly = true;
            if (Program.conn.State == ConnectionState.Open) Program.conn.Close();

            // Disable add, Enable when click clear
            this.btnThemMonHoc.Enabled = false;

            validationButton();
        }

        private void ExcuteSP_Update_Insert_MonHoc(String spName, String dialogDescription)
        {

            Program.sqlcmd = Program.conn.CreateCommand();
            Program.sqlcmd.CommandType = CommandType.StoredProcedure;
            Program.sqlcmd.CommandText = spName;
            // SP variables
            Program.sqlcmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = txtMaMH.Text;
            Program.sqlcmd.Parameters.Add("@TENMH", SqlDbType.NVarChar).Value = txtTenMH.Text;
            // Run query 
            Program.sqlcmd.ExecuteNonQuery();
            this.mONHOCTableAdapter.Update(this.qLDSVROOT.MONHOC);
            this.mONHOCBindingSource.EndEdit();
            // refesh change 
            this.qLDSVROOT.MONHOC.AcceptChanges();
            this.mONHOCTableAdapter.Fill(this.qLDSVROOT.MONHOC);

            // Disabled btnThemMonHoc after added successfully
            MessageBox.Show(dialogDescription, "THÔNG BÁO", MessageBoxButtons.OK);
            this.btnThemMonHoc.Enabled = false;

        }

        private void BtnThemMonHoc_Click(object sender, EventArgs e)
        {
            // Checking error
            if (txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không được để trống!", "", MessageBoxButtons.OK);
                txtMaMH.Focus();
                return;
            }
            if(txtMaMH.Text.Trim().Length > 8)
            {
                MessageBox.Show("Mã môn học tối đa 8 ký tự!", "", MessageBoxButtons.OK);
                txtMaMH.Focus();
                return;
            }
            if (txtTenMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn học không được để trống!", "", MessageBoxButtons.OK);
                txtTenMH.Focus();
                return;
            }
            if (txtTenMH.Text.Trim().Length > 40)
            {
                MessageBox.Show("Tên môn học tối đa 40 ký tự!", "", MessageBoxButtons.OK);
                txtTenMH.Focus();
                return;
            }

            try
            {
                // SP return 
                // 1: exist
                // 0: not exist 
                // String strLenh = spName;
                if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                String spName = "SP_KiemMaMHTonTai";
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = spName;
                // SP Variables
                Program.sqlcmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = txtMaMH.Text;
                Program.sqlcmd.Parameters.Add("@TENMH", SqlDbType.NVarChar).Value = txtTenMH.Text;
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                String result = Program.sqlcmd.Parameters["@Ret"].Value.ToString();

                if (result == "1")
                {
                    MessageBox.Show("Mã môn học đã tồn tại.\n", "", MessageBoxButtons.OK);
                    Program.conn.Close();
                    return;
                }
                else if (result == "2")
                {
                    MessageBox.Show("Tên môn học đã tồn tại.\n", "", MessageBoxButtons.OK);
                    Program.conn.Close();
                    return;
                }
                else
                {
                    try
                    {
                        // Save action add Monhoc into Stack 
                        int type = 1;
                        String lenh = "exec SP_UndoThemMonHoc '" + txtMaMH.Text + "'";
                        ObjectUndo ob = new ObjectUndo(type, lenh);
                        st.Push(ob);
                        // Excute SP
                        ExcuteSP_Update_Insert_MonHoc("SP_InsertMonHoc", "Thêm môn học thành công");

                        isCleared = false;
                        // Do not allow user to edit MaMH
                        txtMaMH.ReadOnly = true;
                     
                        // Close connection
                        Program.conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi thêm môn học.\n" + ex.Message, "", MessageBoxButtons.OK);
                        Program.conn.Close();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra mã môn học.\n" + ex.Message, "", MessageBoxButtons.OK);
                Program.conn.Close();
                return;
            }

        }
       
        private void BtnClearMonHoc_Click(object sender, EventArgs e)
        {
            txtMaMH.Focus();
            // allow to enter MaMH
            txtMaMH.ReadOnly = false;
            // Disabled button
            this.btnThemMonHoc.Enabled = true;
            this.btnPhucHoiMonHoc.Enabled = true;
            // Create new row in grid control
            if(!isCleared)
            {
                this.mONHOCBindingSource.AddNew();
                isCleared = true;
            }
           
        }

        private void BtnRefeshMonHoc_Click(object sender, EventArgs e)
        {
            try
            {
                btnThemMonHoc.Enabled = false;
                txtMaMH.ReadOnly = true;
                // Fill table MONHOC, refesh data
                this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.mONHOCTableAdapter.Fill(this.qLDSVROOT.MONHOC);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void BtnXoaMonHoc_Click(object sender, EventArgs e)
        {
            // Delete on MAMH
            try
            {
                // Check if MaMH exists
                if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                String spName = "SP_KiemMaMHTonTai";
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = spName;

                // SP Variables
                Program.sqlcmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = txtMaMH.Text;
                Program.sqlcmd.Parameters.Add("@TENMH", SqlDbType.NVarChar).Value = txtTenMH.Text;
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                String result = Program.sqlcmd.Parameters["@Ret"].Value.ToString();

                // If maMH exists
                if (result == "1")
                {
                    try
                    {
                        // SP return 
                        // 1: exist
                        // 0: not exist 
                        // Check if MonHoc had Diem => cant delete
                        String spName1 = "SP_KiemMHTonTaiDiem";
                        Program.sqlcmd = Program.conn.CreateCommand();
                        Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                        Program.sqlcmd.CommandText = spName1;

                        // SP Variables
                        Program.sqlcmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = txtMaMH.Text;
                        Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                        Program.sqlcmd.ExecuteNonQuery();
                        String ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();

                        // If MonHoc had Diem
                        if (ret == "1")
                        {
                            MessageBox.Show("Mã môn này đã có điểm!", "THÔNG BÁO", MessageBoxButtons.OK);
                        }
                        if (ret == "0")
                        {
                            if (MessageBox.Show("Bạn có chắc muốn xóa nó không?", "Xóa môn học", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                // Save action delete Monhoc into Stack
                                int type = 2;
                                String lenh = "exec SP_UndoDeleteMonHoc '" + txtMaMH.Text + "', N'" + txtTenMH.Text + "'";
                                ObjectUndo ob = new ObjectUndo(type, lenh);
                                st.Push(ob);

                                // Delete Monhoc
                                this.mONHOCBindingSource.RemoveCurrent();
                                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK);
                                this.mONHOCTableAdapter.Update(this.qLDSVROOT.MONHOC);
                                Program.conn.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa môn học.\n" + ex.Message, "", MessageBoxButtons.OK);
                        Program.conn.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Mã môn học không tồn tại.\n", "THÔNG BÁO", MessageBoxButtons.OK);
                    Program.conn.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                // Can be if did not pick the Department 
                MessageBox.Show("Lỗi kiểm tra mã môn học.\n" + ex.Message, "", MessageBoxButtons.OK);
                Program.conn.Close();
                return;
            }
        }


        private void BtnSuaMonHoc_Click(object sender, EventArgs e)
        {

            if (txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không để trống!", "", MessageBoxButtons.OK);
                txtMaMH.Focus();
                return;
            }
            if (txtMaMH.Text.Trim().Length > 8)
            {
                MessageBox.Show("Mã môn học tối đa 8 ký tự!", "", MessageBoxButtons.OK);
                txtMaMH.Focus();
                return;
            }
            if (txtTenMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn học không để trống!", "", MessageBoxButtons.OK);
                txtTenMH.Focus();
                return;
            }
            if (txtTenMH.Text.Trim().Length > 40)
            {
                MessageBox.Show("Tên môn học tối đa 40 ký tự!", "", MessageBoxButtons.OK);
                txtTenMH.Focus();
                return;
            }
            try
            {
                // Check if MaMH exists
                if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                String spName = "SP_KiemMaMHTonTai";
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = spName;

                // SP Variables
                Program.sqlcmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = txtMaMH.Text;
                Program.sqlcmd.Parameters.Add("@TENMH", SqlDbType.NVarChar).Value = txtTenMH.Text;
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                String result = Program.sqlcmd.Parameters["@Ret"].Value.ToString();

                // If maMH exists
                if (result == "2")
                {
                    MessageBox.Show("Tên môn học đã tồn tại.\n", "", MessageBoxButtons.OK);
                    Program.conn.Close();
                    return;
                }
                else if(result == "0")
                {
                    MessageBox.Show("Mã môn học không tồn tại.\n", "", MessageBoxButtons.OK);
                    Program.conn.Close();
                    return;
                } else
                {
                    if (MessageBox.Show("Bạn có chắc muốn sửa không?", "Sửa môn học", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Get the row on focus contain data
                        handleDuLieuFocus();

                        // Save action update Monhoc into Stack
                        int type = 3;
                        String lenh = "exec SP_UndoUpdateMonHoc '" + maMH + "', N'" + tenMH + "'";
                        ObjectUndo ob = new ObjectUndo(type, lenh);
                        st.Push(ob);

                        // Run sp Update monHoc
                        if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                        ExcuteSP_Update_Insert_MonHoc("SP_UpdateMonHoc", "Sửa môn học thành công");
                        Program.conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra mã môn học.\n" + ex.Message, "", MessageBoxButtons.OK);
                Program.conn.Close();
                return;
            }
        }

        private void BtnThoatMonHoc_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        public void undo(String message, String spLenh)
        {
            if (MessageBox.Show(message, "Undo hoạt động", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                Program.ExecSqlDataReader(spLenh);

                MessageBox.Show(message + spLenh);
                // Fill datagridview
                this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.mONHOCTableAdapter.Fill(this.qLDSVROOT.MONHOC);
                Program.conn.Close();
            }

        }
        private void BtnPhucHoiMonHoc_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectUndo ob = (ObjectUndo)st.Pop();
                if (ob.getType() == 1)
                {
                    undo("Khôi phục sau khi thêm?", ob.getLenh());
                }
                if (ob.getType() == 2)
                {
                    undo("Khôi phục sau khi xóa?", ob.getLenh());
                }
                if (ob.getType() == 3)
                {
                    undo("Khôi phục sau khi sửa?", ob.getLenh());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có gì để Undo", "THÔNG BÁO", MessageBoxButtons.OK);
            }
        }

    }
}