﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolForDan
{
    public class Consts
    {
        public static string WrapSymbol = "\r\n";
        public static string url = "http://shou.1771.com/shipmentorder/init.action";
        public static string para1 = "orderDemandBean.currentNo=0&orderDemandBean.pageSize=10&selectedGameBean.gameId=G10&selectedGameBean.groupid=G10P001&selectedGameBean.serverId={0}&selectedGameBean.serverName=%E5%AE%89%E5%BE%BD2%E5%8C%BA&selectedGameBean.camp=&selectedGameBean.goodstypeid=&orderDemandBean.orderColumn=unitprice+desc&orderDemandBean.searchtype=&orderDemandBean.gameid=G10&orderDemandBean.keyvalue=";
        public static string para2 = "orderDemandBean.currentNo=0&orderDemandBean.pageSize=10&selectedGameBean.gameId=G10&selectedGameBean.groupid=G10P002&selectedGameBean.serverId={0}&selectedGameBean.serverName=%E5%AE%89%E5%BE%BD2%E5%8C%BA&selectedGameBean.camp=&selectedGameBean.goodstypeid=&orderDemandBean.orderColumn=unitprice+desc&orderDemandBean.searchtype=&orderDemandBean.gameid=G10&orderDemandBean.keyvalue=";

        public static List<GameArea> LstServer = new List<GameArea>() 
        {
            #region 服务器
		    new GameArea() {ID=1 ,Code="G10P001059",Name="安徽1区"},
            new GameArea() {ID=2 ,Code="G10P001060",Name="安徽2区"},
            new GameArea() {ID=3 ,Code="G10P001061",Name="安徽3区"},
            new GameArea() {ID=4 ,Code="G10P001030",Name="福建1区"},
            new GameArea() {ID=5 ,Code="G10P001031",Name="福建2区"},
            new GameArea() {ID=6 ,Code="G10P001072",Name="福建3/4区"},
            new GameArea() {ID=7 ,Code="G10P001028",Name="广东10区"},
            new GameArea() {ID=8 ,Code="G10P001029",Name="广东11区"},
            new GameArea() {ID=9 ,Code="G10P001083",Name="广东12区"},
            new GameArea() {ID=10,Code="G10P001091",Name="广东13区"},
            new GameArea() {ID=11,Code="G10P001019",Name="广东1区"},
            new GameArea() {ID=12,Code="G10P001020",Name="广东2区"},
            new GameArea() {ID=13,Code="G10P001021",Name="广东3区"},
            new GameArea() {ID=14,Code="G10P001022",Name="广东4区"},
            new GameArea() {ID=15,Code="G10P001023",Name="广东5区"},
            new GameArea() {ID=16,Code="G10P001024",Name="广东6区"},
            new GameArea() {ID=17,Code="G10P001025",Name="广东7区"},
            new GameArea() {ID=18,Code="G10P001026",Name="广东8区"},
            new GameArea() {ID=19,Code="G10P001027",Name="广东9区"},
            new GameArea() {ID=20,Code="G10P001056",Name="广西1区"},
            new GameArea() {ID=21,Code="G10P001057",Name="广西2/4区"},
            new GameArea() {ID=22,Code="G10P001058",Name="广西3区"},
            new GameArea() {ID=23,Code="G10P001090",Name="广西5区"},
            new GameArea() {ID=24,Code="G10P001068",Name="广州1/2区"},
            new GameArea() {ID=25,Code="G10P001080",Name="贵州1区"},
            new GameArea() {ID=26,Code="G10P001013",Name="湖北1区"},
            new GameArea() {ID=27,Code="G10P001014",Name="湖北2区"},
            new GameArea() {ID=28,Code="G10P001015",Name="湖北3区"},
            new GameArea() {ID=29,Code="G10P001016",Name="湖北4区"},
            new GameArea() {ID=30,Code="G10P001017",Name="湖北5区"},
            new GameArea() {ID=31,Code="G10P001018",Name="湖北6区"},
            new GameArea() {ID=32,Code="G10P001074",Name="湖北7区"},
            new GameArea() {ID=33,Code="G10P001084",Name="湖北8区"},
            new GameArea() {ID=34,Code="G10P001042",Name="湖南1区"},
            new GameArea() {ID=35,Code="G10P001043",Name="湖南2区"},
            new GameArea() {ID=36,Code="G10P001044",Name="湖南3区"},
            new GameArea() {ID=37,Code="G10P001045",Name="湖南4区"},
            new GameArea() {ID=38,Code="G10P001046",Name="湖南5区"},
            new GameArea() {ID=39,Code="G10P001047",Name="湖南6区"},
            new GameArea() {ID=40,Code="G10P001076",Name="湖南7区"},
            new GameArea() {ID=41,Code="G10P001048",Name="江苏1区"},
            new GameArea() {ID=42,Code="G10P001049",Name="江苏2区"},
            new GameArea() {ID=43,Code="G10P001050",Name="江苏3区"},
            new GameArea() {ID=44,Code="G10P001051",Name="江苏4区"},
            new GameArea() {ID=45,Code="G10P001054",Name="江苏5/7区"},
            new GameArea() {ID=46,Code="G10P001053",Name="江苏6区"},
            new GameArea() {ID=47,Code="G10P001055",Name="江苏8区"},
            new GameArea() {ID=48,Code="G10P001062",Name="江西1区"},
            new GameArea() {ID=49,Code="G10P001063",Name="江西2区"},
            new GameArea() {ID=50,Code="G10P001064",Name="江西3区"},
            new GameArea() {ID=51,Code="G10P001065",Name="陕西1区"},
            new GameArea() {ID=52,Code="G10P001077",Name="陕西2/3区"},
            new GameArea() {ID=53,Code="G10P001038",Name="上海1区"},
            new GameArea() {ID=54,Code="G10P001039",Name="上海2区"},
            new GameArea() {ID=55,Code="G10P001040",Name="上海3区"},
            new GameArea() {ID=56,Code="G10P001073",Name="上海4/5区"},
            new GameArea() {ID=57,Code="G10P001007",Name="四川1区"},
            new GameArea() {ID=58,Code="G10P001008",Name="四川2区"},
            new GameArea() {ID=59,Code="G10P001009",Name="四川3区"},
            new GameArea() {ID=60,Code="G10P001010",Name="四川4区"},
            new GameArea() {ID=61,Code="G10P001011",Name="四川5区"},
            new GameArea() {ID=62,Code="G10P001012",Name="四川6区"},
            new GameArea() {ID=63,Code="G10P001001",Name="西北1区"},
            new GameArea() {ID=64,Code="G10P001003",Name="西北2/3区"},
            new GameArea() {ID=65,Code="G10P001004",Name="西南1区"},
            new GameArea() {ID=66,Code="G10P001005",Name="西南2区"},
            new GameArea() {ID=67,Code="G10P001006",Name="西南3区"},
            new GameArea() {ID=68,Code="G10P001082",Name="新疆1区"},
            new GameArea() {ID=69,Code="G10P001081",Name="云贵1区"},
            new GameArea() {ID=70,Code="G10P001079",Name="云南1区"},
            new GameArea() {ID=71,Code="G10P001033",Name="浙江1区"},
            new GameArea() {ID=72,Code="G10P001034",Name="浙江2区"},
            new GameArea() {ID=73,Code="G10P001035",Name="浙江3区"},
            new GameArea() {ID=74,Code="G10P001037",Name="浙江4/5区"},
            new GameArea() {ID=75,Code="G10P001075",Name="浙江6区"},
            new GameArea() {ID=76,Code="G10P001085",Name="浙江7区"},
            new GameArea() {ID=77,Code="G10P001069",Name="重庆1区"},
            new GameArea() {ID=78,Code="G10P001070",Name="重庆2区"},
            new GameArea() {ID=79,Code="G10P002027",Name="北京1区"},
            new GameArea() {ID=80,Code="G10P002045",Name="北京2/4区"},
            new GameArea() {ID=81,Code="G10P002029",Name="北京3区"},
            new GameArea() {ID=82,Code="G10P002023",Name="东北1区"},
            new GameArea() {ID=83,Code="G10P002024",Name="东北2区"},
            new GameArea() {ID=84,Code="G10P002044",Name="东北3/7区"},
            new GameArea() {ID=85,Code="G10P002016",Name="东北4/5/6区"},
            new GameArea() {ID=86,Code="G10P002008",Name="河北1区"},
            new GameArea() {ID=87,Code="G10P002038",Name="河北2/3区"},
            new GameArea() {ID=88,Code="G10P002041",Name="河北4区"},
            new GameArea() {ID=89,Code="G10P002047",Name="河北5区"},
            new GameArea() {ID=90,Code="G10P002035",Name="河南1区"},
            new GameArea() {ID=91,Code="G10P002036",Name="河南2区"},
            new GameArea() {ID=92,Code="G10P002001",Name="河南3区"},
            new GameArea() {ID=93,Code="G10P002002",Name="河南4区"},
            new GameArea() {ID=94,Code="G10P002003",Name="河南5区"},
            new GameArea() {ID=95,Code="G10P002037",Name="河南6区"},
            new GameArea() {ID=96,Code="G10P002050",Name="河南7区"},
            new GameArea() {ID=97,Code="G10P002010",Name="黑龙江1区"},
            new GameArea() {ID=98,Code="G10P002049",Name="黑龙江2/3区"},
            new GameArea() {ID=99,Code="G10P002020",Name="华北1区"},
            new GameArea() {ID=100,Code="G10P002021",Name="华北2区"},
            new GameArea() {ID=101,Code="G10P002022",Name="华北3区"},
            new GameArea() {ID=102,Code="G10P002015",Name="华北4区"},
            new GameArea() {ID=103,Code="G10P002012",Name="吉林1/2区"},
            new GameArea() {ID=104,Code="G10P002004",Name="辽宁1区"},
            new GameArea() {ID=105,Code="G10P002005",Name="辽宁2区"},
            new GameArea() {ID=106,Code="G10P002006",Name="辽宁3区"},
            new GameArea() {ID=107,Code="G10P002043",Name="内蒙古1区"},
            new GameArea() {ID=108,Code="G10P002030",Name="山东1区"},
            new GameArea() {ID=109,Code="G10P002046",Name="山东2/7区"},
            new GameArea() {ID=110,Code="G10P002032",Name="山东3区"},
            new GameArea() {ID=111,Code="G10P002033",Name="山东4区"},
            new GameArea() {ID=112,Code="G10P002034",Name="山东5区"},
            new GameArea() {ID=113,Code="G10P002019",Name="山东6区"},
            new GameArea() {ID=114,Code="G10P002007",Name="山西1区"},
            new GameArea() {ID=115,Code="G10P002017",Name="山西2区"},
            new GameArea() {ID=116,Code="G10P002042",Name="天津1区"}
	        #endregion
        };
    }
}
