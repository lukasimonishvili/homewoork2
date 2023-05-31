using System;

namespace MovieMaker
{
    internal class MainActor : AbstractActor
    {
        public override void Act()
        {
            Console.WriteLine("Main actor is acting");
        }
    }

    internal class StuntActor : AbstractActor
    {
        public override void Act()
        {
            Console.WriteLine("Stunt actor is acting");
        }
    }
}
