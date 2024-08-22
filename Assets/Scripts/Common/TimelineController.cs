using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;
    private static TimelineController _instance;
    private TaskCompletionSource<bool> _playableDirectorTaskCompletionSource;
    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
    public static TimelineController Instance()
    {
        return _instance;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Skip(); //Hacerlo comando
        }
    }
    public Task Play()
    {
        _playableDirectorTaskCompletionSource = new TaskCompletionSource<bool>();

        _playableDirector.stopped += OnPlayableDirectorStopped;

        _playableDirector.Play();

        return _playableDirectorTaskCompletionSource.Task;

    }
    public void Skip()
    {
        if(_playableDirector.state == PlayState.Playing)
        {
            _playableDirector.Stop();
            _playableDirectorTaskCompletionSource.TrySetResult(true);
            Debug.Log("La cinematica ha sido saltada");
        }
    }
    private void OnPlayableDirectorStopped(PlayableDirector playableDirector)
    {
        if (playableDirector == _playableDirector)
        {
            _playableDirector.stopped -= OnPlayableDirectorStopped;

            _playableDirectorTaskCompletionSource.TrySetResult(true);
            Debug.Log("La animación ha terminado, la tarea se ha completado.");
        }
    }
}
