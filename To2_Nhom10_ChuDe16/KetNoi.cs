using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace To2_Nhom10_ChuDe16
{
    class KetNoi
    {
        static public String ChuoiKetNoi()
        {
            return @"Data Source=LAPTOP-DQR4CKJE\SQLEXPRESS;Initial Catalog=QLXE_TAIXE;Integrated Security=True";
        }

        static public bool KiemTraSoLonHon0(string str)
        {
            try
            {
                int so = Int32.Parse(str);
                if (so < 0)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
