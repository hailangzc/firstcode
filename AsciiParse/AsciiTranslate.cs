
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace AsciiParse
{
    public  class AsciiTranslate
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ascii_value"></param>
        /// <returns></returns>
        public static String GetAsciiParseValue(String ascii_value)
        {
            //1B41294720403640523246405233304037323031353037333140322020202041424344454647484A40390D
            if (ascii_value == null || ascii_value.Length == 0)
            {
                Log.SetLogMessage("返回：1001，接受参数为空");
                return JsonConvert.SerializeObject(new {code = 1001,retMsg = "接受参数为空" });
            }

            ascii_value = ascii_value.Replace(" ", "");

            if (!ascii_value.StartsWith("1B41"))
            {
                Log.SetLogMessage("返回：1010，ascii值不是以1B41开头，具体值：" + ascii_value);
                return JsonConvert.SerializeObject(new { code = 1001, retMsg = "ascii值不是以1B41开头" });
            }
               

            if (!ascii_value.EndsWith("0D"))
            {
                Log.SetLogMessage("返回：1011，ascii值不是以0D结尾，具体值：" + ascii_value);
                return JsonConvert.SerializeObject(new { code = 1011, retMsg = "ascii值不是以0D结尾" });
            }
               

            if (ascii_value.Length % 2 != 0)
            {
                Log.SetLogMessage("返回1002，ascii值不规范，非偶数，具体值：" + ascii_value);
                return JsonConvert.SerializeObject(new { code = 1002, retMsg = "ascii值不规范，非偶数" });
            }
               

            String ascii3 = ascii_value.Substring(4, 2);//第三个字节值

            if (ascii3 != "29" && ascii3 != "2C" && ascii3 != "6C" && ascii3 != "69")
            {
                Log.SetLogMessage("返回1012，ascii值第三个字节值不准确，具体值：" + ascii_value);
                return JsonConvert.SerializeObject(new { code = 1012, retMsg = "ascii值第三个字节值不准确" });
            }
            
            String ascii6 = ascii_value.Substring(10, 2);//第6个字节值
            String ascii7 = ascii_value.Substring(12, 2);//第7个字节值
            if (ascii6 != "40" && (ascii7 != "36" || ascii6 != "37"))
            {
                Log.SetLogMessage("返回1013，ascii值第6或7个字节值不准确(非40，36或37)，具体值：" + ascii_value);
                return JsonConvert.SerializeObject(new { code = 1013, retMsg = "第6或7个字节值不准确(非40，36或37)" });
            }
            
            String l_ascii_2 = ascii_value.Substring(ascii_value.Length - 6, 2);
            String l_ascii_3 = ascii_value.Substring(ascii_value.Length - 4, 2);

            if (l_ascii_2 != "40" || l_ascii_3 != "39")
            {
                Log.SetLogMessage("返回1014，倒数第二、三字节值不是以40、39结尾，具体值：" + ascii_value);
                return JsonConvert.SerializeObject(new { code = 1014, retMsg = "倒数第二、三字节值不是以40、39结尾" });
            }
            
            String ascii4 = ascii_value.Substring(6, 2);//第四个字节值
            int ret = chkAsciiCount(ascii4, ascii_value);
            if (ret != 0)
            {
                Log.SetLogMessage("返回1015，字节数和提供的数据不匹配，具体值：" + ascii_value);
                return JsonConvert.SerializeObject(new { code = 1015, retMsg = "字节数和提供的数据不匹配" });
            }

            String parseAsciiVal = convertAsciiVal(ascii_value);//解析后的字符,如：@6@R2F@R30@720150731@2    ABCDEFGHJ

            String endVal = parseVal(parseAsciiVal);
            if (endVal == "-1")
            {
                Log.SetLogMessage("返回1016，解析失败，解析值：" + parseAsciiVal);
                return JsonConvert.SerializeObject(new { code = 1016, retMsg = "解析失败" });
            }

            return JsonConvert.SerializeObject(new {code = 1000, retMsg = endVal });
        }


        #region 校验字节数是否相等
        /// <summary>
        /// 校验字节数是否相等
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static int chkAsciiCount(String val, String ascii_value)
        {
            try
            {
               int count = Int32.Parse(val, System.Globalization.NumberStyles.HexNumber) - 31;

                if ((count * 2) == (ascii_value.Length - 6))
                    return  0;
                return -2;
            }
           catch
            {
                return -1;
            }
        }
        #endregion

        #region 将16进制字符串转换成字符串
        /// <summary>
        /// 将16进制字符串转换成字符串
        /// </summary>
        /// <returns></returns>
        private static String convertAsciiVal(String ascii_value)
        {
            int len = ascii_value.Length-16;
            string parseAscii = ascii_value.Substring(10, len);
          
            // 声明一个byte数组，大小为 16进制字符串 长度的一半，因为16进制数据都是两个一组
            byte[] buf1 = new byte[parseAscii.Length / 2];

            for (int i = 0; i < parseAscii.Length; i += 2)
                buf1[i / 2] = Convert.ToByte(parseAscii.Substring(i, 2), 16);  // 将 16进制字符串 中的每两个字符转换成 byte，并加入到新申请的 byte数组 中
            return Encoding.Default.GetString(buf1); // 将 byte数组 解码成 字符串：

        }

        #endregion

        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        private static Dictionary<String,String> initCode()
        {
            Dictionary<String, String> param = new Dictionary<String, String>(); ;
            param.Add("00", "杭");param.Add("10", "波");param.Add("20", "市");param.Add("30", "溪");param.Add("40", "初");param.Add("50", "清");
            param.Add("01", "州");param.Add("11", "江");param.Add("21", "柯");param.Add("31", "武");param.Add("41", "昊");param.Add("51", "流");
            param.Add("02", "绍");param.Add("12", "东");param.Add("22", "桥");param.Add("32", "磐");param.Add("42", "晨");param.Add("52", "明");
            param.Add("03", "兴");param.Add("13", "南");param.Add("23", "区");param.Add("33", "浦");param.Add("43", "县");param.Add("53", "三");
            param.Add("04", "金");param.Add("14", "西");param.Add("24", "上");param.Add("34", "缙");param.Add("44", "徽");param.Add("54", "沙");
            param.Add("05", "华");param.Add("15", "北");param.Add("25", "虞");param.Add("35", "云");param.Add("45", "祁");param.Add("55", "连");
            param.Add("06", "丽");param.Add("16", "城");param.Add("26", "嵊");param.Add("36", "松");param.Add("46", "门");param.Add("56", "长");
            param.Add("07", "水");param.Add("17", "富");param.Add("27", "新");param.Add("37", "遂");param.Add("47", "洋");param.Add("57", "汀");
            param.Add("08", "衢");param.Add("18", "阳");param.Add("28", "昌");param.Add("38", "和");param.Add("48", "锐");param.Add("58", "石");
            param.Add("09", "黄");param.Add("19", "桐");param.Add("29", "诸");param.Add("39", "龙");param.Add("49", "太");param.Add("59", "瑞");
            param.Add("0A", "山");param.Add("1A", "庐");param.Add("2A", "暨");param.Add("3A", "泉");param.Add("4A", "平");param.Add("5A", "都");
            param.Add("0B", "福");param.Add("1B", "萧");param.Add("2B", "永");param.Add("3B", "景");param.Add("4B", "闽");param.Add("5B", "于");
            param.Add("0C", "建");param.Add("1C", "临");param.Add("2C", "康");param.Add("3C", "庆");param.Add("4C", "泰");param.Add("5C", "广");
            param.Add("0D", "温");param.Add("1D", "安");param.Add("2D", "义");param.Add("3D", "元");param.Add("4D", "胜");param.Add("5D", "李");
            param.Add("0E", "台");param.Add("1E", "淳");param.Add("2E", "乌");param.Add("3E", "青");param.Add("4E", "乐");param.Add("5E", "灿");
            param.Add("0F", "宁");param.Add("1F", "德");param.Add("2F", "兰");param.Add("3F", "田");param.Add("4F", "化");param.Add("5F", "光");

                                         
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
        #endregion

        /// <summary>
        /// 解析最终数据，将数返回
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String parseVal(String parseAsciiVal)
        {
            
            String[] strs = parseAsciiVal.Split('@');//@分隔符分开

            StringBuilder sb = new StringBuilder();

            Dictionary<String, String> param = initCode();
            String errorCode = "0";

            foreach (String s in strs)
            {
                if (s == "" || s == "6")//为空，16点阵，继续循环
                    continue;

                if (s.StartsWith("R") && s.Length > 3)
                {
                    sb.Append(param[s.Substring(1, 2)]);
                    sb.Append(s.Substring(3,s.Length-3));
                }
                else if (s.StartsWith("R") && s.Length == 3)
                    sb.Append(param[s.Substring(1, 2)]);
                else if (s.StartsWith("7") && s.Length >= 2)
                {
                    if(parseAsciiVal.Contains("@7"))//第一行数据
                        sb.Append(s.Substring(1, s.Length - 1));
                    else
                        sb.Append(s.Substring(0,s.Length - 1));
                }
                else if (s.StartsWith("2") && s.Length >= 2)//第二行数据
                {
                    if(parseAsciiVal.Contains("@2"))
                    {
                        sb.Append("\n");
                        sb.Append(s.Substring(1, s.Length - 1));
                    }
                    else
                        sb.Append(s.Substring(0, s.Length - 1));
                }
                else
                {
                    errorCode = "-2";
                    break;
                }
            }


            if (errorCode == "0")
                return sb.ToString();
            else
                return "-1";


        }
    }
}
