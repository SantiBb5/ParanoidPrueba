using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;

public class ModernTalking : MonoBehaviour
{
    public string ScriptName;
    public string Label;

    private void Talkin()
    {
        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = true;

        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.PreloadAndPlayAsync(ScriptName, label: Label).Forget();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
