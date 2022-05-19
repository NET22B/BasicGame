internal class Game
{
   

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        
    }

    private void Initialize()
    {
        var map = new Map(width: 10,height: 10);
        var hero = new Hero();
    }
}