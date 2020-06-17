using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health_Script : MonoBehaviour
{
    public float StartingHealth = 100;
    public float CurrentHealth = 0;

    public Slider HealthBar;
    public GameObject loseMenu;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = StartingHealth;
        StartCoroutine(HealthDecay());
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = Mathf.Lerp(HealthBar.value, CurrentHealth / StartingHealth, Time.deltaTime * 10);
        //CurrentHealth = Mathf.Lerp(CurrentHealth, StartingHealth, Time.deltaTime);
        //HealthBar.value = CurrentHealth;

        if(CurrentHealth <= 0)
        {
            loseMenu.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator HealthDecay()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            CurrentHealth -= 5;
        }
    }

}
