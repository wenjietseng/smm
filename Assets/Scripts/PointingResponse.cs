using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingResponse : MonoBehaviour
{
    private OVRInput.Controller trackedObj; 
    public GameObject laserPrefab; // The laser prefab
    private GameObject laser; // A reference to the spawned laser
    private Transform laserTransform; // The transform component of the laser for ease of use
    private Vector3 hitPoint; // Point where the raycast hits
    public GameObject answerReticlePrefab;
    private GameObject answerReticle;
    public LayerMask triangleCompletionMask;
    
    private Transform answerReticleTransform;
    public const OVRInput.Button AnswerButton = OVRInput.Button.One;
    // Reticle actually being used and its transform
    private GameObject reticle;
    private Transform reticleTransform;
    // References to each of the markers
    private GameObject[] markers = new GameObject[3];

    // Whether the reticle was locked on a marker in the last cycle
    private bool snapped_on = false;
    private bool rotated_on = false;
    // Needed for time
    float currentTime;

    private bool shouldAnswer; // True if there's a valid answer target
    void Awake()
    {
        trackedObj = this.GetComponent<OVRControllerHelper>().m_controller;
    }

    void Start()
    {
        // Intialize laser
        laser = GameObject.Instantiate(laserPrefab);
        laserTransform = laser.transform;

        // Create instances of reticles
        answerReticle = GameObject.Instantiate(answerReticlePrefab);
        answerReticleTransform = answerReticle.transform;

        // Get markers
        markers[0] = GameObject.Find("StartMarker");
        markers[1] = GameObject.Find("FirstMarker");
        markers[2] = GameObject.Find("SecondMarker");


        // landmarks setup should be another script

        // Record a start time for the trial
        currentTime = Time.time;
        // System.IO.File.AppendAllText(GameSettings.track_file,
                                    //  "Start time:" + Time.time + "\r\n");

        // Hide reticles and laser
        laser.SetActive(false);
        answerReticle.SetActive(false);
    }


    void Update()
    {
        OVRInput.Update();      

        // Debug.Log(OVRInput.GetDown(AnswerButton, trackedObj)); // is this for selection?
        bool answerInitiated = (GetCurrentMarker() == null);

        if (answerInitiated)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100, triangleCompletionMask)) // mask: triangle completion and SMM landmarks pointing
            {
                // point the laser
                hitPoint = hit.point;
                ShowLaser(hit);
                                
                //Show teleport reticle
                answerReticle.SetActive(true);
                answerReticleTransform.position = hitPoint + new Vector3(0, 0.01f, 0);

                // If you're in this block, you hit something with the triangle completion mask
                shouldAnswer = true;
            }
            else
            {
                // If you didn't hit the somthing with the triangle completion mask, turn off the laser
                laser.SetActive(false);
                answerReticle.SetActive(false);
                shouldAnswer = false;
            }
        }

        if (OVRInput.GetUp(AnswerButton, trackedObj) && shouldAnswer)
        {
            // Writes the response to a file
            // System.IO.File.AppendAllText(GameSettings.response_file, "Response: " +
            //                                                          answerReticleTransform.position.ToString() +
            //                                                          " Time: " + Time.time + "\r\n");
            answerReticle.SetActive(false);
            laser.SetActive(false);
            
            Debug.Log("State:" + "next trial?");

            // Display a configuration-specific popup message for the experimenter
            // TODO: Could have environment-specific objects to generate messages
            // if (GameSettings.env == "Training")
                // Debug.Log(GameSettings.navMode.ToString() + " interface training complete. Press Space to re-run, or Escape to return to menu.",
                //           GameSettings.navMode.ToString() + " Training Complete");
            // else
                // Debug.Log(GameSettings.navMode.ToString() + " interface trial " + GameSettings.current_trial.ToString() + "/" + 
                //           GameSettings.trial_count.ToString() + " complete. Press Space to continue, Backspace to redo, or Escape to return to menu.",
                //           GameSettings.navMode.ToString() + " " + GameSettings.current_trial.ToString() + "/" + GameSettings.trial_count.ToString() + " Complete");
        }
    }

    private GameObject GetCurrentMarker()
    {
        for (int i = 0; i < markers.Length; i++)
        {
            if (markers[i].activeSelf)
            {
                return markers[i];
            }
        }

        return null;
    }

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true); //Show the laser
        laserTransform.position = Vector3.Lerp(this.transform.position, hitPoint, .5f); // Move laser to the middle between the controller and the position the raycast hit
        laserTransform.LookAt(hitPoint); // Rotate laser facing the hit point
        laserTransform.localScale = new Vector3(
            laserTransform.localScale.x,
            laserTransform.localScale.y,
            Vector3.Distance(this.transform.position, hitPoint)
        ); // Scale laser so it fits exactly between the controller & the hit point
    }

}
