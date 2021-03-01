using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWinform.Model
{
    public class OneModelRun
    {
        //天龙八部 三条人物线
        //虚竹 ： 小和尚 逍遥掌门 令鹭宫宫主 西夏驸马
        //乔峰 ： 丐帮帮主  契丹人 南院大王 挂印离开
        //段誉 ： 钟灵儿 木碗清 王语嫣 大理国王

        /// <summary>
        /// 获取随机数字
        /// </summary>
        /// <returns></returns>
        public static int GetRandomInt(int minNumber , int maxIntNumber) 
        {
            //生成随机种子
            var seed = DateTime.Now.Millisecond;
            var guid = Guid.NewGuid().ToString();
            for (var i = 0; i < guid.Length; i++)
            {
                switch (guid[i])
                {
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                        seed += 10;
                        break;
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'k':
                    case 'l':
                    case 'm':
                    case 'n':
                        seed += 15;
                        break;
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                    case 't':
                        seed += 20;
                        break;
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        seed += 25;
                        break;
                }
            }

            Random random = new Random(seed);
            return random.Next(minNumber, maxIntNumber);
        }
    }
}
