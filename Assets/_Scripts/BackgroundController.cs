using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
    //Public INSTANCE VARIABLES

    public float speed = 5;

    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    private Vector3 _currentPosition;

    // Use this for initialization
    void Start()
    {
        // Make a reference with the Transform Component
        this._transform = gameObject.GetComponent<Transform>();

        // Reset the Ocean Sprite to the Top
        this.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        this._currentPosition = this._transform.position;
        this._currentPosition -= new Vector3( this.speed,0);
        this._transform.position = this._currentPosition;

        if (this._currentPosition.x <= -270)
        {
            this.Reset();
        }
    }

    public void Reset()
    {
        this._transform.position = new Vector3(240f, 0);
    }// reset the background page to start point
}
