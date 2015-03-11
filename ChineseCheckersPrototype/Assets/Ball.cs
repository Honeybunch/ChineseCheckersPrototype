using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	enum SelectionState
	{
		NONE,
		HIGHLIGHTED,
		SELECTED
	}

	public TeamColor BallColor;

	SelectionState selectionState;

	// Use this for initialization
	void Start ()
	{
		switch(BallColor)
		{
		case TeamColor.BLUE:
			gameObject.renderer.material.color = Color.blue;
			break;
		case TeamColor.RED:
			gameObject.renderer.material.color = Color.red;
			break;
		default:
			break;
		}	
	}

	void OnMouseOver()
	{
		Debug.Log(gameObject.renderer.material.color);
	}

	void Update()
	{
		switch(selectionState)
		{
		case SelectionState.HIGHLIGHTED:
			gameObject.renderer.material.SetColor("Outline Color", Color.cyan);
			break;
		case SelectionState.SELECTED:
			gameObject.renderer.material.SetColor("Outline Color", Color.green);
			break;
		default:
			gameObject.renderer.material.SetColor("Outline Color", Color.black);
			break;
		}
	}
}
