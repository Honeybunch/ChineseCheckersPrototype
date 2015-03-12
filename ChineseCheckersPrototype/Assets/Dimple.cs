using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dimple : MonoBehaviour
{
	//Publics
	public List<Neighbor> neighbors = new List<Neighbor>();
	public TeamColor HomeColor = TeamColor.NONE;
	public Vector3 Position
	{
		get{return transform.position;}
		set{transform.position = value;}
	}

	//Privates
	private bool occupied = false;

	//Public Statics
	public static List<Dimple> Dimples = new List<Dimple>();

	void Start()
	{
		SetDefaultColor();

		//Add to static list
		Dimples.Add(this);
	}

	void OnMouseOver()
	{
		if(Ball.Selected)
		{
			bool isNeighborToSelected = false;

			foreach(Neighbor n in Ball.SelectedBall.CurrentDimple.neighbors)
			{
				Dimple d = n.dimple;
				if(d == this)
				{
					isNeighborToSelected = true;
					break;
				}
			}

			if(isNeighborToSelected)
				renderer.material.SetColor ("_OutlineColor", Color.cyan);
		}
	}

	void OnMouseExit()
	{
		SetDefaultColor();
	}

	public void AddNeighboringDimple(Neighbor n)
	{	
		// add the neighbor if there isn't already one in that direction
		if(getNeighborAtDirection(n.direction)==null){
			neighbors.Add(n);
		}else{
			return;
		}

		Dimple neighborDimple = n.dimple;

		// get direction to THIS dimple from new neighbor
		Direction acrossDirection = acrossFromDirection(n.direction);

		// ad THIS dimple as neighbor to the neighbor at the new direction
		if(neighborDimple.getNeighborAtDirection(acrossDirection)==null){
			neighborDimple.AddNeighboringDimple(new Neighbor(this,acrossDirection));
		}
	}

	public void toggleOccupied(){
		occupied = !occupied;
	}

	public bool isOccupied(){
		return occupied;
	}

	public Dimple getNeighborAtDirection(Direction d){
		Dimple moveToDimple = null;
		foreach(Neighbor n in neighbors){
			if(n.direction == d){
				moveToDimple =n.dimple;

			}
		}
		return moveToDimple;

	}

	Direction acrossFromDirection(Direction d){
		if((int)d >2){
			return d-3;		
		}
		else{
			return d+3;
		}
	}

	public void SetDefaultColor()
	{
		//Set the color to be highlighted if we have a selected ball

		if(Ball.Selected)
		{
			Ball.SelectedBall.HighlightNeighboringDimples();
		}
		else
		{
			switch(HomeColor)
			{
			case TeamColor.BLUE:
				renderer.material.SetColor ("_OutlineColor", Color.blue);
				break;
			case TeamColor.RED:
				renderer.material.SetColor ("_OutlineColor", Color.red);
				break;
			default:
				renderer.material.SetColor ("_OutlineColor", new Color(.3f, .3f, .3f));
				break;
			}
		}
	}
}
