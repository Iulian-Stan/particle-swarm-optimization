using System;
using System.Linq;
using System.Runtime.Serialization;

namespace PSO
{
    public class Particle
    {
        private static Random _rnd = new Random();
        /// <summary>
        /// Current cost
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// Current X axis component
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Current Y axis component
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Best cost
        /// </summary>
        public double Best { get; set; }
        /// <summary>
        /// X component for best cost
        /// </summary>
        public double BestX { get; set; }
        /// <summary>
        /// Y component for best cost
        /// </summary>
        public double BestY {get; set;}
        /// <summary>
        /// X axis velocity
        /// </summary>
        public double XV { get; set; }
        /// <summary>
        /// Y axis velocity
        /// </summary>
        public double YV { get; set; }
        public Particle() { }
        public Particle(int w, int h)
        {
            XV = 0;
            YV = 0;
            Best = double.MaxValue;
            BestX = X = _rnd.Next(w - 20) + 10 - w / 2;
            BestY = Y = _rnd.Next(h - 20) + 10 - h / 2;
        }

        public void Update(Function f)
        {
            Cost = f.Apply(X, Y);
            if (Cost < Best)
            {
                Best = Cost;
                BestX = X;
                BestY = Y;
            }
        }

        public void Update(double Fi1, double Fi2, double W, double PSI, double GX, double GY)
        {
            XV = PSI * (W * XV + Fi1 * _rnd.NextDouble() * (BestX - X) + Fi2 * _rnd.NextDouble() * (GX - X));
            YV = PSI * (W * YV + Fi1 * _rnd.NextDouble() * (BestY - Y) + Fi2 * _rnd.NextDouble() * (GY - Y));
            
            X += XV;
            Y += YV;
        }
    }
}