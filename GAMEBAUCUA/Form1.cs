using System.Runtime.InteropServices;

namespace GAMEBAUCUA
{
    public partial class Form1 : Form
    {
        int limit = 0;
        int[] check = { 0, 0, 0, 0, 0, 0 }; // Mảng để thực hiện check các điều kiện
        // phụ thuộc vào vị trí của các lựa chọn
        int betMoney = 0; // Mệnh giá cược
        int totalBet = 0; // Tổng tiền cược
        int totalMoney = 10000; // Tiền gốc mặc định là 1000
        int winMoney = 0; // Tổng tiền thắng cược
        public Form1() // contructer
        {
            InitializeComponent();  // khởi tạo compoment
            lb_Tien.Text = totalMoney.ToString();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            // tạo 1 mảng chứa đường dẫn đến ảnh 
            string[] imagesURL = new string[]
            {
                @"E:\FPT_Poly\DuAnMau\AnhBauCua\z4752866875804_aea4a56dfc3506aff563c3ba12f8db01.jpg",
                @"E:\FPT_Poly\DuAnMau\AnhBauCua\z4752866792472_8f5b89155c43b1000eaa25de6405ee1a.jpg",
                @"E:\FPT_Poly\DuAnMau\AnhBauCua\z4752866823149_cdbddbe4fce932d1f7329ca9537aca4c.jpg",
                @"E:\FPT_Poly\DuAnMau\AnhBauCua\z4752866844462_501976b2960b18b6009fc3811e56adbb.jpg",
                @"E:\FPT_Poly\DuAnMau\AnhBauCua\z4752866865262_dacbb861e6419f65ec8d80a0eb72dbd4.jpg",
                @"E:\FPT_Poly\DuAnMau\AnhBauCua\z4752866865270_0152c2392166ac2284db33f7c38f27c2.jpg"

            };
            //int r1 = r.Next(0, 5); int r2 = r.Next(0, 5); int r3 = r.Next(0, 5);
            int r1 = r.Next(imagesURL.Length);
            int r2 = r.Next(0, 5);
            int r3 = r.Next(imagesURL.Length);
            ptb_R1.Image = Image.FromFile(imagesURL[r1]);
            ptb_R2.Image = Image.FromFile(imagesURL[r2]);
            ptb_R3.Image = Image.FromFile(imagesURL[r3]);

            TotalBet();
            winMoney = check[r1] * betMoney + check[r2] * betMoney + check[r3] * betMoney;
            totalMoney = totalMoney = totalMoney + winMoney * 2 - totalBet;
            // MessageBox.Show($"Tổng tiền cược {totalBet}\n" +
            //$"Tổng tiền thắng {winMoney}, {betMoney}, {limit}");
            betMoney = 0;
            winMoney = 0;
            totalBet = 0;
            limit = 0; // Reset hết các giá trị sau mỗi lần chơi
            lb_Tien.Text = totalMoney.ToString();
            check = new int[] { 0, 0, 0, 0, 0, 0 }; // reset sau khi chơi mỗi lần
            ResetComponent();

        }
        public void ResetComponent()
        {
            lb_Bau.Text = "0"; lb_Cua.Text = "0"; lb_Tom.Text = "0";
            lb_Ca.Text = "0"; lb_Ga.Text = "0"; lb_Huou.Text = "0";
            rdb_1000.Checked = false; rdb_2000.Checked = false; rdb_10000.Checked = false;
            rdb_1000.BackColor = Color.White;
            rdb_2000.BackColor = Color.White;
            rdb_10000.BackColor = Color.White;
        }

        private void btn_Start_MouseHover(object sender, EventArgs e)
        {
            btn_Start.BackColor = Color.BlueViolet;
        }
        public void DatCuoc(Label lb)
        {
            lb.Text = Convert.ToInt32(lb.Text) + 1 + "";
            limit++;   // tổng số lượt chọn +1
            if (limit > 3)
            {
                limit -= Convert.ToInt32(lb_Bau.Text);
                lb.Text = "0";
            }
            //MessageBox.Show(limit.ToString());
        }
        private void ptb_Bau_Click(object sender, EventArgs e)
        {
            DatCuoc(lb_Bau);
            //lb_Bau.Text = Convert.ToInt32(lb_Bau.Text) + 1 + "";\
            //limit++;   // tổng số lượt chọn +1
            //if (limit > 3)
            //{
            //    limit -= Convert.ToInt32(lb_Bau.Text);
            //    lb_Bau.Text = "0";
            //}
            //MessageBox.Show(limit.ToString());

        }
        private void ptb_Cua_Click(object sender, EventArgs e)
        {
            DatCuoc(lb_Cua);
        }

        private void ptp_Tom_Click(object sender, EventArgs e)
        {
            DatCuoc(lb_Tom);
        }

        private void ptb_Ca_Click(object sender, EventArgs e)
        {
            DatCuoc(lb_Ca);
        }

        private void ptb_Ga_Click(object sender, EventArgs e)
        {
            DatCuoc(lb_Ga);
        }

        private void ptb_Huou_Click(object sender, EventArgs e)
        {
            DatCuoc(lb_Huou);
        }

        private void rdb_1000_CheckedChanged(object sender, EventArgs e)
        {
            if (betMoney != 1000 && rdb_1000.Checked)
            {
                betMoney = 1000;
                rdb_1000.BackColor = Color.AntiqueWhite;
                rdb_10000.BackColor = Color.White;
                rdb_2000.BackColor = Color.White;
            }
        }
        public bool CheckBetMoney()
        {
            if (totalMoney < betMoney)
            {
                MessageBox.Show("Bạn không đủ tiền để đặt mức cược này");
                return false;
            }
            return true;
        }

        private void rdb_2000_CheckedChanged(object sender, EventArgs e)
        {
            if (betMoney != 2000 && rdb_2000.Checked)
            {
                betMoney = 2000;
                rdb_2000.BackColor = Color.AntiqueWhite;
                rdb_10000.BackColor = Color.White;
                rdb_1000.BackColor = Color.White;
            }
        }

        private void rdb_10000_CheckedChanged(object sender, EventArgs e)
        {
            if (betMoney != 10000 && rdb_10000.Checked)
            {
                betMoney = 10000;
                rdb_10000.BackColor = Color.AntiqueWhite;
                rdb_1000.BackColor = Color.White;
                rdb_2000.BackColor = Color.White;
            }
        }
        public void TotalBet()
        {
            if (lb_Bau.Text != "0") check[0] = Convert.ToInt32(lb_Bau.Text);
            if (lb_Cua.Text != "0") check[1] = Convert.ToInt32(lb_Cua.Text);
            if (lb_Tom.Text != "0") check[2] = Convert.ToInt32(lb_Tom.Text);
            if (lb_Ca.Text != "0") check[3] = Convert.ToInt32(lb_Ca.Text);
            if (lb_Ga.Text != "0") check[4] = Convert.ToInt32(lb_Ga.Text);
            if (lb_Huou.Text != "0") check[5] = Convert.ToInt32(lb_Huou.Text);
            // Tính tổng tiền cược
            int count = 0;
            foreach (int item in check) count += item; // Tính tổng số lượng đặt cược
            totalBet = count * betMoney;
            // Tạo Message để test


        }
    }
}