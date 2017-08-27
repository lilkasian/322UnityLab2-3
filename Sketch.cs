using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sketch : MonoBehaviour {

    public GameObject myPreFab;
    public Color lerpedColor = Color.white;
    public float timer = 0.0f;

	// Use this for initialization
	void Start () {

        int totalCubes = 30;
        float totalDistance = 2.9f;

        for (int i = 0; i < totalCubes; i++)
        {
            float perc = i / (float)totalCubes;

            float sin = Mathf.Sin(perc * Mathf.PI/2);

            float x = 1.8f + sin * totalDistance;
            float y = 5.0f;
            float z = 0.0f;

            var newCube = (GameObject)Instantiate(myPreFab, new Vector3(x, y, z), Quaternion.identity);
            newCube.GetComponent<CubeScript>().SetSize(0.45f * (1.0f - perc));
            newCube.GetComponent<CubeScript>().rotateSpeed = 0.2f + perc*4.0f;

            //Makes All Cubes Blue
            //newCube.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
        }

    }   
	
	// Update is called once per frame
	void Update () {
        //lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        timer += Time.deltaTime;

        if (timer >= 1.0f)//change the float value here to change how long it takes to switch.
        {
            // pick a random color
            Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            // apply it on current object's material
            myPreFab.GetComponent<Renderer>().material.color = newColor;
            timer = 0;
        }

    }


}
