using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshRenderer))] // wont be able to remove this in unity without removing this line. Manually.

public class Cube : MonoBehaviour // mono behaviour means it's a script that can be attached to a game object.
{
    public TextMesh nameText;

    // Start is called before the first frame update

    /*Going to forcibly changing the colour, so we need a mesh renderer.
     */
    void Start()
    {
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>(); // calling a function? you need " ( ) "
        renderer.material.color = Random.ColorHSV(0, 1, 1, 1, 1, 1); //when the script starts, the cube will have a random colour

    }
}