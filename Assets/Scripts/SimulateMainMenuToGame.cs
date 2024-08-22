using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateMainMenuToGame : MonoBehaviour
{
    // Start is called before the first frame update
     async void Start()
     {
        await new InitTimelineCommand().Execute();
        await new StartRunCommand().Execute();
     }

   
}
