namespace BasicGame.ConsoleGame.Services
{
    public interface IMapService
    {
        (int width, int height) GetMap();
    }
}