namespace PokemonCLI
{
    public class LoadingLine : ISceneAction
    {
        public void Run()
        {
            Tools.Typewriter.PrintPause(6);
        }
    }
}
