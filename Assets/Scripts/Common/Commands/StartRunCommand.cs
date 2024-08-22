using System.Threading.Tasks;

public class StartRunCommand : ICommand
{
    public async Task Execute()
    {
        Player.Instance().SetPlayerEnabled(false);
        await Timer.Instance().StartCountdown();
        Player.Instance().SetPlayerEnabled(true);
        ObstacleSpawner.Instance().CanSpawn(true);
    }
}
