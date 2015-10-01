using System;
using System.Windows.Forms;

namespace PSO
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPso());
        }
    }
}





/*
    internal class Program
    {
        private static Random _ran;

        private static void Main()
        {
            var iteration = 0;
            try
            {
                Console.WriteLine("\nBegin Particle Swarm Optimization demonstration\n");
                Console.WriteLine("\nObjective function to minimize has dimension = 2");
                Console.WriteLine("Objective function is f(x) = 3 + (x0^2 + x1^2)");

                _ran = new Random(0);

                const int numberParticles = 10;
                const int numberIterations = 1000;
                const int dim = 2; // dimensions
                const double minX = -100.0;
                const double maxX = 100.0;

                Console.WriteLine("Range for all x values is " + minX + " <= x <= " + maxX);
                Console.WriteLine("\nNumber iterations = " + numberIterations);
                Console.WriteLine("Number particles in swarm = " + numberParticles);

                var swarm = new Particle[numberParticles];
                var bestGlobalPosition = new double[dim];
                    // best solution found by any particle in the swarm. implicit initialization to all 0.0
                double bestGlobalFitness = double.MaxValue; // smaller values better

                const double minV = -1.0*maxX;
                const double maxV = maxX;

                Console.WriteLine("\nInitializing swarm with random positions/solutions");
                for (var i = 0; i < swarm.Length; ++i) // initialize each Particle in the swarm
                {
                    var randomPosition = new double[dim];
                    for (var j = 0; j < randomPosition.Length; ++j)
                    {
                        const double lo = minX;
                        const double hi = maxX;
                        randomPosition[j] = (hi - lo)*_ran.NextDouble() + lo; // 
                    }
                    //double fitness = SphereFunction(randomPosition); // smaller values are better
                    //double fitness = GP(randomPosition); // smaller values are better
                    double fitness = ObjectiveFunction(randomPosition);
                    var randomVelocity = new double[dim];

                    for (int j = 0; j < randomVelocity.Length; ++j)
                    {
                        double lo = -1.0*Math.Abs(maxX - minX);
                        double hi = Math.Abs(maxX - minX);
                        randomVelocity[j] = (hi - lo)*_ran.NextDouble() + lo;
                    }
                    swarm[i] = new Particle(randomPosition, fitness, randomVelocity, randomPosition, fitness);

                    // does current Particle have global best position/solution?
                    if (swarm[i].Fitness < bestGlobalFitness)
                    {
                        bestGlobalFitness = swarm[i].Fitness;
                        swarm[i].Position.CopyTo(bestGlobalPosition, 0);
                    }
                } // initialization

                Console.WriteLine("\nInitialization complete");
                Console.WriteLine("Initial best fitness = " + bestGlobalFitness.ToString("F4"));
                Console.WriteLine("Best initial position/solution:");
                for (int i = 0; i < bestGlobalPosition.Length; ++i)
                {
                    Console.WriteLine("x" + i + " = " + bestGlobalPosition[i].ToString("F4") + " ");
                }

                const double w = 0.729; // inertia weight. see http://ieeexplore.ieee.org/stamp/stamp.jsp?arnumber=00870279
                const double c1 = 1.49445; // cognitive/local weight
                const double c2 = 1.49445; // social/global weight

                Console.WriteLine("\nEntering main PSO processing loop");
                while (iteration < numberIterations)
                {
                    ++iteration;
                    var newVelocity = new double[dim];
                    var newPosition = new double[dim];

                    foreach (Particle currP in swarm)
                    {
                        for (int j = 0; j < currP.Velocity.Length; ++j) // each x value of the velocity
                        {
                            double r1 = _ran.NextDouble(); // cognitive and social randomizations
                            double r2 = _ran.NextDouble(); // cognitive and social randomizations

                            newVelocity[j] = (w*currP.Velocity[j]) +
                                             (c1*r1*(currP.BestPosition[j] - currP.Position[j])) +
                                             (c2*r2*(bestGlobalPosition[j] - currP.Position[j]));

                            if (newVelocity[j] < minV)
                                newVelocity[j] = minV;
                            else if (newVelocity[j] > maxV)
                                newVelocity[j] = maxV;
                        }

                        newVelocity.CopyTo(currP.Velocity, 0);

                        for (int j = 0; j < currP.Position.Length; ++j)
                        {
                            newPosition[j] = currP.Position[j] + newVelocity[j];
                            if (newPosition[j] < minX)
                                newPosition[j] = minX;
                            else if (newPosition[j] > maxX)
                                newPosition[j] = maxX;
                        }

                        newPosition.CopyTo(currP.Position, 0);
                        double newFitness = ObjectiveFunction(newPosition);
                        currP.Fitness = newFitness;

                        if (newFitness < currP.BestFitness)
                        {
                            newPosition.CopyTo(currP.BestPosition, 0);
                            currP.BestFitness = newFitness;
                        }

                        if (newFitness < bestGlobalFitness)
                        {
                            newPosition.CopyTo(bestGlobalPosition, 0);
                            bestGlobalFitness = newFitness;
                        }
                    }

                    Console.WriteLine(swarm[0].ToString());
                    Console.ReadLine();
                } // while

                Console.WriteLine("\nProcessing complete");
                Console.Write("Final best fitness = ");
                Console.WriteLine(bestGlobalFitness.ToString("F4"));
                Console.WriteLine("Best position/solution:");
                for (int i = 0; i < bestGlobalPosition.Length; ++i)
                {
                    Console.Write("x" + i + " = ");
                    Console.WriteLine(bestGlobalPosition[i].ToString("F4") + " ");
                }
                Console.WriteLine("");

                Console.WriteLine("\nEnd PSO demonstration\n");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal error: " + ex.Message);
                Console.ReadLine();
            }
        }

        // Main()

        private static double ObjectiveFunction(double[] x)
        {
            return 3.0 + (x[0]*x[0]) + (x[1]*x[1]); // f(x) = 3 + x^2 + y^2
        }
    }

    // class Program

    public class Particle
    {
        public double BestFitness;
        public double[] BestPosition; // best position found so far by this Particle
        public double Fitness;
        public double[] Position; // equivalent to x-Values and/or solution
        public double[] Velocity;

        public Particle(double[] position, double fitness, double[] velocity, double[] bestPosition, double bestFitness)
        {
            Position = new double[position.Length];
            position.CopyTo(Position, 0);
            Fitness = fitness;
            Velocity = new double[velocity.Length];
            velocity.CopyTo(Velocity, 0);
            BestPosition = new double[bestPosition.Length];
            bestPosition.CopyTo(BestPosition, 0);
            BestFitness = bestFitness;
        }

        public override string ToString()
        {
            string s = "";
            s += "==========================\n";
            s += "Position: ";
            for (int i = 0; i < Position.Length; ++i)
                s += Position[i].ToString("F2") + " ";
            s += "\n";
            s += "Fitness = " + Fitness.ToString("F4") + "\n";
            s += "Velocity: ";
            for (int i = 0; i < Velocity.Length; ++i)
                s += Velocity[i].ToString("F2") + " ";
            s += "\n";
            s += "Best Position: ";
            for (int i = 0; i < BestPosition.Length; ++i)
                s += BestPosition[i].ToString("F2") + " ";
            s += "\n";
            s += "Best Fitness = " + BestFitness.ToString("F4") + "\n";
            s += "==========================\n";
            return s;
        }
    }

    // class Particle
     * */












/*
class MultiSwarmProgram
{
    static void Main()
    {
        try
        {
            Console.WriteLine("\nBegin Multiple Particle Swarm optimization demo\n");
            Console.WriteLine("Goal is to minimize Rastrigin's function");
            Console.WriteLine("Function has known solution of 0.0 at x0 = 0.0, x1 = 0.0");

            Console.WriteLine("\nSetting minX = -100.0 and maxX = +100.0");
            const int dim = 2;
            const double minX = -100.0;
            const double maxX = 100.0;

            Console.WriteLine("Setting number particles in each swarm = 4");
            Console.WriteLine("Setting number swarms in multiswarm = 3");
            const int numParticles = 4; // number particles in each swarm
            const int numSwarms = 3; // number swarms in multiswarm

            Console.WriteLine("\nInitializing all swarms in multiswarm");
            var ms = new Multiswarm(numSwarms, numParticles, dim, minX, maxX);
            Console.WriteLine("\nInitial multiswarm:");
            Console.WriteLine(ms.ToString());

            const int maxLoop = 150;
            Console.WriteLine("\nSetting maxLoop = " + maxLoop);
            Console.WriteLine("Entering main solve loop");
            ms.Solve(maxLoop);

            Console.WriteLine("Solve loop complete");
            Console.WriteLine("\nFinal multiswarm:");
            Console.WriteLine(ms.ToString());

            Console.WriteLine("\nBest solution found = " + ms.BestMultiCost.ToString("F6"));
            Console.Write("at x0 = " + ms.BestMultiPos[0].ToString("F4"));
            Console.WriteLine(", x1 = " + ms.BestMultiPos[1].ToString("F4"));

            Console.WriteLine("\nEnd demo\n");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }

    public static double Cost(double[] position)
    {
        return position.Sum(xi => (xi*xi) - (10*Math.Cos(2*Math.PI*xi)) + 10);
    }
} // Program

public class Particle
{
    static readonly Random Ran = new Random(0);
    public double[] Position;
    public double[] Velocity;
    public double Cost;
    public double[] BestPartPos;
    public double BestPartCost;

    public Particle(int dim, double minX, double maxX)
    {
        Position = new double[dim];
        Velocity = new double[dim];
        BestPartPos = new double[dim];
        for (int i = 0; i < dim; ++i)
        {
            Position[i] = (maxX - minX) * Ran.NextDouble() + minX;
            Velocity[i] = (maxX - minX) * Ran.NextDouble() + minX;
        }
        Cost = MultiSwarmProgram.Cost(Position);
        BestPartCost = Cost;
        Array.Copy(Position, BestPartPos, dim);
    }

    public override string ToString()
    {
        string s = "";
        s += "Pos [ ";
        for (int i = 0; i < Position.Length; ++i)
            s += Position[i].ToString("F2") + " ";
        s += "] ";
        s += "Vel [ ";
        for (int i = 0; i < Velocity.Length; ++i)
            s += Velocity[i].ToString("F2") + " ";
        s += "] ";
        s += "Cost = " + Cost.ToString("F3");
        s += " Best Pos [ ";
        for (int i = 0; i < BestPartPos.Length; ++i)
            s += BestPartPos[i].ToString("F2") + " ";
        s += "] ";
        s += "BestCost = " + Cost.ToString("F3");
        return s;
    }

} // Particle

public class Swarm
{
    public Particle[] Particles;
    public double[] BestSwarmPos;
    public double BestSwarmCost;

    public Swarm(int numParticles, int dim, double minX, double maxX)
    {
        BestSwarmCost = double.MaxValue;
        BestSwarmPos = new double[dim];
        Particles = new Particle[numParticles];
        for (int i = 0; i < Particles.Length; ++i)
        {
            Particles[i] = new Particle(dim, minX, maxX);
            if (Particles[i].Cost < BestSwarmCost)
            {
                BestSwarmCost = Particles[i].Cost;
                Array.Copy(Particles[i].Position, BestSwarmPos, dim);
            }
        }
    }

    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < Particles.Length; ++i)
            s += "[" + i + "] " + Particles[i] + "\n";
        s += "Best Swarm Pos [ ";
        for (int i = 0; i < BestSwarmPos.Length; ++i)
            s += BestSwarmPos[i].ToString("F2") + " ";
        s += "] ";
        s += "Best Swarm Cost = " + BestSwarmCost.ToString("F3");
        s += "\n";
        return s;
    }
} // Swarm

public class Multiswarm
{
    public Swarm[] Swarms;
    public double[] BestMultiPos;
    public double BestMultiCost;
    public int Dim;
    public double MinX;
    public double MaxX;

    static readonly Random Ran = new Random(0); // Solve() has random features

    public Multiswarm(int numSwarms, int numParticles, int dim, double minX, double maxX)
    {
        Swarms = new Swarm[numSwarms];
        BestMultiPos = new double[dim];
        BestMultiCost = double.MaxValue;
        Dim = dim;
        MinX = minX;
        MaxX = maxX;

        for (int i = 0; i < numSwarms; ++i)
        {
            Swarms[i] = new Swarm(numParticles, dim, minX, maxX);
            if (Swarms[i].BestSwarmCost < BestMultiCost)
            {
                BestMultiCost = Swarms[i].BestSwarmCost;
                Array.Copy(Swarms[i].BestSwarmPos, BestMultiPos, dim);
            }
        }
    }

    public void Solve(int maxLoop)
    {
        var ct = 0;
        const double w = 0.729; // inertia
        const double c1 = 1.49445; // particle / cogntive
        const double c2 = 1.49445; // swarm / social
        const double c3 = 0.3645; // multiswarm / global
        const double death = 0.005; // prob of particle death
        const double immigrate = 0.005; // prob of particle immigration

        while (ct < maxLoop)
        {
            ++ct;
            for (int i = 0; i < Swarms.Length; ++i) // each swarm
            {
                for (int j = 0; j < Swarms[i].Particles.Length; ++j) // each particle
                {
                    double p = Ran.NextDouble();
                    if (p < death)
                    {
                        Swarms[i].Particles[j] = new Particle(Dim, MinX, MaxX);
                    }

                    double q = Ran.NextDouble();
                    if (q < immigrate)
                    {
                        Immigration(i, j); // swap curr particle with a random particle in diff swarm
                    }

                    for (int k = 0; k < Dim; ++k) // update velocity. each x position component
                    {
                        double r1 = Ran.NextDouble();
                        double r2 = Ran.NextDouble();
                        double r3 = Ran.NextDouble();

                        Swarms[i].Particles[j].Velocity[k] = (w * Swarms[i].Particles[j].Velocity[k]) +
                          (c1 * r1 * (Swarms[i].Particles[j].BestPartPos[k] - Swarms[i].Particles[j].Position[k])) +
                          (c2 * r2 * (Swarms[i].BestSwarmPos[k] - Swarms[i].Particles[j].Position[k])) +
                          (c3 * r3 * (BestMultiPos[k] - Swarms[i].Particles[j].Position[k]));

                        if (Swarms[i].Particles[j].Velocity[k] < MinX)
                            Swarms[i].Particles[j].Velocity[k] = MinX;
                        else if (Swarms[i].Particles[j].Velocity[k] > MaxX)
                            Swarms[i].Particles[j].Velocity[k] = MaxX;

                    }

                    for (int k = 0; k < Dim; ++k) // update position
                    {
                        Swarms[i].Particles[j].Position[k] += Swarms[i].Particles[j].Velocity[k];
                    }

                    // update cost
                    Swarms[i].Particles[j].Cost = MultiSwarmProgram.Cost(Swarms[i].Particles[j].Position);

                    // check if new best cost
                    if (Swarms[i].Particles[j].Cost < Swarms[i].Particles[j].BestPartCost)
                    {
                        Swarms[i].Particles[j].BestPartCost = Swarms[i].Particles[j].Cost;
                        Array.Copy(Swarms[i].Particles[j].Position, Swarms[i].Particles[j].BestPartPos, Dim);
                    }

                    if (Swarms[i].Particles[j].Cost < Swarms[i].BestSwarmCost)
                    {
                        Swarms[i].BestSwarmCost = Swarms[i].Particles[j].Cost;
                        Array.Copy(Swarms[i].Particles[j].Position, Swarms[i].BestSwarmPos, Dim);
                    }

                    if (Swarms[i].Particles[j].Cost < BestMultiCost)
                    {
                        BestMultiCost = Swarms[i].Particles[j].Cost;
                        Array.Copy(Swarms[i].Particles[j].Position, BestMultiPos, Dim);
                    }
                }
            }

        }
    }

    private void Immigration(int i, int j)
    {
        // swap particle j in swarm i, with a random particle in a random swarm
        int otheri = Ran.Next(0, Swarms.Length);
        int otherj = Ran.Next(0, Swarms[0].Particles.Length);
        Particle tmp = Swarms[i].Particles[j];
        Swarms[i].Particles[j] = Swarms[otheri].Particles[otherj];
        Swarms[otheri].Particles[otherj] = tmp;
    }

    public override string ToString()
    {
        string s = "";
        s += "=======================\n";
        s = Swarms.Aggregate(s, (current, t) => current + (t + "\n"));
        s += "Best Multiswarm Pos [ ";
        for (int i = 0; i < BestMultiPos.Length; ++i)
            s += BestMultiPos[i].ToString("F2") + " ";
        s += "] ";
        s += "Best Multiswarm Cost = " + BestMultiCost.ToString("F3");
        s += "\n=======================\n";
        return s;
    }

} // Multiswarm
*/