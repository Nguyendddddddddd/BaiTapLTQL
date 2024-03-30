using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChucVuDAO
    {
       public static List<ChucVuDTO> selectChucVu()
        {
            String query = "select * from chucvu";
            DataTable dt = DataProvider.queryGetData(query, QLNVConnection.getInstance());
            QLNVConnection.open();
            if (dt.Rows.Count == 0)
                return null;
            List<ChucVuDTO> lstChucVu = new List<ChucVuDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                ChucVuDTO chucVu = new ChucVuDTO();
                chucVu.maCV = dr["macv"].ToString();
                chucVu.tenCV = dr["tencv"].ToString();
                chucVu.heSoPC = float.Parse(dr["hsphucap"].ToString());
                lstChucVu.Add(chucVu);
            }
            QLNVConnection.close();
            return lstChucVu;
        }
    }
}
