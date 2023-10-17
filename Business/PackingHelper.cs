using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyoceraVIPackingSystem.Business
{
    public class PackingHelper
    {
        public static bool IsFinish
        {
            get
            {
                return _box_items.Count >= UsapHelper.BoxQty;
            }
        }
        public static ushort BoxQty
        {
            get
            {
                return (ushort)_box_items.Count;
            }
        }
        public static int WoQty
        {
            get
            {
                return _Wo_Qty;
            }
        }
        private static int _Wo_Qty;
        private static List<ERPService.KYOCERAEntity> _box_items = null;
        public static List<ERPService.KYOCERAEntity> BoxItems
        {
            get
            {
                return _box_items;
            }
        }
        public static void GetBoxItems(string boxID)
        {
            var items = SingletonHelper.ERPInstance.KyoGetMac(boxID);
            _box_items = items == null ? new List<ERPService.KYOCERAEntity>() : items.OrderByDescending(r => r.DateCheck).ThenByDescending(r => r.TimeCheck).ToList();
            _Wo_Qty = SingletonHelper.ERPInstance.KyoGetQty(UsapHelper.OrderNo);
        }
    }
}
