using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class QuaTrinhLuongBUS
    {
        public static List<QuaTrinhLuongDTO> selectQuaTrinhLuong()
        {
            return QuaTrinhLuongDAO.selectQuaTrinhLuong();
        }
        public static List<QuaTrinhLuongDTO> selectQuaTrinhLuongBetweenDay(DateTime daybd, DateTime daykt)
        {
            return QuaTrinhLuongDAO.selectQuaTrinhLuongBetweenDay(daybd, daykt);
        }
    }
}
