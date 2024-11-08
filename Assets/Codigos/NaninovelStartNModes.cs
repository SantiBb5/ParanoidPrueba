using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;

public class NaninovelStartNModes : MonoBehaviour
{
    public Camera AdventureModeCamera;

    // Start is called before the first frame update
    private async void Start()
    { 

        await RuntimeInitializer.InitializeAsync();
        var player = Engine.GetService<IScriptPlayer>();
        await player.PreloadAndPlayAsync("Base");
    }

}