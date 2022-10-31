﻿// Abstract Factory pattern -- Real World example

using System;

namespace Abstract.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Abstract Factory Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Create and run the African animal world

            ContinentFactory africa = new AfricaFactory();

            var world = new AnimalWorld(africa);

            world.RunFoodChain();


            // Create and run the American animal world

            ContinentFactory america = new AmericaFactory();

            world = new AnimalWorld(america);

            world.RunFoodChain();


            // Create and run the Asia animal world
            ContinentFactory asia = new AsiaFactory();
            world = new AnimalWorld(asia);
            world.RunFoodChain();

            // Wait for user input

            Console.ReadKey();
        }
    }



    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>
    internal abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();

        public abstract Carnivore CreateCarnivore();
    }


    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    internal class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }


    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    internal class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }
    internal class AsiaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Elephant();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Tiger();
        }
    }


    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>
    internal abstract class Herbivore
    {
    }


    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>
    internal abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }


    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    internal class Wildebeest : Herbivore
    {
    }


    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    internal class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest

            Console.WriteLine(GetType().Name +
                              " eats " + h.GetType().Name);
        }
    }


    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    internal class Bison : Herbivore
    {
    }


    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    internal class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison

            Console.WriteLine(GetType().Name +
                              " eats " + h.GetType().Name);
        }
    }

    internal class Tiger : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison

            Console.WriteLine(GetType().Name +
                              " eats " + h.GetType().Name);
        }
    }

    internal class Elephant : Herbivore
    {
       
    }


    /// <summary>
    /// The 'Client' class
    /// </summary>
    internal class AnimalWorld
    {
        private readonly Carnivore _carnivore;
        private readonly Herbivore _herbivore;


        // Constructor

        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();

            _herbivore = factory.CreateHerbivore();
        }


        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}