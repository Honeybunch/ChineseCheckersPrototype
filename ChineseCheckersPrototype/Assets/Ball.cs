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
		Dimple moveToDimple = currentDimple.getNeighborAtDirection(d);

		if(moveToDimple==null){
			return false;
		}
		else{
			if(moveToDimple.isOccupied()){
				// if moveToDimple alreayd has a ball, check if we can jump
				moveToDimple = moveToDimple.getNeighborAtDirection(d);
				// valid jump?
				if(moveToDimple == null || moveToDimple.isOccupied()){
					return false;
				}

			}
		}
		currentDimple.toggleOccupied();
		// This is where we update position?
		currentDimple = moveToDimple;
		currentDimple.toggleOccupied();


		return true;
	}
}
