using System;
namespace InterfaceDemo
{
    public interface IMath
    {
        public double Add(double i, double j);
        public double Substract(double i, double j);
        public double Multiply(double i, double j, double k);
        public double Divide(double i, double j);  
    }
    public class Math : IMath
    {
        public double Add(double a, double b) 
        { 
            return a + b; 
        }
        public double Substract(double a, double b) 
        { 
            if(a>b)
                return a - b; 
            else
                return b - a;
        }
        public double Multiply(double a, double b, double c) 
        { 
            return a * b * c; 
        }
        public double Divide(double a, double b) 
        { 
            return a / b; 
        }
    }
    public interface ICalculator
    {
        public double Interest(double principal, double time, double rate);
    }
    public class SimpleInterest : ICalculator
    {
        public IMath math;
        public SimpleInterest (IMath _IMath)
        {
            math = _IMath;
        }
        public double Interest(double principal, double time, double rate)
        {
            return  math.Multiply(principal,time,rate)/100;
        }
    }
    public class CompoundInterest : ICalculator
    {
        public IMath math;
        public CompoundInterest(IMath _IMath)
        {
            math = _IMath;
        }
        public double Interest(double principal, double time, double rate)
        {
            Console.WriteLine("Enter the number of times interest need to be compounded");
            double n= Convert.ToDouble(Console.ReadLine());
            double amount = principal;
            for(int i = 0; i < (n*time); i++)
            {
                amount = amount + amount * ( rate /(n* 100));
            }
            return amount - principal;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            IMath mathobj = new Math();
            Console.WriteLine("Enter the Principal Amount");
            double p= Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the Interest Rate");
            double r = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the number of years");
            double t = Convert.ToDouble(Console.ReadLine());
            SimpleInterest SI=new SimpleInterest(mathobj);
            var SIVal=SI.Interest(p, t, r);
            Console.WriteLine("The Simple Interest = {0}", SIVal);
            CompoundInterest CI= new CompoundInterest(mathobj);
            var CIVal = CI.Interest(p, t, r);
            Console.WriteLine("The Compound Interest = {0}", CIVal);
        }
    }
}