namespace KyoceraVIPackingSystem.Business
{
    public class UsapHelper
    {
        #region Fields
        private static bool _Exist;
        private static int _Wo_Qty;
        private static bool _CheckMac;
        public static bool Exist
        {
            get { return _Exist; }
        }
        public static int WoQty
        {
            get { return _Wo_Qty; }
        }
        public static bool CheckMac
        {
            get { return _CheckMac; }
        }
        public static ushort BoxQty
        {
            get
            {
                return (ushort)_BCLBFLM.OS_QTY;
            }
        }
        public static string OrderNo
        {
            get
            {
                return _BCLBFLM.TN_NO.Right(10);
            }
        }
        public static string BoxID
        {
            get
            {
                return _BCLBFLM.BC_NO;
            }
        }
        public static string Model
        {
            get
            {
                return _BCLBFLM.PART_NO;
            }
        }
        private static UsapService.BCLBFLMEntity _BCLBFLM;

        #endregion
        #region Private Methods
        private static bool ExistBoxID(string boxID)
        {
            if (!boxID.StartsWith("F0"))
            {
                return false;
            }
            _BCLBFLM = SingletonHelper.UsapInstance.GetByBcNo(boxID);
            return _BCLBFLM != null ? true : false;
        }
        #endregion
        #region Public Methods
        public static void FindBoxID(string boxID)
        {
            if (ExistBoxID(boxID))
            {
                _Exist = true;
                _Wo_Qty = (int)SingletonHelper.UsapInstance.FindWoQty(_BCLBFLM.TN_NO);
                _CheckMac = SingletonHelper.ERPInstance.KyoCheckMac(_BCLBFLM.PART_NO);
                if (!_CheckMac)
                {
                    _CheckMac = SingletonHelper.ERPInstance.KyoCheckMac(_BCLBFLM.PART_NO.LeftOf('-'));
                }
            }
            else
            {
                _Exist = false;
            }
        }
        #endregion
    }
}
