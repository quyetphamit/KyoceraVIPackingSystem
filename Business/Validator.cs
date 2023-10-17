﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace KyoceraVIPackingSystem.Business
{
    public class Validator
    {
        //        public static List<string> modelCheckFCT = new List<string>()
        //        {
        //           "3V2SK01030","3V2SK01050","3V2SK80060","3V2SL01026","3V2SL01070","3V2SL01080","3V2SL80060","3V2SL80070",
        //           "3V2SL80080","3V2SL80090","3V2SM01050","3V2SM01060","3V2SM80260","3V2SM80270","3V2SM80280","3V2SM80290",
        //           "3V2TL01016","3V2TL01030","3V2TL01050","3V2TL80040","3V2YB0101A","3V2YB0102A","3V2YC0101A","3V2YC0102A",
        //           "3V2YD0101A","3V2YD0102A","3V2YF01017",
        //           "3V2LV01243",
        //"3V2MS01010",
        //"3V2LV01025",
        //"3V2LV01184",
        //"3V2LV01194",
        //"3V2LV01204",
        //"3V2LV01311",
        //"3V2LV01214",
        //"3V2LV80222",
        //"3V2LV80243",
        //"3V2LV80321",
        //"3V2LV80263",
        //"3V2LV80230",
        //"3V2LV80232",
        //"3V2LV80250",
        //"3V2LV80270",
        //"3V2LV80252",
        //"3V2LV80271",
        //"3V2LV80274",
        //"3V2LV80301",
        //"3V2MS80130",
        //"3V2MS80132",
        //"3V2LV01193",
        //"3V2LV01202",
        //"3V2LV01023",
        //"3V2LV01182",
        //"3V2LV01183",
        //"3V2LV01192",
        //"3V2LV01310",
        //"3V2LV80221",
        //"3V2LV80231",
        //"3V2LV80242",
        //"3V2LV80300",
        //"3V2P701112",
        //"3V2P701121",
        //"3V2P701130",
        //"3V2P701140",
        //"3V2P701070",
        //"3V2P701071",
        //"3V2P701072",
        //"3V2P701074",
        //"3V2P701075",
        //"3V2P780061",
        //"3V2P780082",
        //"3V2P780172",
        //"3V2P780182",
        //"3V2P780192",
        //"3V2P780231",
        //"3V2P780211",
        //"3V2P780241",
        //"3V2P701131",
        //"3V2P701073",
        //"3V2P701110",
        //"3V2P701111",
        //"3V2P701120",
        //"3V2R280024",
        //"3V2R380064",
        //"3V2R280123",
        //"3V2R301016",
        //"3V2R201033",
        //"3V2R201017",
        //"3V2R201018",
        //"3V2R201034",
        //"3V2R301017",
        //"3V2R201019",
        //"3V2TP01200",
        //"3V2TP01210",
        //"3V2Y301010",
        //"3V2Y401010",
        //"3V2Y401060",
        //"3V2WD01010",
        //"3V2Y380010",
        //"3V2Y480010",
        //"3V2TP01181",
        //"3V2TP01171",
        //"3V2TT01070",
        //"3V2Y401030",
        //"3V2TP80051",
        //"3V2TP80071",
        //"3V2TT80080",
        //"3V2Y480040",
        //"3V2TT01050",
        //"3V2TT01090",
        //"3V2Y401050",
        //"3V2Y480060",
        //"3V2TS01060",
        //"3V2TS01070",
        //"3V2TS01080",
        //"3V2TS01090",
        //"3V2TS80090",
        //"3V2TS80100",
        //"3V2Y380011",
        //"3V2Y480011",
        //"3VC0T01010",
        //"3VC0T80040",
        //"3V2T601014",
        //"3V2T601015",
        //"3V2T601120",
        //"3V2T601131",
        //"3V2T601132",
        //"3V2T901061",
        //"3V2T901081",
        //"3V2TP01010",
        //"3V2T601140",
        //"3V2T680202",
        //"3V2T680221",
        //"3V2T680231",
        //"3V2T980241",
        //"3V2T980251",
        //"3V2T601016",
        //"3V2T601133",
        //"3V2TP01011",
        //"3V2T601017",
        //"3V2T601134",
        //"3V2TP01012",
        //"3V2TP80050",
        //"3V2TP01013",
        //"3V2TP01014",
        //"3V2T601018",
        //"3V2T601135",
        //"3V2TT01030",
        //"3V2TP01160",
        //"3V2TP80070",
        //"3V2TP01015",
        //"3V2TP01161",
        //"3V2YB01010",
        //"3V2YB01020",
        //"3V2YC01010",
        //"3V2YC01020",
        //"3V2YD01010",
        //"3V2YD01020",
        //"3V2YF01010",
        //"3V2YB01011",
        //"3V2YB01021",
        //"3V2YC01011",
        //"3V2YC01021",
        //"3V2YD01011",
        //"3V2YD01021",
        //"3V2YF01011",
        //"3V2YB01012",
        //"3V2YB01022",
        //"3V2YC01012",
        //"3V2YC01022",
        //"3V2YD01012",
        //"3V2YD01022",
        //"3V2YF01012",
        //"3V2YB01013",
        //"3V2YB01023",
        //"3V2YC01013",
        //"3V2YC01023",
        //"3V2YD01013",
        //"3V2YD01023",
        //"3V2YF01013",
        //"3V2YB01014",
        //"3V2YB01024",
        //"3V2YC01014",
        //"3V2YC01024",
        //"3V2YD01014",
        //"3V2YD01024",
        //"3V2YF01014",
        //"3V2YB01015",
        //"3V2YB01025",
        //"3V2YC01015",
        //"3V2YC01025",
        //"3V2YD01015",
        //"3V2YD01025",
        //"3V2YB01016",
        //"3V2YB01026",
        //"3V2YC01016",
        //"3V2YC01026",
        //"3V2YD01016",
        //"3V2YD01026",
        //"3V2YF01015",
        //"3V2YD01017",
        //"3V2YC01017",
        //"3V2YB01017",
        //"3V2YD01027",
        //"3V2YC01027",
        //"3V2YB01027",
        //"3V2YB01019",
        //"3V2YB01029",
        //"3V2YC01019",
        //"3V2YC01029",
        //"3V2YD01019",
        //"3V2YD01029",
        //"3V2YF01016",
        //"3V2YB0101A",
        //"3V2YB0102A",
        //"3V2YC0101A",
        //"3V2YC0102A",
        //"3V2YD0101A",
        //"3V2YD0102A",
        //"3V2YF01017",
        //"3V2M601014",
        //"3V2M601510",
        //"3V2M680023",
        //"3V2M680033",
        //"3V2M680043",
        //"3V2M680050",
        //"3V2M680063",
        //"3V2M701015",
        //"3V2M701022",
        //"3V2M701025",
        //"3V2M701510",
        //"3V2M780023",
        //"3V2M780033",
        //"3V2M780043",
        //"3V2M780050",
        //"3V2M780063",
        //"3V2M780070",
        //"3V2M780074",
        //"3V2M780083",
        //"3V2M780090",
        //"3V2M780103",
        //"3V2M701026",
        //"3V2M780110",
        //"3V2M780075",
        //"3V2M601015",
        //"3V2M601512",
        //"3V2M680024",
        //"3V2M680034",
        //"3V2M680044",
        //"3V2M680052",
        //"3V2M680064",
        //"3V2M701016",
        //"3V2M701027",
        //"3V2M701512",
        //"3V2M780024",
        //"3V2M780034",
        //"3V2M780044",
        //"3V2M780052",
        //"3V2M780064",
        //"3V2M780076",
        //"3V2M780084",
        //"3V2M780092",
        //"3V2M780104",
        //"3V2M780111",
        //"3V2M601016",
        //"3V2M601513",
        //"3V2M680025",
        //"3V2M680035",
        //"3V2M680045",
        //"3V2M680053",
        //"3V2M680065",
        //"3V2M701017",
        //"3V2M701028",
        //"3V2M701513",
        //"3V2M780025",
        //"3V2M780035",
        //"3V2M780045",
        //"3V2M780053",
        //"3V2M780065",
        //"3V2M780077",
        //"3V2M780085",
        //"3V2M780093",
        //"3V2M780105",
        //"3V2M780112",
        //"3V2M601017",
        //"3V2M601514",
        //"3V2M680054",
        //"3V2M701018",
        //"3V2M701029",
        //"3V2M701514",
        //"3V2M780054",
        //"3V2M780094",
        //"3V2M601018",
        //"3V2M601515",
        //"3V2M701019",
        //"3V2M70102A",
        //"3V2M701515",
        //"3V2M680036",
        //"3V2M680046",
        //"3V2M680055",
        //"3V2M780095",
        //"3V2M601019",
        //"3V2M601516",
        //"3V2M680026",
        //"3V2M680066",
        //"3V2M70101A",
        //"3V2M70102B",
        //"3V2M701516",
        //"3V2M780026",
        //"3V2M780036",
        //"3V2M780046",
        //"3V2M780055",
        //"3V2M780066",
        //"3V2M780078",
        //"3V2M780086",
        //"3V2M780106",
        //"3V2M780113",
        //"3V2M301013",
        //"3V2M301033",
        //"3V2M301511",
        //"3V2M380083",
        //"3V2M380093",
        //"3V2M380103",
        //"3V2M380110",
        //"3V2M380123",
        //"3V2M380133",
        //"3V2M380143",
        //"3V2M301510",
        //"3V2M380160",
        //"3V2M301512",
        //"3V2M301513",
        //"3V2M380111",
        //"3V2M301014",
        //"3V2M301034",
        //"3V2M380084",
        //"3V2M380094",
        //"3V2M380104",
        //"3V2M380124",
        //"3V2M380134",
        //"3V2M380144",
        //"3V2M380161",
        //"3V2M301015",
        //"3V2M301035",
        //"3V2M301016",
        //"3V2M301036",
        //"3V2M301514",
        //"3V2M380085",
        //"3V2M380095",
        //"3V2M380105",
        //"3V2M380112",
        //"3V2M380125",
        //"3V2M380135",
        //"3V2M380145",
        //"3V2M380162",
        //"3V2SL01015",
        //"3V2SL01020",
        //"3V2SK01010",
        //"3V2SL01025",
        //"3V2SK01015",
        //"3V2SM01010",
        //"3V2SM01015",
        //"3V2SM01025",
        //"3V2TL01015",
        //"3V2SK80044",
        //"3V2SL80040",
        //"3V2SL80044",
        //"3V2SL80054",
        //"3V2SM80090",
        //"3V2SM80094",
        //"3V2SM80100",
        //"3V2SM80104",
        //"3V2TL80020",
        //"3V2TL80024",
        //"3V2SK01016",
        //"3V2SK80045",
        //"3V2SL01016",
        //"3V2SL01026",
        //"3V2SL80045",
        //"3V2SL80055",
        //"3V2SM01016",
        //"3V2SM01026",
        //"3V2SM80095",
        //"3V2SM80105",
        //"3V2TL01016",
        //"3V2TL80025",
        //"3V2SL01017",
        //"3V2SL01027",
        //"3V2SL80046",
        //"3V2SL80056",
        //"3V2SM01017",
        //"3V2SM01027",
        //"3V2SM80096",
        //"3V2SM80106",
        //"3V2SL01018",
        //"3V2SL01028",
        //"3V2SM01018",
        //"3V2SM01028",
        //"3V2SL01019",
        //"3V2SL01029",
        //"3V2SM01019",
        //"3V2SM01029",
        //"3V2SL0102A",
        //"3V2SM0102A",
        //"3V2SL0101A",
        //"3V2SM0101A",
        //"3V2SL01080",
        //"3V2SL80080",
        //"3V2SL80090",
        //"3V2SM01050",
        //"3V2SM01060",
        //"3V2SM80280",
        //"3V2SM80290",
        //"3V2SL80070",
        //"3V2SL80060",
        //"3V2SM80260",
        //"3V2SM80270",
        //"3V2SL01070",
        //"3V2SK01020",
        //"3V2SK80050",
        //"3V2TL01020",
        //"3V2TL80030",
        //"3V2SK01021",
        //"3V2TL01021",
        //"3V2SK01022",
        //"3V2TL01022",
        //"3V2TL01023",
        //"3V2SK01023",
        //"3V2SK01030",
        //"3V2SK80060",
        //"3V2SL01050",
        //"3V2SL01060",
        //"3V2SL80060",
        //"3V2SL80070",
        //"3V2SM01030",
        //"3V2SM01040",
        //"3V2SM80260",
        //"3V2SM80270",
        //"3V2TL01030",
        //"3V2TL80040",
        //"3V2SK01050",
        //"3V2SK80070",
        //"3V2SL01070",
        //"3V2TL01050",
        //"3V2TL80050",
        //"3V2TY01010",
        //"3V2TZ01010",
        //"3V2TZ01020",
        //"3V2TY80010",
        //"3V2TZ80010",
        //"3V2TZ80020",
        //"3V2TY01011",
        //"3V2TZ01011",
        //"3V2TZ01021",
        //"3V2TY01012",
        //"3V2TZ01012",
        //"3V2TY01013",
        //"3V2TZ01013",
        //"3V2TZ01022",
        //"3V2TY01014",
        //"3V2TZ01014",
        //"3V2TZ01023",
        //"3V2TV01010",
        //"3V2TW01010",
        //"3V2TX01010",
        //"3V2TW01040",
        //"3V2TX01040",
        //"3V2TX01050",
        //"3V2TV01060",
        //"3V2TV80030",
        //"3V2TW80020",
        //"3V2TX80010",
        //"3V2TV80040",
        //"3V2TW80030",
        //"3V2TX80020",
        //"3V2TV01011",
        //"3V2TV01061",
        //"3V2TW01011",
        //"3V2TW01041",
        //"3V2TX01011",
        //"3V2TX01041",
        //"3V2TW01012",
        //"3V2TW01042",
        //"3V2TX01012",
        //"3V2TX01042",
        //"3V2TX01051",
        //"3V2TV01012",
        //"3V2TV01062",
        //"3V2TV01013",
        //"3V2TV01063",
        //"3V2TW01013",
        //"3V2TW01043",
        //"3V2TX01013",
        //"3V2TX01043",
        //"3V2V001010",
        //"3V2V101010",
        //"3V2VW01010",
        //"3V2V080030",
        //"3V2V180020",
        //"3V2VW80020",
        //"3V2V001011",
        //"3V2V101011",
        //"3V2VW01011",
        //"3V2V001012",
        //"3V2V101012",
        //"3V2VW01012",
        //"3V2ZL01010",
        //"3V2ZL80010",
        //"3V2V001013",
        //"3V2V101013",
        //"3V2ZL01011",
        //"3V2V001014",
        //"3V2V101014",
        //"3V2ZL01012",
        //"3V2XA80050",
        //"3V2XA01010",
        //"3V2V001030",
        //"3V2V080040",
        //"3V2V101030",
        //"3V2V180040",
        //"3V2VW80030",
        //"3V2ZL01020",
        //"3V2ZL80020",
        //"3V2NM01019",
        //"3V2NX01018",
        //"3V2NY01018",
        //"3V2NZ01012",
        //"3V2P001012",
        //"3V2NM80052",
        //"3V2NM80132",
        //"3V2NM80142",
        //"3V2NM80152",
        //"3V2NM80161",
        //"3V2NX80031",
        //"3V2NX80041",
        //"3V2NX80051",
        //"3V2NX80061",
        //"3V2NY80021",
        //"3V2NY80031",
        //"3V2NZ80020",
        //"3V2NZ80040",
        //"3V2NZ80050",
        //"3V2NZ80060",
        //"3V2P080020",
        //"3V2P080040",
        //"3V2P080050",
        //"3V2P680022",
        //"3V2P680052",
        //"3V2P680062",
        //"3V2P680071",
        //"3V2NM0101A",
        //"3V2P001013",
        //"3V2TA01010",
        //"3V2TB01010",
        //"3V2TF01020",
        //"3V2TG01010",
        //"3V2V201010",
        //"3V2V301010",
        //"3V2TA80050",
        //"3V2TB80010",
        //"3V2TF80020",
        //"3V2TG80030",
        //"3V2V280010",
        //"3V2V380020",
        //"3V2TA01012",
        //"3V2TB01012",
        //"3V2TF01022",
        //"3V2TG01012",
        //"3V2TG01030",
        //"3V2TG80040",
        //"3V2V201012",
        //"3V2V301012",
        //"3V2TA01011",
        //"3V2TB01011",
        //"3V2TF01021",
        //"3V2TG01011",
        //"3V2V201011",
        //"3V2V301011",
        //"3V2TF01023",
        //"3V2TG01013",
        //"3V2TA01013",
        //"3V2TB01013",
        //"3V2TF01024",
        //"3V2TG01014",
        //"3V2TG01031",
        //"3V2V201013",
        //"3V2V301013",
        //"3V2TA01014",
        //"3V2TB01014",
        //"3V2TF01025",
        //"3V2TG01015",
        //"3V2TG01032",
        //"3V2V201014",
        //"3V2V301014",
        //"3V2TA01015",
        //"3V2TB01015",
        //"3V2TF01026",
        //"3V2TG01016",
        //"3V2TG01033",
        //"3V2V201015",
        //"3V2V301015",
        //"3V2TA01016",
        //"3V2TB01016",
        //"3V2TF01027",
        //"3V2TG01017",
        //"3V2V201016",
        //"3V2V301016",
        //"3V2TB01017",
        //"3V2TB01020",
        //"3V2TB80020",
        //"3V2TB01030",
        //"3V2TF01030",
        //"3V2TG01040",
        //"3V2V201020",
        //"3V2V301040",
        //"3V2TB01040",
        //"3V2V201030",
        //"3V2V301050",
        //"3V2TA01017",
        //"3V2TB01018",
        //"3V2TB01031",
        //"3V2TB01041",
        //"3V2TB01051",
        //"3V2V201017",
        //"3V2V201021",
        //"3V2V201031",
        //"3V2V201041",
        //"3V2V301017",
        //"3V2V301041",
        //"3V2V301051",
        //"3V2V301061",
        //"3V2TB01050",
        //"3V2V201040",
        //"3V2TB01060",
        //"3V2TG01050",
        //"3VC0V01010",
        //"3VC0Z01010",
        //"3VC1001010",
        //"3VC1201010",
        //"3VC1301010",
        //"3VC1101010",
        //"3VC0V80040",
        //"3VC0Z80010",
        //"3VC1080020",
        //"3VC1180010",
        //"3VC1280020",
        //"3VC1380020",
        //"3V2YB0101B",
        //"3V2YB0102B",
        //"3V2YC0101B",
        //"3V2YC0102B",
        //"3V2YD0101B",
        //"3V2YD0102B",
        //"3V2YF01018",
        //"3V2M301012",
        //"3V2M301032",
        //"3V2M380081",
        //"3V2M380091",
        //"3V2M380101",
        //"3V2M380121",
        //"3V2M380131",
        //"3V2M380141",
        //"3VC0T80070",
        //"3VC0T01070",
        //"3V2YB0101B",
        //"3V2YB0102B",
        //"3V2YC0101B",
        //"3V2YC0102B",
        //"3V2YD0101B",
        //"3V2YD0102B",
        //"3V2YF01018"
        //        };
        public static IEnumerable<MsgEnity> GetMsgErr(string boardNo, string mac = "")
        {
            MsgEnity entity = new MsgEnity();
            var exists = SingletonHelper.ERPInstance.KyoGetBoard(boardNo);
            if (exists != null)
            {
                var date = (DateTime)exists.DateCheck;
                entity.msg = $"[{boardNo}] đã được bắn ngày [{date.ToString("yyyy-MM-dd")} {exists.TimeCheck}].\nVui lòng kiểm tra và thông tin lại với Leader!";
                entity.Type = MessageMode.LOCK;
               yield return entity;
            }
            var orderNo = SingletonHelper.ERPInstance.KyoGetInit(boardNo);
            if (orderNo == null)
            {
                entity.msg = "Không có dữ liệu in barcode";
                entity.Type = MessageMode.ERR;
                yield return entity;
            }
            if (UsapHelper.OrderNo != orderNo)
            {
                entity.msg = "Sai WO";
                entity.Type = MessageMode.ERR;
                yield return entity;
            }
            var boxInfo = SingletonHelper.ERPInstance.KyoGetMac(UsapHelper.BoxID);
            if (boxInfo != null && boxInfo.Count() >= Convert.ToInt32(UsapHelper.BoxQty))
            {
                entity.msg = $"Thùng [{UsapHelper.BoxID}] đã đầy. Vui lòng lấy thùng khác!";
                entity.Type = MessageMode.ERR;
                yield return entity;
            }
            if (UsapHelper.CheckMac)
            {
                var fctExit = SingletonHelper.ERPInstance.KyoTestLogFind(boardNo);
                if (fctExit.Count() == 0)
                {
                    entity.msg = $"[{boardNo}] không có dữ liệu FCT!";
                    entity.Type = MessageMode.LOCK;
                    yield return entity;
                }
                if (!string.IsNullOrEmpty(mac) && fctExit.FirstOrDefault().MAC_ADDRESS != mac)
                {
                    entity.msg = $"Sai Mac!";
                    entity.Type = MessageMode.LOCK;
                    yield return entity;
                }
            }
            if (UmesHelper.IsWip)
            {
                if (UmesHelper.Item == null)
                {
                    entity.msg = $"Board [{UmesHelper.Item.BOARD_NO}] chưa được khởi tạo trên 'MES'.\nVui lòng kiểm tra và thông tin lại với Leader!";
                    entity.Type = MessageMode.ERR;
                    yield return entity;
                }
                if (UmesHelper.Item.PRODUCT_ID != UsapHelper.Model)
                {
                    entity.msg = $"Sai Model!\n[{UmesHelper.Item.PRODUCT_ID}]#[{UsapHelper.Model}]";
                    entity.Type = MessageMode.ERR;
                    yield return entity;
                }
                if (UmesHelper.Procedure == null)
                {
                    entity.msg = $"Order [{UmesHelper.Item.ORDER_NO}] không tồn tại trạm [VI2_KYD]";
                    entity.Type = MessageMode.ERR;
                    yield return entity;
                }
                if (UmesHelper.Item.BOARD_STATE == 3)
                {
                    entity.msg = $"Mạch [{UmesHelper.Item.BOARD_NO}] đã được khai báo hủy!";
                    entity.Type = MessageMode.ERR;
                    yield return entity;
                }
                if (UmesHelper.Item.IS_FINISHED)
                {
                    entity.msg = $"Mạch [{UmesHelper.Item.BOARD_NO}] đã finish!";
                    entity.Type = MessageMode.ERR;
                    yield return entity;
                }
                if (UmesHelper.Item.PROCEDURE_INDEX < UmesHelper.Procedure.INDEX - 1)
                {
                    entity.msg = $"Mạch [{UmesHelper.Item.BOARD_NO}] đang tại trạm [{UmesHelper.Item.STATION_NO}]";
                    entity.Type = MessageMode.ERR;
                    yield return entity;
                }
                if (UmesHelper.Item.PROCEDURE_INDEX == UmesHelper.Procedure.INDEX - 1 && UmesHelper.Item.BOARD_STATE != 1)
                {
                    entity.msg = $"Mạch [{UmesHelper.Item.BOARD_NO}] đang NG tại [{UmesHelper.Item.STATION_NO}]";
                    entity.Type = MessageMode.ERR;
                    yield return entity;
                }
                if (SingletonHelper.ERPInstance.NGDataExist(UmesHelper.Item.BOARD_NO) && !SingletonHelper.PVSInstance.CheckRepair(UmesHelper.Item.BOARD_NO))
                {
                    entity.msg = $"Bản mạch chưa được khai báo lỗi trên hệ thống WIP!";
                    entity.Type = MessageMode.ERR;
                    yield return entity;
                }
            }
            else
            {
                if (UmesHelper.RuleItem == null)
                {
                    entity.msg = "Rule chưa được tạo trên WIP!";
                    entity.Type = MessageMode.ERR;
                    yield return entity;
                }
                if (UmesHelper.RuleItem.LENGTH != boardNo.Length)
                {
                    entity.msg = $"Độ dài barcode không đúng [{UmesHelper.RuleItem.LENGTH}] ký tự.\nVui lòng kiểm tra và bắn lại!";
                    entity.Type = MessageMode.ERR;
                    yield return entity;
                }
                string key = boardNo.Substring(Convert.ToInt32(UmesHelper.RuleItem.INDEX) - 1, Convert.ToInt32(UmesHelper.RuleItem.CONTENT_LENGTH));
                if (key != UmesHelper.RuleItem.CONTENT)
                {
                    entity.msg = $"Sai Model [{UmesHelper.RuleItem.CONTENT}] # [{key}]\nVui lòng kiểm tra rule trên WIP !";
                    entity.Type = MessageMode.ERR;
                    yield return entity;
                }
            }
            //var linkErr = UmesHelper.GetLinkErr(boardNo);
            //if (!string.IsNullOrEmpty(linkErr))
            //{
            //    entity.msg = linkErr;
            //    entity.Type = MessageMode.ERR;
            //    yield return entity;
            //}
            yield break;
        }
    }
    public class MsgEnity
    {
        public string msg { get; set; }
        public MessageMode Type { get; set; } = MessageMode.NONE;
    }
}
