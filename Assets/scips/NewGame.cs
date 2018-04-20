using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour 
{
	void OnMouseDown ()
	{
		transform.localScale *= 1.1f;

	}

	void OnMouseUp()
	{
		Application.LoadLevel (1);
	}
}
