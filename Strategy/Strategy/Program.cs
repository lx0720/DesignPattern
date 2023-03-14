﻿using System;
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

        public List<int> StrategyInterface(List<int> list)
        {
            return strategy.AlgorithmInterface(list);
           
        }
    }
    ///3.具体的策略角色

    ///冒牌排序 时间 n^2 空间 1 
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
    ///选择排序 时间 n^2 空间 1 
    public class SelectSortStrategy : Strategy
    {
        public override List<int> AlgorithmInterface(List<int> list)
        {
            for(int i=0;i<list.Count-1;i++)
            {
                int min = i;
                for(int j = i;j<list.Count;j++)
                {
                    if(list[min] > list[j])
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    list[i] = list[i] + list[min];
                    list[min] = list[i] - list[min];
                    list[i] = list[i] - list[min];
                }
            }
            return list;
        }
    }
    ///插入排序 时间 n^2 空间 1 
    public class InsertSortStrategy : Strategy
    {
        public override List<int> AlgorithmInterface(List<int> list)
        {
            for(int i=1;i<list.Count;i++)
            {
                int temp = list[i];
                for(int j=i-1;j>=0;j--)
                {
                    if(list[j] > temp)
                    {
                        list[j + 1] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
    }
    ///快速排序 时间 nlogn 空间 logn
    public class QuickSortStrategy : Strategy
    {
        public override List<int> AlgorithmInterface(List<int> list)
        {
            QuickSort(0, list.Count - 1, list);
            return list;
        }
        ///递归
        public void QuickSort(int l, int r, List<int> list)
        {
            if (l < r)
            {
                int mid = Sort(l, r, list);
                QuickSort(l, mid - 1, list);
                QuickSort(mid + 1, r, list);
            }
        }
        /// 实际排序的函数
        public int Sort(int l,int r,List<int> list)
        {
            int temp = list[l]; //基准

            while(l < r)
            {
                while (l < r && list[r] >= temp)
                    r--;   //右哨兵左移
                list[l] = list[r];
                while (l < r && list[l] <= temp)
                    l++;
                list[r] = list[l];
            }
            list[l] = temp;
            return l;
        }
    }
    ///Main函数
    public class Test
    {
        static void Main()
        {
            List<int> list = new List<int>() { 7, 2, 6, 1, 5, 9, 3, 4 ,8};
            StrategyContext strategyContext = new StrategyContext(new QuickSortStrategy()) ;
            List<int> list1 = strategyContext.StrategyInterface(list);
            foreach(var i in list1)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
    }
}
