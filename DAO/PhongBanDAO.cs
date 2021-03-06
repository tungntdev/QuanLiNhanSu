﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class PhongBanDAO
    {
        public static SqlConnection con;

        public static DataTable LoadDataPB()
        {
            string sTruyVan = "select * from tblPhongBan";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static bool ThemPB(PhongBanDTO pb)
        {
            try
            {
                string sTruyVan = string.Format("Insert into tblPhongBan(IDPhong,TenPhong,IDTruongPhong,NgayNhanChuc) values ({0},N'{1}',{2},'{3}')", pb.IdPhong, pb.TenPhong, pb.IdTruongPhong, pb.NgayNhanChuc);
                con = DataProvider.KetNoi();
                DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }

            catch
            {
                return false;
            }
        }

        public static bool SuaPB(PhongBanDTO pb)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format("Update tblPhongBan set TenPhong = N'{0}',IDTruongPhong={1},NgayNhanChuc = '{2}' where IDNhanVien={3}", pb.TenPhong, pb.IdTruongPhong, pb.NgayNhanChuc, pb.IdPhong);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaPB(PhongBanDTO pb)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format("Delete tblPhongBan x where x.IDPhong={0} and Delete tblNhanVien a where a.IDPhong={1}", pb.IdPhong,pb.IdPhong);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
