using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Modle
{
    public class OneRunModel
    {
        //a 集合Set ,纯粹的数据集合
        //b 线性结构 ： 一对一的 数组
        //c 树型结构 ：一对多的， 菜单/文件夹/类别/树型控件/表达式目录树
        //d 图状结构（网状） ： 多对多 ，地图/拓扑秃/快递


        //线性结构  1对1
        // 1 内存的连续存储  （数组） 压缩空间 访问速度快  （删除数据会影响性能,会导致存储空间移动）
        public static void OneRun() 
        {
            //数组  内存连续存储
            int[] vs = new int[3]; //限制长度  
            ArrayList arrayList = new ArrayList(); //不限制长度  obj类型
            List<int> vs1 = new List<int>();
        }

        //线性结构 不连续摆放
        public static void TwoRun()
        {
            {
                //不连续摆放 存储数据+地址 ，找数据只能顺序查找  查找慢 读取慢 （next（） move（））  链表
                LinkedList<int> ts = new System.Collections.Generic.LinkedList<int>();
            }
            {
                //队列 先进先出
                Queue<string> vs = new Queue<string>();
            }

            //栈
            {
                //先进后出
                Stack<int> vs = new Stack<int>();
            }
        }
    }
}
