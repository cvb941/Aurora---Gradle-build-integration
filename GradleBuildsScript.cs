using Aurora;
using Aurora.EffectsEngine;
using Aurora.Profiles;
using Aurora.Devices;
using Aurora.Settings;
using System;
using System.IO;
using System.Drawing;

public class GradleBuildsScript
{

    //CHANGE THIS TO YOUR AURORA PATH
    public const string auroraPath = "";

    //SETTINGS
    public Color SuccessColor = Color.Green;
    public Color FailureColor = Color.Red;
    public Color BackgroundColour = Color.Black;
    public int blinkInterval = 5;
    public int blinkDuration = 100;
    //END of SETTINGS


    public string ID = "Gradle Builds";
    public KeySequence DefaultKeys = new KeySequence(new[] { DeviceKeys.TAB, DeviceKeys.Q,  DeviceKeys.W, DeviceKeys.E, DeviceKeys.R, DeviceKeys.T, DeviceKeys.Y, DeviceKeys.U, DeviceKeys.I, DeviceKeys.O, DeviceKeys.P });

    public Color ForegroundColour;

    public string successPath = auroraPath + "gradleBuildComplete";
    public string failurePath = auroraPath + "gradleBuildFailed";

    public int counter = 0;
    public bool blinkEnabled = false;
    public bool blinkState = false;
    public int sleepTime = 30;

    public EffectLayer UpdateLights(ScriptSettings settings, IGameState state = null)
    {
        
        EffectLayer layer = new EffectLayer(this.ID);

        if (blinkEnabled) {    
            if (counter % blinkInterval == 0) {
                //Invert state so it blinks
                blinkState = !blinkState;
            }
            if (blinkState) layer.Fill(ForegroundColour);
             else layer.Fill(BackgroundColour);
            if (counter > blinkDuration) {
                //Cleanup
                if(Directory.Exists(successPath)) Directory.Delete(successPath,true);
                if(Directory.Exists(failurePath)) Directory.Delete(failurePath,true);
                blinkEnabled = false;
                counter=0;
            }
        } else {
           //Sleep
            if (counter>sleepTime) {
                 //Keep reseting the counter so it doesnt overflow
                counter = 0;
                if(Directory.Exists(successPath)||Directory.Exists(failurePath)) {
                    blinkEnabled = true;
                    if(Directory.Exists(successPath)) ForegroundColour = SuccessColor;
                    if(Directory.Exists(failurePath))  ForegroundColour = FailureColor;
                }
            }
        }

        
        counter++;
        return layer;
    }
}