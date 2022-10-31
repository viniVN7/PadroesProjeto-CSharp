﻿// Command pattern -- Structural example

using System;

namespace Command.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Command Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create receiver, command, and invoker

            var receiver = new Receiver();

            Command command = new ConcreteCommand(receiver);

            var invoker = new Invoker();


            // Set and execute command

            invoker.SetCommand(command);

            invoker.ExecuteCommand();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    internal abstract class Command
    {
        protected Receiver receiver;


        // Constructor

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }


        public abstract void Execute();
    }


    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    internal class ConcreteCommand : Command
    {
        // Constructor

        public ConcreteCommand(Receiver receiver) :
            base(receiver)
        {
        }


        public override void Execute()
        {
            receiver.Action();
        }
    }


    /// <summary>
    /// The 'Receiver' class
    /// </summary>
    internal class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }


    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    internal class Invoker
    {
        private Command _command;


        public void SetCommand(Command command)
        {
            _command = command;
        }


        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}