using AsciiParse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            //Console.WriteLine(sb.ToString());

            //String s = AsciiTranslate.GetAsciiParseValue("1B41294720403640523246405233304037323031353037333140322020202041424344454647484A40390D");
              String s = AsciiTranslate.parseVal("77720150731@6@R2F@R30@2ABCDEFGHJ");
            //dynamic o = JsonConvert.DeserializeObject<dynamic>(s);
            //var  b = o["retMsg"];
            Console.WriteLine(s);

            Console.ReadLine();
        }

        private static Dictionary<String, String> initCode()
        {
            Dictionary<String, String> param = new Dictionary<String, String>(); ;

            param.Add("00", "杭"); param.Add("10", "波"); param.Add("20", "市"); param.Add("30", "溪"); param.Add("40", "初"); param.Add("50", "清");
            param.Add("01", "州"); param.Add("11", "江"); param.Add("21", "柯"); param.Add("31", "武"); param.Add("41", "昊"); param.Add("51", "流");
            param.Add("02", "绍"); param.Add("12", "东"); param.Add("22", "桥"); param.Add("32", "磐"); param.Add("42", "晨"); param.Add("52", "明");
            param.Add("03", "兴"); param.Add("13", "南"); param.Add("23", "区"); param.Add("33", "浦"); param.Add("43", "县"); param.Add("53", "三");
            param.Add("04", "金"); param.Add("14", "西"); param.Add("24", "上"); param.Add("34", "缙"); param.Add("44", "徽"); param.Add("54", "沙");
            param.Add("05", "华"); param.Add("15", "北"); param.Add("25", "虞"); param.Add("35", "云"); param.Add("45", "祁"); param.Add("55", "连");
            param.Add("06", "丽"); param.Add("16", "城"); param.Add("26", "嵊"); param.Add("36", "松"); param.Add("46", "门"); param.Add("56", "长");
            param.Add("07", "水"); param.Add("17", "富"); param.Add("27", "新"); param.Add("37", "遂"); param.Add("47", "洋"); param.Add("57", "汀");
            param.Add("08", "衢"); param.Add("18", "阳"); param.Add("28", "昌"); param.Add("38", "和"); param.Add("48", "锐"); param.Add("58", "石");
            param.Add("09", "黄"); param.Add("19", "桐"); param.Add("29", "诸"); param.Add("39", "龙"); param.Add("49", "太"); param.Add("59", "瑞");
            param.Add("0A", "山"); param.Add("1A", "庐"); param.Add("2A", "暨"); param.Add("3A", "泉"); param.Add("4A", "平"); param.Add("5A", "都");
            param.Add("0B", "福"); param.Add("1B", "萧"); param.Add("2B", "永"); param.Add("3B", "景"); param.Add("4B", "闽"); param.Add("5B", "于");
            param.Add("0C", "建"); param.Add("1C", "临"); param.Add("2C", "康"); param.Add("3C", "庆"); param.Add("4C", "泰"); param.Add("5C", "广");
            param.Add("0D", "温"); param.Add("1D", "安"); param.Add("2D", "义"); param.Add("3D", "元"); param.Add("4D", "胜"); param.Add("5D", "李");
            param.Add("0E", "台"); param.Add("1E", "淳"); param.Add("2E", "乌"); param.Add("3E", "青"); param.Add("4E", "乐"); param.Add("5E", "灿");
            param.Add("0F", "宁"); param.Add("1F", "德"); param.Add("2F", "兰"); param.Add("3F", "田"); param.Add("4F", "化"); param.Add("5F", "光");


            param.Add("60", "泽"); param.Add("70", "成"); param.Add("80", "寿"); param.Add("90", "伦"); param.Add("A0", "银"); param.Add("B0", "达");
            param.Add("61", "顺"); param.Add("71", "苍"); param.Add("81", "老"); param.Add("91", "诚"); param.Add("A1", "观"); param.Add("B1", "双");
            param.Add("62", "丰"); param.Add("72", "仙"); param.Add("82", "虎"); param.Add("92", "辰"); param.Add("A2", "翔"); param.Add("B2", "鑫");
            param.Add("63", "祺"); param.Add("73", "居"); param.Add("83", "饶"); param.Add("93", "庚"); param.Add("A3", "振"); param.Add("B3", "畅");
            param.Add("64", "易"); param.Add("74", "岭"); param.Add("84", "筑"); param.Add("94", "国"); param.Add("A4", "合"); param.Add("B4", "腾");
            param.Add("65", "卓"); param.Add("75", "玉"); param.Add("85", "横"); param.Add("95", "纳"); param.Add("A5", "歌"); param.Add("B5", "鸿");
            param.Add("66", "彩"); param.Add("76", "环"); param.Add("86", "峰"); param.Add("96", "业"); param.Add("A6", "设"); param.Add("B6", "博");
            param.Add("67", "瓯"); param.Add("77", "天"); param.Add("87", "恊"); param.Add("97", "首"); param.Add("A7", "地"); param.Add("B7", "迪");
            param.Add("68", "政"); param.Add("78", "九"); param.Add("88", "栎"); param.Add("98", "亨"); param.Add("A8", "电"); param.Add("B8", "汇");
            param.Add("69", "凯"); param.Add("79", "盛"); param.Add("89", "运"); param.Add("99", "豪"); param.Add("A9", "扬"); param.Add("B9", "能");
            param.Add("6A", "欧"); param.Add("7A", "海"); param.Add("8A", "之"); param.Add("9A", "全"); param.Add("AA", "邦"); param.Add("BA", "旺");
            param.Add("6B", "常"); param.Add("7B", "远"); param.Add("8B", "衢"); param.Add("9B", "一"); param.Add("AB", "高"); param.Add("BB", "宇");
            param.Add("6C", "开"); param.Add("7C", "联"); param.Add("8C", "展"); param.Add("9C", "融"); param.Add("AC", "杰"); param.Add("BC", "旭");
            param.Add("6D", "游"); param.Add("7D", "慈"); param.Add("8D", "拓"); param.Add("9D", "四"); param.Add("AD", "锦"); param.Add("BD", "狮");
            param.Add("6E", "嘉"); param.Add("7E", "优"); param.Add("8E", "蕴"); param.Add("9E", "万"); param.Add("AE", "港"); param.Add("BE", "根");
            param.Add("6F", "文"); param.Add("7F", "奉"); param.Add("8F", "浙"); param.Add("9F", "亿"); param.Add("AF", "威"); param.Add("BF", "霞");


            param.Add("C0", "坚"); param.Add("D0", "潮"); param.Add("E0", "用"); param.Add("F0", "婺");
            param.Add("C1", "中"); param.Add("D1", "仑"); param.Add("E1", "瀚"); param.Add("F1", "店");
            param.Add("C2", "荣"); param.Add("D2", "湾"); param.Add("E2", "辉"); param.Add("F2", "利");
            param.Add("C3", "传"); param.Add("D3", "溢"); param.Add("E3", "戈"); param.Add("F3", "筱");
            param.Add("C4", "大"); param.Add("D4", "柘"); param.Add("E4", "霸"); param.Add("F4", "祥");
            param.Add("C5", "春"); param.Add("D5", "越"); param.Add("E5", "马"); param.Add("F5", "鸣");
            param.Add("C6", "强"); param.Add("D6", "翊"); param.Add("E6", "汉"); param.Add("F6", "屹");
            param.Add("C7", "吉"); param.Add("D7", "岩"); param.Add("E7", "立"); param.Add("F7", "六");
            param.Add("C8", "财"); param.Add("D8", "路"); param.Add("E8", "陆"); param.Add("F8", "欣");
            param.Add("C9", "弘"); param.Add("D9", "定"); param.Add("E9", "励"); param.Add("F9", "耀");
            param.Add("CA", "通"); param.Add("DA", "棱"); param.Add("EA", "晖"); param.Add("FA", "宜");
            param.Add("CB", "隆"); param.Add("DB", "信"); param.Add("EB", "协"); param.Add("FB", "民");
            param.Add("CC", "正"); param.Add("DC", "岱"); param.Add("EC", "方"); param.Add("FC", "铄");
            param.Add("CD", "裕"); param.Add("DD", "泗"); param.Add("ED", "权"); param.Add("FD", "澎");
            param.Add("CE", "恒"); param.Add("DE", "牛"); param.Add("EE", "承"); param.Add("FE", "益");
            param.Add("CF", "军"); param.Add("DF", "洞"); param.Add("EF", "堂"); param.Add("FF", "佳");

            return param;
        }
    }
}
