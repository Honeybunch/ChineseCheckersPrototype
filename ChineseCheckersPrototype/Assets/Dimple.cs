using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Keeping these clockwise
public enum Direction
{
	LEFT,
	UP_LEFT,
	UP_RIGHT,
	RIGHT,
	DOWN_RIGHT,
	DOWN_LEFT
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

public class Dimple
{
	public List<Neighbor> neighbors = new List<Neighbor>();
	public TeamColor homeColor;
	public Vector3 position;
	bool occupied = false;

	//Singleton dimple list
	public static List<Dimple> Dimples = new List<Dimple>();

	public Dimple(TeamColor homeColor, Vector3 position)
	{
		this.homeColor = homeColor;
		this.position = position;

		//Add to static list
		Dimples.Add(this);

		//Create game object representation of this dimple
		GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		go.transform.localScale = new Vector3(.35f, 0, .35f);
		go.transform.position = position;
		//Collider will interfere with mouseover
		GameObject.Destroy(go.GetComponent<Collider>());

		switch(homeColor)
		{
		case TeamColor.BLUE:
			go.renderer.material.color = Color.blue;
			break;
		case TeamColor.RED:
			go.renderer.material.color = Color.red;
			break;
		default:
			break;
		}
	}

	public void AddNeighboringDimple(Neighbor n)
	{	

		neighbors.Add(n);
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
}
