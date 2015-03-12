using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Keeping these clockwise
public enum Direction
{
	LEFT = 0,
	UP_LEFT =1,
	UP_RIGHT = 2,
	RIGHT = 3,
	DOWN_RIGHT = 4,
	DOWN_LEFT = 5
}

//Different home locations that the dimples could belong to
public enum TeamColor
{
	NONE,
	RED,
	BLUE,
	TEST
}

public struct Neighbor
{
	public Dimple dimple;
	public Direction direction;

	public Neighbor(Dimple dimp, Direction dir){
		dimple = dimp;
		direction = dir;
	}
}

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


	/*
		//Create game object representation of this dimple
		GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		go.transform.localScale = new Vector3(.35f, 0, .35f);
		go.transform.position = position;
		//Collider will interfere with mouseover
		GameObject.Destroy(go.GetComponent<Collider>());
		*/

	void Start()
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
			break;
		}

		//Add to static list
		Dimples.Add(this);
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
}
