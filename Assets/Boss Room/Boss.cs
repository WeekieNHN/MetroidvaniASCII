using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    

    [Header("Hearts")]
    public GameObject[] hearts;

    [Header("Opening Text")]
    public GameObject threatenText;

    [Header("Moving Platform")]
    public MovingPlatform movingPlatform;

    [Header("Beam")]
    public GameObject beamObject;
    public float beamLength = 0.3f;

    [Header ("Reset")]
    public Transform button1Pos;
    public Transform button2Pos;
    public GameObject locks;
    public GameObject buttonPrefab;


    private void Awake () 
    {
        if (movingPlatform) movingPlatform.enabled = false;
    }

    private bool IsWoke = false;
    public void WakeUp ()
    {
        IsWoke = true;

        if (movingPlatform) movingPlatform.enabled = true;

        Destroy(threatenText, 3f);
    }

    public void SubtractHeart () 
    {
        for (int i = 0; i < hearts.Length; i += 1)
        {
            // If we've already removed this heart, skip
            if (hearts[i] == null) continue;

            Destroy(hearts[i]);

            hearts[i] = null;

            StartCoroutine(Beam());

            return;
        }
    }

    private void FixedUpdate() 
    {
        // Check if we've killed the boss
        if (IsWoke && IsBossKilled()) GameOver(); 
    }

    private bool IsBossKilled ()
    {
        for (int i = 0; i < hearts.Length; i += 1)
        {
            // If we've already removed this heart, skip
            if (hearts[i] == null) continue;
            // if we have a heart
            return false;
        }

        return true;
    }

    private IEnumerator Beam ()
    {
        // Activate the object
        beamObject.SetActive(true);

        // Wait for the specified duration
        yield return new WaitForSeconds(beamLength);

        // Deactivate the object
        beamObject.SetActive(false);

        ResetCycle();
    }

    private void ResetCycle ()
    {
        // Reset btn 1
        foreach (Transform go in button1Pos.transform) Destroy(go.gameObject);
        BigButton btn1 = Instantiate(buttonPrefab, button1Pos).GetComponent<BigButton>();
        btn1.transform.localPosition = Vector3.zero;
        btn1.transform.localScale = Vector3.one;
        btn1.OnPress.AddListener(delegate { locks.SetActive(false); } );
        // Reset btn 2
        foreach (Transform go in button2Pos.transform) Destroy(go.gameObject);
        BigButton btn2 = Instantiate(buttonPrefab, button2Pos).GetComponent<BigButton>();
        btn2.transform.localPosition = Vector3.zero;
        btn2.transform.localScale = Vector3.one;
        btn2.OnPress.AddListener(SubtractHeart);
        // Reset btn 2 lock
        locks.SetActive(true);
    }

    bool over = false;
    private void GameOver ()
    {
        if (over) return;

        over = true;

        GameOverManager.GameOver();

        Destroy(gameObject);
    }

}
