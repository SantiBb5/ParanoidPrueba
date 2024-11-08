using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;

[CommandAlias("novel")]
public class StoryTime : Command
{

    public StringParameter ScriptName;
    public StringParameter Label;

    public override async UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {

         // 2. Switch cameras.
        var advCamera = GameObject.Find("AdventureModeCamera").GetComponent<Camera>();
        advCamera.enabled = false;
        var naniCamera = Engine.GetService<ICameraManager>().Camera;
        naniCamera.enabled = true;

        // 3. Load and play specified script (is required).
        if (Assigned(ScriptName))
        {
            var scriptPlayer = Engine.GetService<IScriptPlayer>();
            await scriptPlayer.PreloadAndPlayAsync(ScriptName, label: Label);
        }

        // 4. Enable Naninovel input.
        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = true;
    }
}
