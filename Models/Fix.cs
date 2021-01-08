using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shoping_Cart.Models
{
    public class Fix
    {
        public static List<CartItem> c = new List<CartItem>();
    }
    public class CartItem
    {
        public int iid;
        public int iqty;
    }
}