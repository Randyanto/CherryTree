using UnityEngine;
using CherryTree;

public class ExampleAudio : MonoBehaviour {

    public const string AudioSFX = "AudioSFX";
    public const string AudioBGM = "AudioBGM";

    public chAudioManager audioManager;

	void Start() {
        audioManager.GetAudioPlayer(AudioBGM).Play("Thunder");        
    }

}
