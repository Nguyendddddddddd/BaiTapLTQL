using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVienBUS
    {
        public static List<NhanVienDTO> selectNhanVien()
        {
            return NhanVienDAO.selectNhanVien();
        }
        public static bool insertNhanVien(NhanVienDTO nhanVien)
        {
            return NhanVienDAO.insertNhanVien(nhanVien);
        }
        public static bool updateNhanVien(NhanVienDTO nhanVien)
        {
            return NhanVienDAO.updateNhanVien(nhanVien);
        }
        public static bool deleteNhanVien(string manv)
        {
            return NhanVienDAO.deleteNhanVien(manv);
        }
        public static NhanVienDTO selectNhanVienByManv(string manv)
        {
            return NhanVienDAO.selectNhanVienByManv(manv);
        }
        public static List<NhanVienDTO> selectNhanVienByTennv(string tennv)
        {
            return NhanVienDAO.selectNhanVienByTennv(tennv);
        }
        public static List<NhanVienDTO> selectNhanVienByHoVaTen(string tennv, string honv)
        {
            return NhanVienDAO.selectNhanVienByHoVaTen(honv, tennv);
        }
    }
}
