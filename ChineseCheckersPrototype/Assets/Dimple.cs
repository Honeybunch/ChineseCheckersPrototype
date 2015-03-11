﻿using UnityEngine;
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
	BLUE
}

public struct Neigbor
{
	Dimple dimple;
	Direction direction;
}

public class Dimple
{
	public List<Neigbor> neigbors = new List<Neigbor>();
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
		go.renderer.material = new Material(Shader.Find("Diffuse"));

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

	public void AddNeighboringDimple(Neigbor neigbor)
	{
		neigbors.Add(neigbor);
	}
}