using UnityEngine;
using System.Collections;

public class Constant : MonoBehaviour {

	public static int SelectedLevel=1;

	public static bool IsSoundOn()
	{
		if (PlayerPrefs.GetInt ("IsSoundOn", 0) == 0) {
			//sound on 
			return true;
		} else {
			//sound off
			return false;
		}
	}

	public static bool IsMusicOn()
	{
		if (PlayerPrefs.GetInt ("IsMusicOn", 0) == 0) {
			//music on 
			return true;
		} else {
			//music off
			return false;
		}
	}

	static void Initialize()
	{
		if (!PlayerPrefs.HasKey ("TotalLevelsUnlock")) {
			PlayerPrefs.SetInt ("TotalLevelsUnlock", 1);
		}
	}

  

}
