using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChucVuBUS
    {
        public static List<ChucVuDTO> selectChucVu()
        {
            return ChucVuDAO.selectChucVu();
        }
    }

}
