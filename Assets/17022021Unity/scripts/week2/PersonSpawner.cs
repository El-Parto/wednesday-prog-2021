using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// the aim of this script should be assign names with an Array, 

public class PersonSpawner : MonoBehaviour
{ 
    [SerializeField]
    private string[] names; // list of names we're displaying "[]" is an array. Not to be confused with a list.
    [SerializeField]
    private GameObject personPrefab; // <- - the prefab we're copying

    // Start is called before the first frame update
    void Start()
    {
        /* a different type of loop we're going to use. 
         The for loop. for  = iterating over a whole bunch of things
        While = has condition
        for loop has 3 components.
        first value
        operator
        rate
        or for (for short)*/
        for ( int i = 0; i <  names.Length; i++) // if i is less than names.Length, then increment I

        /* First value " int i = 0 */  /*operator "names.Length;" what is determining if it's running /* rate */
        {
            GameObject newPerson = Instantiate(personPrefab); //"GameObject" is a new class type "gameObject" means we're accessing it.
            newPerson.transform.position = new Vector3(-6 + (i * 3), 0, 0);
            
            //changing the names of the cubes (the text above them)
            Cube personCube = newPerson.GetComponent<Cube>(); //where "Cube" is that is referenced from "public class Cube" in "Cube.cs"
            personCube.nameText.text = names[i];

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
