using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	public bool updateDimple = false;

	public static List<Ball> Balls = new List<Ball>();
	public static bool Selected;

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

		Balls.Add(this);
	}

	void OnMouseOver()
	{
		//If we click on a ball, it is selected and we lock into that
		if(Input.GetMouseButtonDown(0))
		{
			selectionState = SelectionState.SELECTED;
			Selected = true;
		}

		//Otherwise we're just highlighting the ball if there are no other balls selected
		else if(!Selected)
		{
			selectionState = SelectionState.HIGHLIGHTED;

			//Make sure every other ball is not in a highlighted state
			foreach(Ball b in Balls)
			{
				if(b != this)
					b.selectionState = SelectionState.NONE;

			}
		}
	
	}

	void OnMouseExit()
	{
		if(selectionState != SelectionState.SELECTED)
			selectionState = SelectionState.NONE;
	}

	void Update()
	{
		switch(selectionState)
		{
		case SelectionState.HIGHLIGHTED:
			gameObject.renderer.material.SetColor("_OutlineColor", Color.cyan);
			break;
		case SelectionState.SELECTED:
			gameObject.renderer.material.SetColor("_OutlineColor", Color.green);
			break;
		default:
			gameObject.renderer.material.SetColor("_OutlineColor", Color.black);
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

	
		return updateDimple = true;;
	}
}
