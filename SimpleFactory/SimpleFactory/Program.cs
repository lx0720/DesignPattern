using System;

namespace SimpleFactory_DP
{
    ///简单工厂提供一个便利的方法创建所需的对象，
    ///而不需要了解这些对象是如何创建的

    ///优点 : 
    ///1.结构简单，易于理解
    ///2.削弱了对具体产品类的一个依赖，有利于整个软件体系结构的优化
    ///缺点 :
    ///1.高内聚 不好
    ///2.不符合开闭原则

    public class SimpleFactoryCommodity { }
    public class Door : SimpleFactoryCommodity { }
    public class Table : SimpleFactoryCommodity { }

    public class SimpleAbstractFactory
    {
        public static SimpleFactoryCommodity GetSimpleFactoryCommodity(string simpleFactoryCommodityName)
        {
            if (simpleFactoryCommodityName == "Door")
                return new Door();
            if (simpleFactoryCommodityName == " Table")
                return new Table();
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SimpleFactoryCommodity simpleCommodity = SimpleAbstractFactory.GetSimpleFactoryCommodity("Door");

        }
    }
}
