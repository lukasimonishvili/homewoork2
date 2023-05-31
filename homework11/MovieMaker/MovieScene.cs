namespace MovieMaker
{
    internal class MovieScene
    {
        private MainActor mainActor = new MainActor();
        private StuntActor stuntActor = new StuntActor();
        private int maxDangerLevelForMainActor = 50;

        public void Action(int dangerLevel)
        {
            if (dangerLevel < maxDangerLevelForMainActor)
            {
                stuntActor.Act();
            }
            else
            {
                mainActor.Act();
            }
        }

    }
}
