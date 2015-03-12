using UnityEngine;
using System.Collections;

public class DimplePopulator : MonoBehaviour 
{
	public GameObject BallObject;
	public GameObject DimpleObject;

	//Simple material to draw some basic circles
	float ballRadius;
	GameObject redBallObjectOne;
	GameObject blueBallObjectOne;

	Dimple redDimpleOne;
	Dimple redDimpleTwo;
	Dimple redDimpleThree;
	Dimple blueDimpleOne;
	Dimple blueDimpleTwo;
	Dimple blueDimpleThree;
	Dimple noneDimpleOne;
	Dimple noneDimpleTwo;
	Dimple noneDimpleThree;
	Dimple noneDimpleFour;

	void Start () 
	{
		//Setup dimples and balls
		Vector3 centerPosition = gameObject.transform.position;

		Vector3 redOnePos = 	centerPosition + new Vector3(-1.0f, .05f, .5f);
		Vector3 redTwoPos = 	centerPosition + new Vector3(	 0, .05f, .5f);
		Vector3 redThreePos = 	centerPosition + new Vector3( 1.0f, .05f, .5f);
		Vector3 redFourPos = 	centerPosition + new Vector3(-0.5f, .05f, 1.0f);
		Vector3 redFivePos = 	centerPosition + new Vector3( 0.5f, .05f, 1.0f);
		Vector3 redSixPos = 	centerPosition + new Vector3(	 0, .05f, 1.5f);

		Vector3 noneOnePos =    centerPosition + new Vector3(-1.5f, .05f, 0f);
		Vector3 noneTwoPos =    centerPosition + new Vector3(-.5f, .05f, 0f);
		Vector3 noneThreePos =  centerPosition + new Vector3(.5f, .05f, 0f);
		Vector3 noneFourPos =   centerPosition + new Vector3(1.5f, .05f, 0f);
		
		Vector3 blueOnePos = 	centerPosition + new Vector3(-1.0f, .05f, -.5f);
		Vector3 blueTwoPos = 	centerPosition + new Vector3(	 0, .05f, -.5f);
		Vector3 blueThreePos = 	centerPosition + new Vector3( 1.0f, .05f, -.5f);
		Vector3 blueFourPos = 	centerPosition + new Vector3(-0.5f, .05f, -1.0f);
		Vector3 blueFivePos = 	centerPosition + new Vector3( 0.5f, .05f, -1.0f);
		Vector3 blueSixPos = 	centerPosition + new Vector3(	 0, .05f, -1.5f);
		
		redDimpleOne = (GameObject.Instantiate(DimpleObject) as GameObject).AddComponent<Dimple>();
		redDimpleOne.HomeColor = TeamColor.RED;
		redDimpleOne.Position = redOnePos;

		redDimpleTwo = (GameObject.Instantiate(DimpleObject) as GameObject).AddComponent<Dimple>();
		redDimpleTwo.HomeColor = TeamColor.RED;
		redDimpleTwo.Position = redTwoPos;

		redDimpleThree = (GameObject.Instantiate(DimpleObject) as GameObject).AddComponent<Dimple>();
		redDimpleThree.HomeColor = TeamColor.RED;
		redDimpleThree.Position = redThreePos;
		
		noneDimpleOne = (GameObject.Instantiate(DimpleObject) as GameObject).AddComponent<Dimple>();
		noneDimpleOne.HomeColor = TeamColor.NONE;
		noneDimpleOne.Position = noneOnePos;
		noneDimpleTwo = (GameObject.Instantiate(DimpleObject) as GameObject).AddComponent<Dimple>();
		noneDimpleTwo.HomeColor = TeamColor.NONE;
		noneDimpleTwo.Position = noneTwoPos;
		noneDimpleThree = (GameObject.Instantiate(DimpleObject) as GameObject).AddComponent<Dimple>();
		noneDimpleThree.HomeColor = TeamColor.NONE;
		noneDimpleThree.Position = noneThreePos;
		noneDimpleFour = (GameObject.Instantiate(DimpleObject) as GameObject).AddComponent<Dimple>();
		noneDimpleFour.HomeColor = TeamColor.NONE;
		noneDimpleFour.Position = noneFourPos;
		
		blueDimpleOne = (GameObject.Instantiate(DimpleObject) as GameObject).AddComponent<Dimple>();
		blueDimpleOne.HomeColor = TeamColor.BLUE;
		blueDimpleOne.Position = blueOnePos;
		blueDimpleTwo = (GameObject.Instantiate(DimpleObject) as GameObject).AddComponent<Dimple>();
		blueDimpleTwo.HomeColor = TeamColor.BLUE;
		blueDimpleTwo.Position = blueTwoPos;
		blueDimpleThree = (GameObject.Instantiate(DimpleObject) as GameObject).AddComponent<Dimple>();
		blueDimpleThree.HomeColor = TeamColor.BLUE;
		blueDimpleThree.Position = blueThreePos;

		//Create ball game objects
		redBallObjectOne = GameObject.Instantiate(BallObject) as GameObject;
		blueBallObjectOne = GameObject.Instantiate(BallObject) as GameObject;

		redBallObjectOne.AddComponent<Ball>();
		blueBallObjectOne.AddComponent<Ball>();

		redBallObjectOne.GetComponent<Ball>().BallColor = TeamColor.RED;
		blueBallObjectOne.GetComponent<Ball>().BallColor = TeamColor.BLUE;

		redBallObjectOne.transform.position = blueTwoPos;
		blueBallObjectOne.transform.position = redTwoPos;

		redDimpleTwo.toggleOccupied();
		blueDimpleTwo.toggleOccupied();

		redBallObjectOne.GetComponent<Ball>().currentDimple = redDimpleTwo;
		blueBallObjectOne.GetComponent<Ball>().currentDimple = blueDimpleTwo;

		//Get Ball radius
		ballRadius = BallObject.transform.localScale.x;


		/*neighbor population*/
		redDimpleOne.AddNeighboringDimple(new Neighbor(redDimpleTwo, Direction.RIGHT));
		//////
	}

	void Update(){
		if(redBallObjectOne.GetComponent<Ball>().updateDimple){
			redBallObjectOne.GetComponent<Ball>().updateDimple = false;
			redBallObjectOne.transform.position = redBallObjectOne.GetComponent<Ball>().currentDimple.Position;
		}

		foreach(Neighbor n in redDimpleOne.neighbors){

		}
	}


}
