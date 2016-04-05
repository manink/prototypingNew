using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

    public static GameObject trig1 = null;
    
    //Bools that let you know if you have collected all checkpoints for a path
    public bool pathOneRevealed = false;
    public bool pathTwoRevealed = false;

    //Lists of every checkpoint in the path
    public ArrayList pathTwo = new ArrayList();
    public ArrayList pathOne = new ArrayList();

    //here our map covers that we disable to reveal the map
    public GameObject hider1 = null;
    public GameObject hider2 = null;
    public GameObject hider3 = null;
    public GameObject hider4 = null;

    // Use this for initialization
    void Start () {
        //Adds all the checkpoints to each of the lists
        for (int i = 0; i < 5; i++)
        {
            pathOne.Add(false);
            print("pathOne Add");
            //pathTwo.Add(false);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        //if(myColl.tag == "Player")
        //{
        //    trig1.SetActive(false);
            //print("triggered");
        //}

        if (other.tag == "Path One")
        {
            //checks which collider and turns the bool that corrosponds to it in the last to true
            switch (other.name)
            {
                case "Zone 1":
                    pathOne[0] = true;
                    print("first one");
                    break;
                case "Zone 2":
                    pathOne[1] = true;
                    print("second one");
                    break;
                case "Zone 3":
                    pathOne[2] = true;
                    print("third one");
                    break;
                case "Zone 4":
                    pathOne[3] = true;
                    print("four one");
                    break;
                case "Zone 5":
                    pathOne[4] = true;
                    print("five one");
                    break;
            }

            //checks to see if all of the checkpoints have been turned to true
            if (pathOne.Contains(false))
            {
                pathOneRevealed = false;
            }
            else
            {
                pathOneRevealed = true;
                Debug.Log("PATH ONE REVEALED");
                //hider1.GetComponent<Plane>();
                hider4.SetActive(false);
            }
        }

        //repeat of abouve part for path two
        else if (other.tag == "Path Two")
        {
            switch (other.name)
            {
                case "Collider_1":
                    pathTwo[0] = true;
                    break;
                case "Collider_2":
                    pathTwo[1] = true;
                    break;
                case "Collider_3":
                    pathTwo[2] = true;
                    break;
                case "Collider_4":
                    pathTwo[3] = true;
                    print("collider 4 triggered");
                    break;
                case "Collider_5":
                    pathTwo[4] = true;
                    break;
            }

            if (pathTwo.Contains(false))
            {
                pathTwoRevealed = false;
            }
            else
            {
                pathTwoRevealed = true;

                Debug.Log("PATH TWO REVEALED");
            }
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
