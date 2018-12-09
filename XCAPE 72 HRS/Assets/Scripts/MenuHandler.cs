using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

	public void MenuButton(){
		SceneManager.LoadScene("MenuScreen");
	}

	public void Quit(){
		Application.Quit();
	}

}
