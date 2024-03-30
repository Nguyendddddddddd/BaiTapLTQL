using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class QuaTrinhLuongDAO
    {

        public static List<QuaTrinhLuongDTO> selectQuaTrinhLuong()
        {
            string query = "select * from quatrinhluong";

            DataTable tb = DataProvider.queryGetData(query, QLNVConnection.getInstance());
            QLNVConnection.open();
            List<QuaTrinhLuongDTO> lstQuaTrinhLuong = new List<QuaTrinhLuongDTO>();
            if (tb.Rows.Count == 0)
                return null;
            foreach (DataRow dr in tb.Rows)
            {
                QuaTrinhLuongDTO quaTrinhLuong = new QuaTrinhLuongDTO()
                {
                    manv = dr["manv"].ToString(),
                    ghichu = bool.Parse(dr["ghichu"].ToString()),
                    hsluong = float.Parse(dr["hsluong"].ToString()),
                    ngaybd = DateTime.Parse(dr["ngaybd"].ToString())
                };
                lstQuaTrinhLuong.Add(quaTrinhLuong);
            }
            QLNVConnection.close();
            return lstQuaTrinhLuong;
        }
        public static List<QuaTrinhLuongDTO> selectQuaTrinhLuongBetweenDay(DateTime daybd, DateTime daykt)
        {
            string query = $@"select * 
                              from quatrinhluong 
                              where ngaybd between '{daybd.Date.ToShortDateString()}' and '{daykt.Date.ToShortDateString()}' ";

            DataTable tb = DataProvider.queryGetData(query, QLNVConnection.getInstance());
            QLNVConnection.open();
            List<QuaTrinhLuongDTO> lstQuaTrinhLuong = new List<QuaTrinhLuongDTO>();
            if (tb.Rows.Count == 0)
                return null;
            foreach (DataRow dr in tb.Rows)
            {
                QuaTrinhLuongDTO quaTrinhLuong = new QuaTrinhLuongDTO()
                {
                    manv = dr["manv"].ToString(),
                    ghichu = bool.Parse(dr["ghichu"].ToString()),
                    hsluong = float.Parse(dr["hsluong"].ToString()),
                    ngaybd = DateTime.Parse(dr["ngaybd"].ToString())
                };
                lstQuaTrinhLuong.Add(quaTrinhLuong);
            }
            QLNVConnection.close();
            return lstQuaTrinhLuong;
        }
    }
}
