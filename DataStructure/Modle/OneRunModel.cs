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


        //线性结构
        // 1(b) 内存连续存储 节约空间 可以索引访问 读取快 增删快 （可以坐标访问 读取快 -增删慢，长度不变） Array 在内存上连续分配的，而且元素类型都市一样的
        //   ArrayList 不定长的，连续分配的 元素没有类型限制 ，任何元素都是当成Object处理 如果是值类型，会有装箱拆箱操作 读取快-增删慢
        //   Array List 也是Array ，内存上都市连续摆放的 不定长的：泛型 保证数据安全 避免装箱拆箱 读取快-增删慢s
        //
        //  非连续拜访 ， 存储数据+地址，读取慢，增删快（找数据只能按顺序查找）
        

        // 2(a) set 纯粹的集合，数据丢进去  唯一性
        // 集合：hash 分布 元素间没有关系 动态增加容量  去重
        // 统计用户IP ：IP地址
        //
        //  排序的集合：去重 而且排序
        //  统计排名-每统计一个就丢进集合

      

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
                //链表
                //不连续摆放 存储数据+地址 ，找数据只能顺序查找  查找慢 读取慢 （next（） move（））  链表
                LinkedList<int> ts = new System.Collections.Generic.LinkedList<int>();
            }
            {
                //队列 先进先出 链表
                Queue<string> vs = new Queue<string>();
            }

            //栈
            { 
                //先进后出
                Stack<int> vs = new Stack<int>();
            }
        }


        public static void ThreeRun() 
        {
            IEnumerable<int> enumerable;

            //set 纯粹的集合，数据丢进去  唯一性
            //集合：hash 分布 元素间没有关系 动态增加容量  去重
            HashSet<int> s = new HashSet<int>();

            // 4 排序的集合：去重 而且排序
            //  统计排名-每统计一个就丢进集合
            SortedSet<int> vs = new SortedSet<int>(); 
        }


        // 3 读取 & 增删 都快？ 有hash 散列 字典
        //   Key-Value  一段连续空间放 value (开辟的空间比用的多，hash 是用空间换性能) 基于key散列计算得到地址索引 ，这样读取快
        //   增删也快，删除时也是计算位置 ，增加也不影响别人
        //   肯定会出现2个 key（散列冲突） 散列结构一致 可以让第二次+1
        //   可能会导致效率的降低，尤其时数据梁大的情况下
        //   hashtable key-value  体积可以动态添加 拿着key计算一个地址 ，然后放入 key - value

        public static void FourRun() 
        {

        }
    }
}
