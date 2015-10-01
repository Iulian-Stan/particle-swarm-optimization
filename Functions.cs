using System;
using System.Drawing;

namespace PSO
{
    public abstract class Function
    {
        public abstract double Apply(double x, double y);       
    }

    //for i = 1:n
    //      val = val + x(i).^2;
    //end    
    public class Sphere : Function
    {
        public override double Apply(double x, double y)
        {
            return x * x + y * y;
        }
    }

    //for i=1:size(x,2)
    //    temp1=temp1+(x(i)^2)/4000;
    //    temp2=temp2*cos(x(i)/sqrt(i));
    //end
    //val=temp1-temp2+1
    public class Griewangk : Function
    {
        public override double Apply(double x, double y)
        {
            return (x * x + y * y) / 4000 - Math.Cos(x) * Math.Cos(y / Math.Sqrt(2)) + 1;
        }
    }

    //for i=1:size(x,2)
    //  val=val+x(i)^2-10*cos(2*pi*x(i))+10;
    //end
    public class Rastrigin : Function
    {
        public override double Apply(double x, double y)
        {
            return x * x + y * y - 10 * (Math.Cos(2 * Math.PI * x) + Math.Cos(2 * Math.PI * y)) + 10 * 2;
        }
    }

    //for i=1:(size(x,2)-1)
    //  val=val+100*(x(i+1)-(x(i))^2)^2+(x(i)-1)^2;
    //end
    public class Rosenbock : Function
    {
        public override double Apply(double x, double y)
        {
            return 100 * (y - x * x) * (y - x * x) + (1 - x) * (1 - x);
        }
    }
}