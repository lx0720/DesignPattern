using System;
using System.Collections.Generic;

namespace Observer_DP
{
    //在软件构建过程中，需要为某些对象建立一种一对多的“通知依赖关系”，
    //当一个对象的状态发生改变时，所有依赖它的对象都需要得到通知并被自动更新。
    //优点 :
    //1.使用面向对象，Observer模式使得我们可以独立地改变目标与观察者，从而使二者之间的依赖关系达到松耦合
    //2.当目标发送通知时，无须指定观察者，通知会自动传播。观察者自己决定是否需要订阅通知，目标对象对此一无所知。
    //缺点 :
    //1.松耦合导致代码间关系不明显，有时可能难以理解
    //2.如果一个Subject被大量的Observer订阅的话，在广播通知的时候可能有效率问题

    //1.抽象被观察者角色 : 被观察的对象
    public abstract class Subject
    {
        private List<Observer> observers = new List<Observer>();

        public void AddObserver(Observer observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach(Observer observer in observers)
            {
                observer.Update();
            }
        }
    }
    //2.抽象观察者角色 : 抽象的观察者
    public abstract class Observer
    {
        public abstract void Update();
    }

    //3.具体的被观察者
    public class Teacher : Subject
    {
        private string teacherState;

        public string GetTeacherState()
        {
            return teacherState;
        }

        public void SetTeacherState(string state)
        {
            teacherState = state;
        }
    }
    //4.具体观察者
    public class Student : Observer
    {
        private string name;
        private string observerState;
        private Teacher teacher;
        public Student(Teacher teacher,string name)
        {
            this.teacher = teacher;
            this.name = name;
        }
        public override void Update()
        {
            observerState = teacher.GetTeacherState();
            Console.WriteLine("观察者: "+name+" 新状态: "+observerState);
        }
        public Teacher GetTeacher()
        {
            return teacher;
        }
    }

    public class Test
    {
        static void Main()
        {
            Teacher teacher = new Teacher();
            teacher.AddObserver(new Student(teacher, "无语"));
            teacher.AddObserver(new Student(teacher, "生气"));
            teacher.SetTeacherState("开心");
            teacher.Notify();
        }
    }

}
