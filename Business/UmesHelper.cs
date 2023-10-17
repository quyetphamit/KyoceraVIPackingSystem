using System;
using System.Linq;

namespace KyoceraVIPackingSystem.Business
{
    public static class UmesHelper
    {
        //private static bool _IsWip;
        public static bool IsWip { get { return _Item != null; } }
        private static PVSService.OrderItemEntity _Item;
        private static PVSService.BARCODE_RULE_ITEMSEntity _Rule_Item;
        public static PVSService.BARCODE_RULE_ITEMSEntity RuleItem
        {
            get
            {
                return _Rule_Item;
            }
        }
        public static PVSService.OrderItemEntity Item
        {
            get
            {
                return _Item;
            }
        }
        private static PVSService.WORK_ORDER_PROCEDURESEntity _Procedure;
        public static PVSService.WORK_ORDER_PROCEDURESEntity Procedure { get { return _Procedure; } }
        public static void FindUmes(string boardNo)
        {
            _Item = SingletonHelper.PVSInstance.GetOrderItem(boardNo);
            if (_Item != null)
            {
                _Procedure = SingletonHelper.PVSInstance.GetWoProcedure(_Item.ORDER_ID.ToString(), "VI2_KYD").FirstOrDefault();
            }
            else
            {
                _Rule_Item = SingletonHelper.PVSInstance.GetBarodeRuleItemsByRuleNo(UsapHelper.Model);
                if (_Rule_Item == null)
                {
                    var str1 = UsapHelper.Model.LastIndexOf('-');
                    _Rule_Item = SingletonHelper.PVSInstance.GetBarodeRuleItemsByRuleNo(UsapHelper.Model.Left(str1));
                }
            }

        }
        public static bool Unlock(string username, string password)
        {
            var user = SingletonHelper.PVSInstance.FindUser(username, password);
            if (user != null)
            {
                return user.Rules.Any(r => r.MODULE == "KYO_VI2" && r.RULE_ID == 1);
            }
            return false;
        }
        public static void RemoveRepair()
        {
            if (UmesHelper.IsWip)
            {
                var packEntity = SingletonHelper.ERPInstance.KyoGetBoard(_Item.BOARD_NO);
                if (packEntity != null)
                {
                    var repairEntity = SingletonHelper.PVSInstance.GetRepair(_Item.BOARD_NO);
                    if (repairEntity != null && DateTime.Compare(repairEntity.UPDATE_TIME, packEntity.DateCheck) > 0)
                    {
                        Console.WriteLine("Ahihi");
                        SingletonHelper.ERPInstance.KyoRemoveBoard(_Item.BOARD_NO);
                    }
                }
            }
        }
        public static string GetLinkErr(string boardNo)
        {
            //Ultils.CreateFileLog(UsapHelper.Model, boardNo, "P", "VI2_KYD", SingletonHelper.PVSInstance.GetDateTime());
            bool linkSuccess = false;
            if (UmesHelper.IsWip)
            {
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(500);
                    var orderItem = SingletonHelper.PVSInstance.GetWorkOrderItemByBoardNo(boardNo);
                    if (orderItem == null)
                    {
                        return "Không tìm thấy dữ liệu trên Umes!";
                    }
                    if (orderItem.STATION_NO == "VI2_KYD")
                    {
                        linkSuccess = true;
                        break;
                    }
                }

                if (!linkSuccess)
                {
                    return "Link WIP thất bại!";
                }
            }
            return null;
        }
    }
}
