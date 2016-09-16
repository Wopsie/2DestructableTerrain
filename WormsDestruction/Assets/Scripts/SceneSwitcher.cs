using UnityEngine;

public class SceneSwitcher : MonoBehaviour {

	public void SwitchScene(int index){
        Application.LoadLevel(index);
    }
}
