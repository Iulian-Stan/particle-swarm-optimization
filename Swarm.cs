using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace PSO
{
    public class Swarm
    {
        public static Function F { get; protected set; }
        public List<Particle> Particles { get; protected set; }
        private readonly double _fi1, _fi2, _w, _psi;
        private double _x, _y, _best = double.MaxValue;

        public int Count { get { return (Particles == null ? 0 : Particles.Count); } }
        public Particle this[int index]
        {
            get { return Particles[index]; }
        }

        public Swarm() { }

        public Swarm(EFunction function, int particles, double fi1, double fi2, double w, double psi, int width, int height)
        {
            _fi1 = fi1;
            _fi2 = fi2;
            _w = w;
            _psi = psi;
            switch (function)
            {
                case EFunction.Sphere:
                    F = new Sphere();
                    break;
                case EFunction.Griewangk:
                    F = new Griewangk();
                    break;
                case EFunction.Rastrigin:
                    F = new Rastrigin();
                    break;
                case EFunction.Rosenbock:
                    F = new Rosenbock();
                    break;
            }
            if (Particles != null)
                Particles.Clear();
            else
                Particles = new List<Particle>(particles);
            for (int particle = 0; particle < particles; ++particle)
                Particles.Add(new Particle(width, height));

            CreateMap(width, height);
        }

        public void SimulateStep(int delay)
        {
            foreach (Particle particle in Particles)
            {
                particle.Update(F);
                if (_best > particle.Best)
                {
                    _best = particle.Best;
                    _x = particle.BestX;
                    _y = particle.BestY;
                }
            }
            foreach (Particle particle in Particles)
            {
                particle.Update(_fi1, _fi2, _w, _psi, _x, _y);
            }
            if (delay > 0)
                Thread.Sleep(delay);
        }

        public void SimulateStep(int delay, int neighbours)
        {
            foreach (Particle particle in Particles)
                particle.Update(F);
            for (int part = 0; part < Particles.Count; ++part)
            {
                _best = Particles[part].Best;
                for (int neighbour = (part + Particles.Count - neighbours / 2) % Particles.Count; neighbour < (part + Particles.Count - neighbours / 2) % Particles.Count; ++neighbour)
                {
                    if (_best > Particles[neighbour].Best)
                    {
                        _best = Particles[neighbour].Best;
                        _x = Particles[neighbour].BestX;
                        _y = Particles[neighbour].BestY;
                    }
                }
                Particles[part].Update(_fi1, _fi2, _w, _psi, _x, _y);
            }
            if (delay > 0)
                Thread.Sleep(delay);
        }

        public void Clear()
        {
            Particles?.Clear();
        }

        public void AddRange(List<Particle> particles)
        {
            Particles.AddRange(particles);
        }

        static public Bitmap Map { get; protected set; }

        private static void CreateMap(int width, int height)
        {
            double[,] img = new double[width, height];
            double maxObtained, minObtained = maxObtained = F.Apply(0, 0);
            for (int j = 0; j < width; j++)
                for (int i = 0; i < height; i++)
                {
                    img[j, i] = F.Apply((j - width / 2), (i - height / 2));
                    if (minObtained > img[j, i])
                    {
                        minObtained = img[j, i];
                    }
                    if (maxObtained < img[j, i])
                    {
                        maxObtained = img[j, i];
                    }
                }

            double minExpected = 0d;
            double maxExpected = 240d;

            double a = (maxExpected - minExpected) / (maxObtained - minObtained);
            double b = (minExpected * maxObtained - minObtained * maxExpected) / (maxObtained - minObtained);


            Map = new Bitmap(width, height);
            for (int j = 0; j < width; j++)
                for (int i = 0; i < height; i++)
                {
                    Map.SetPixel(
                        j, i, new HSLColor(a * img[j, i] + b, 240.0, 120.0));
                }
        }
    }
}
