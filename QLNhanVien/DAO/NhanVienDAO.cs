using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhanVienDAO
    {
        public static List<NhanVienDTO> selectNhanVien()
        {
            string query = "select * from nhanvien";

            DataTable tb = DataProvider.queryGetData(query, QLNVConnection.getInstance());
            QLNVConnection.open();
            List<NhanVienDTO> lstNhanVien = new List<NhanVienDTO>();
            if (tb.Rows.Count == 0)
                return null;
            foreach (DataRow dr in tb.Rows)
            {
                NhanVienDTO nhanVien = new NhanVienDTO()
                {
                    manv = dr["manv"].ToString(),
                    holot = dr["holot"].ToString(),
                    tennv = dr["tennv"].ToString(),
                    phai = dr["phai"].ToString(),
                    ngaysinh = DateTime.Parse(dr["ngaysinh"].ToString()),
                    macv = dr["macv"].ToString(),
                };
                lstNhanVien.Add(nhanVien);
            }
            QLNVConnection.close();
            return lstNhanVien;
        }
        public static NhanVienDTO selectNhanVienByManv(string manv)
        {
            string query = $"select * from nhanvien where manv = '{manv}'";
            QLNVConnection.open();
            DataTable tb = DataProvider.queryGetData(query, QLNVConnection.getInstance());
            if (tb.Rows.Count == 0)
                return null;
            var dr = tb.Rows[0];
            NhanVienDTO nhanVien = new NhanVienDTO()
            {
                manv = dr["manv"].ToString(),
                holot = dr["holot"].ToString(),
                tennv = dr["tennv"].ToString(),
                phai = dr["phai"].ToString(),
                ngaysinh = DateTime.Parse(dr["ngaysinh"].ToString()),
                macv = dr["macv"].ToString(),
            };
            QLNVConnection.close();
            return nhanVien;
        }
        public static List<NhanVienDTO> selectNhanVienByTennv(string tennv)
        {
            string query = $"select * from nhanvien where tennv like N'%{tennv}%'";
            QLNVConnection.open();
            DataTable tb = DataProvider.queryGetData(query, QLNVConnection.getInstance());
            if (tb.Rows.Count == 0)
                return null;

            List<NhanVienDTO> lstNhanVien = new List<NhanVienDTO>();
            foreach (DataRow dr in tb.Rows)
            {
                NhanVienDTO nhanVien = new NhanVienDTO()
                {
                    manv = dr["manv"].ToString(),
                    holot = dr["holot"].ToString(),
                    tennv = dr["tennv"].ToString(),
                    phai = dr["phai"].ToString(),
                    ngaysinh = DateTime.Parse(dr["ngaysinh"].ToString()),
                    macv = dr["macv"].ToString(),
                };
                lstNhanVien.Add(nhanVien);
            }

            QLNVConnection.close();
            return lstNhanVien;
        }

        public static List<NhanVienDTO> selectNhanVienByHoVaTen(string honv, string tennv)
        {
            string query = $"select * from nhanvien where tennv like N'%{tennv}%' and holot like N'%{honv}%'";
            QLNVConnection.open();
            DataTable tb = DataProvider.queryGetData(query, QLNVConnection.getInstance());
            if (tb.Rows.Count == 0)
                return null;

            List<NhanVienDTO> lstNhanVien = new List<NhanVienDTO>();
            foreach (DataRow dr in tb.Rows)
            {
                NhanVienDTO nhanVien = new NhanVienDTO()
                {
                    manv = dr["manv"].ToString(),
                    holot = dr["holot"].ToString(),
                    tennv = dr["tennv"].ToString(),
                    phai = dr["phai"].ToString(),
                    ngaysinh = DateTime.Parse(dr["ngaysinh"].ToString()),
                    macv = dr["macv"].ToString(),
                };
                lstNhanVien.Add(nhanVien);
            }

            QLNVConnection.close();
            return lstNhanVien;
        }

        public static bool insertNhanVien(NhanVienDTO nv)
        {
            string query = $"insert into nhanvien values(N'{nv.manv}',N'{nv.holot}',N'{nv.tennv}',N'{nv.phai}','{nv.ngaysinh}','{nv.macv}')";
            QLNVConnection.open();
            bool kq = DataProvider.queryNonGetData(query, QLNVConnection.getInstance());
            QLNVConnection.close();
            return kq;
        }
        public static bool updateNhanVien(NhanVienDTO nv)
        {
            string query = $@"update nhanvien
                              set manv = N'{nv.manv}',
                              holot = N'{nv.holot}',
                              tennv = N'{nv.tennv}',
                              phai = N'{nv.phai}',
                              ngaysinh = '{nv.ngaysinh}',
                              macv = '{nv.macv}'
                              where manv ='{nv.manv}'";

            QLNVConnection.open();
            bool kq = DataProvider.queryNonGetData(query, QLNVConnection.getInstance());
            QLNVConnection.close();
            return kq;
        }
        public static bool deleteNhanVien(string manv)
        {
            string query = $"delete nhanvien where manv = N'{manv}'";
            QLNVConnection.open();
            bool kq = DataProvider.queryNonGetData(query, QLNVConnection.getInstance());
            QLNVConnection.close();
            return kq;
        }
    }
}
