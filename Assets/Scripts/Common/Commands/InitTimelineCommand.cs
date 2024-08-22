using System.Threading.Tasks;

public class InitTimelineCommand : ICommand
{
   
    public async Task Execute()
    {
        await TimelineController.Instance().Play();
        ScoreView.Instance().ShowScore();
    }
}
