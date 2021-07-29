using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using Web_Girls.Models.Context;
using Web_Girls.Models.ModelsView;

namespace Web_Girls.Models.Reponsivity
{
    public class AccountResposi
    {
        public List<AccountView> ViewAc()
        {
            using (var context = new MyContext())
            {
                var ListTK = context.TaiKhoans.AsNoTracking().Include("HoiVien");
                var ListTKView = new List<AccountView>();
                int dem = 0;
                foreach (var TK in ListTK)
                {
                    dem++;
                    var tk = new AccountView();
                    tk.STT = dem;
                    tk.MaHV = TK.MaHV;
                    tk.TenHV = TK.HoiVien.TenHV;
                    tk.Quyen = TK.Quyen;
                    tk.Khoa = TK.Khoa;
                    tk.EditTime = TK.EditTime.ToString("dd/MM/yyyy HH:mm:ss.fff");
                    tk.TenDN = TK.TenDN;
                    ListTKView.Add(tk);
                }
                return ListTKView;
            }
        }
        public AccountViewItem ViewAcI(string TenDN)
        {
            using(var context = new MyContext())
            {
                var Ac = context.TaiKhoans.AsNoTracking().Where(x => x.TenDN == TenDN).Include("HoiVien").FirstOrDefault();
                //var Ac=AC.fi
                var AcI = new AccountViewItem();
                AcI.MaHV = Ac.MaHV;
                AcI.TenHV = Ac.HoiVien.TenHV;
                AcI.TenDN = Ac.TenDN;
                AcI.Khoa = Ac.Khoa;
                AcI.NgaySinh = Ac.HoiVien.NgaySinh.ToString("dd/MM/yyyy");
                AcI.Email = Ac.HoiVien.Email;
                AcI.SDT = Ac.HoiVien.SDT;
                return AcI;
            }    
        }
        public bool isKeyAc(AccountViewItem id)
        {
            using (var context = new MyContext())
            {
                if (id != null)
                {
                    var Ac = context.TaiKhoans.Find(id.TenDN);
                    Ac.Khoa = id.Khoa;
                    context.SaveChanges();
                    return true;
                }
                else return false;   
               
            }
        }
    }
}