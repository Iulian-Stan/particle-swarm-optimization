# Particle Swarm Optimization

The purpose of this project is to show the use of **PSO** (**P**article **S**warm **O**ptimization)
methods in minimizations problems. This particular example is focused on finding the minimal value
of a function. It is applied only for two dimmensional functions (which made possible to graphically 
represent algorithm's execution) but can be extended to any number of dimensions. Used functions:
- Sphere
- Griewangk 
- Rastrigin 
- Rosenbock 

For more details (formula/representation) on optimisation functions (including the used ones)
consult this [Wiki page](https://en.wikipedia.org/wiki/Test_functions_for_optimization).

Another swarm intelligence based algorithm can be found here - 
[Ant Colony Optimization](https://github.com/Iulian-Stan/AntColonyOptimization).

## Solution

By running the application it can be seen that the system is initialized with a randomly placed 
**_particles_** - which represents the initial solution in the function's visible domain. It tries
to improve the solution gradually moving each particle closer to a possible solution. Eventually
all particles will gather in a single point representing the minimal value.

## Interface 

![demo](https://raw.githubusercontent.com/Iulian-Stan/ParticleSwarmOptimization/502a390653387d3233d84223d3d5d66206923721/demo.PNG)

There is a graphical representation of the problem on the left side and control panel on the right.

### Graphic
The functions origin is in the middle of the image, the color represents function value taking
each points coordinates as input values, the dots represent the **_particles_**.

### Control
Parameters:
* **Population** size - particles number
* **Delay** - small freeze time used in simulation
* **Optimization function** - mentioned above
* **Algorithm** 
 * Base - particle's position shifting is determined equaly by all other particles
 * Initial weight - in addition to base case it adds a coefficient to the previous shifting 
(other way said it sets previous step position importance) 
 * Constriction factor - the entire formula from base case is scaled by a factor
* **Topology**
 * Full - each particle is affected by the entire population
 * Ring - each particle is affected only by two neigbours
 * 4-neighbours - each particle is affected by 4 neighbours
* **Coeficients**
 * φ1 - individual influence (how much te movement is affected by individual position)
 * φ2 - social infuence (how much te movement is affected by other's particles position)
 * w/ψ - initial weight or constriction factor (depending on selected algorithm)
 
Best result is displayed on the bottom.
