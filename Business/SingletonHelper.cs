﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KyoceraVIPackingSystem.Business
{
    public class SingletonHelper
    {
        private static volatile PVSService.PVSWebServiceSoapClient _pvs_service = null;
        private static volatile UsapService.USAPWebServiceSoapClient _usap_service = null;
        private static volatile ERPService.ERPWebServiceSoapClient _erp_service = null;
        private static readonly object sync = new object();
        private SingletonHelper()
        {

        }
        public static PVSService.PVSWebServiceSoapClient PVSInstance
        {
            get
            {
                if (_pvs_service == null)
                {
                    lock (sync)
                    {
                        if (_pvs_service == null)
                        {
                            _pvs_service = new PVSService.PVSWebServiceSoapClient();
                        }
                    }
                }
                return _pvs_service;
            }
        }
        public static UsapService.USAPWebServiceSoapClient UsapInstance
        {
            get
            {
                if (_usap_service == null)
                {
                    lock (sync)
                    {
                        if (_usap_service == null)
                        {
                            _usap_service = new UsapService.USAPWebServiceSoapClient();
                        }
                    }
                }
                return _usap_service;
            }
        }
        public static ERPService.ERPWebServiceSoapClient ERPInstance
        {
            get
            {
                if (_erp_service == null)
                {
                    lock (sync)
                    {
                        if (_erp_service == null)
                        {
                            _erp_service = new ERPService.ERPWebServiceSoapClient();
                        }
                    }
                }
                return _erp_service;
            }
        }
    }
}
