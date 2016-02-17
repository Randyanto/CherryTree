using UnityEngine;
using CherryTree;

public class GameController : MonoBehaviour {

    public const string AudioSFX = "AudioSFX";
    public const string AudioBGM = "AudioBGM";

    public chAudioManager audioManager;

	void Start() {
        //audioManager.GetAudioPlayer(AudioBGM).Play("Thunder");        
    }

}
