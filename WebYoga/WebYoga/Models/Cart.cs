using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebYoga.Model;

namespace WebYoga.Models
{
    [Serializable]
    public class Cart
    {
        public tblSanPham SanPham { get; set; }
        public int SoLuong { get; set; }
    }
}