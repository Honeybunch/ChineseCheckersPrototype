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
	public Dimple currentDimple;
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
		selectionState = SelectionState.HIGHLIGHTED;
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

	/* method that will move a ball in a certain direction, or hop in a certain direction */

	bool moveBall(Direction d){
		bool validMove =true;
		Dimple moveToDimple = null;
		foreach(Neighbor n in currentDimple.neigbors){
			if(n.direction == d){
				moveToDimple =n.dimple;
			}
		}
		if(moveToDimple==null){
			validMove = false; 
		}else{
			if(moveToDimple.isOccupied()){

			}else{


			}
		}

		return validMove;
	}
}
