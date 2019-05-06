using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Config params
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    //cached references
    Lvl lvl;
    GameStatus gameStatus;

    //Statevariables
    [SerializeField] int timesHit;

    private void Start()
    {
        if ( tag == "Breakable")
        {
            lvl = FindObjectOfType<Lvl>();
            lvl.CountBreakableBlocks();
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( tag == "Breakable")
        {
            HendleHit();

        }
        

    }

    private void ShowNextSprite()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit];
    }

    private void HendleHit()
    {
        timesHit++;
        if (maxHits <= timesHit)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextSprite();
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        TriggerSparklesVFX();
        Destroy(gameObject);
        lvl.BlockDestroyed();
        FindObjectOfType<GameStatus>().AddToScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position , transform.rotation);
        Destroy(sparkles, 2f);

    }

   
}
