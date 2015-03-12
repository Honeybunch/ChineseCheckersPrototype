using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ball : MonoBehaviour 
{
	public TeamColor BallColor;
	public Dimple CurrentDimple;
	public bool UpdateDimple = false;

	SelectionState selectionState;

	public static List<Ball> Balls = new List<Ball>();
	public static bool Selected;
	public static Ball SelectedBall;

	// Use this for initialization
	void Start ()
	{
		setDefaultColor();

		Balls.Add(this);
	}

	void OnMouseOver()
	{
		//If we click on a ball, it is selected and we lock into that
		if(Input.GetMouseButtonDown(0) && !Selected)
		{
			selectionState = SelectionState.SELECTED;

			Selected = true;
			SelectedBall = this;

			HighlightNeighboringDimples();
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

		//Input to break out of selection state
		if(Input.GetMouseButtonDown(1))
		{
			if(Selected)
			{
				SelectedBall.setDefaultColor();
				SelectedBall.selectionState = SelectionState.NONE;

				Selected = false;

				//Fix dimple colours
				foreach(Neighbor n in SelectedBall.CurrentDimple.neighbors)
				{
					n.dimple.SetDefaultColor();
				}

				SelectedBall = null;
			}
		}

	}

	public void HighlightNeighboringDimples()
	{
		List<Neighbor> neighbors = CurrentDimple.neighbors;

		foreach(Neighbor n in neighbors)
		{
			n.dimple.renderer.material.SetColor("_OutlineColor", Color.yellow);
		}
	}

	void setDefaultColor()
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

	/* method that will move a ball in a certain direction, or hop in a certain direction */

<<<<<<< HEAD
=======
	bool moveBall(Direction d){
		Dimple moveToDimple = CurrentDimple.getNeighborAtDirection(d);
>>>>>>> 3dfb2dec6068c24852cb1c35e956f9808658a274


	public bool moveBall(Direction d){
		Dimple moveToDimple = currentDimple.getNeighborAtDirection(d);
		//Debug.Log (d);
		//Debug.Log (moveToDimple);
		if(moveToDimple==null){
			return false;
		}
		else{
			if(moveToDimple.isOccupied()){
				Debug.Log ("occupied");

				// if moveToDimple alreayd has a ball, check if we can jump
				moveToDimple = moveToDimple.getNeighborAtDirection(d);
				// valid jump?
				if(moveToDimple == null || moveToDimple.isOccupied()){
					return false;
				}

			}
		}
		CurrentDimple.toggleOccupied();
		// This is where we update position?
<<<<<<< HEAD
		currentDimple = moveToDimple;
		currentDimple.toggleOccupied();
		Debug.Log (currentDimple);

		Vector3 newPos = this.transform.position;
		newPos.x = currentDimple.transform.position.x;
		newPos.z = currentDimple.transform.position.z;
		this.transform.position = newPos;
=======
		CurrentDimple = moveToDimple;
		CurrentDimple.toggleOccupied();
>>>>>>> 3dfb2dec6068c24852cb1c35e956f9808658a274

		return true;
	
<<<<<<< HEAD
=======
		return UpdateDimple = true;;
>>>>>>> 3dfb2dec6068c24852cb1c35e956f9808658a274
	}
}
