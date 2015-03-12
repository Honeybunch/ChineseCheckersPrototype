using UnityEngine;
using System.Collections;

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

enum SelectionState
{
	NONE,
	HIGHLIGHTED,
	SELECTED
}