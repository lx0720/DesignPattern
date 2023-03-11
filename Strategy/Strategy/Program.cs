using System;
using System.Collections.Generic;

namespace Strategy_DP
{
    ///定义 ：定义一系列的算法，并把他们一个一个封装起来，并且他们可以相互替代。
    ///优点 ：在运行时可以根据需要透明的更改对象的算法和将算法和对象本身解耦。
    
    ///1.抽象策略角色 ：定义所有支持的算法的公共接口
    public abstract class Strategy
    {
        public abstract List<int> AlgorithmInterface(List<int> list);
    }
    ///2.上下文环境角色 ：使用一个具体的策略类对象来完成初始化，同时维护一个对Strategy对象的引用。提供一个接口来让Strategy访问它的数据。
    public class StrategyContext
    {
        private Strategy strategy;

        public StrategyContext(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void StrategyInterface(List<int> list)
        {
            List<int> sortList = strategy.AlgorithmInterface(list);
            foreach(var i in sortList)
            {
                Console.Write(i);
            }
        }
    }
    ///3.具体的策略角色
    public class BubbleSortStrategy : Strategy
    {
        bool isOk;
        public override List<int> AlgorithmInterface(List<int> list)
        {
            for(int i=0;i<list.Count-1;i++)
            {
                isOk = true; 
                for(int j=0;j<list.Count-i-1;j++)
                {
                    if(list[j] > list[j+1])
                    {
                        list[j] = list[j] + list[j + 1];
                        list[j + 1] = list[j] - list[j + 1];
                        list[j] = list[j] - list[j + 1];
                        isOk = false;
                    }
                }
                if (isOk) break;
            }
            return list;
        }
    }
    ///Main函数
    public class Test
    {
        static void Main()
        {
            List<int> list = new List<int>() { 7, 2, 6, 1, 5, 9, 3, 4 ,8};
            StrategyContext strategyContext = new StrategyContext(new BubbleSortStrategy());
            strategyContext.StrategyInterface(list);
        }
    }
}
