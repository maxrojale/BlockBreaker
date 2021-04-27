using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockDestroyedSound;
    [SerializeField] GameObject blocksparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    int timesHit;
    Level level;
    GameSession gamestatus;

    private void Start()
    {
        gamestatus = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();
    }

    private void HandleHit()
    {
        int maxHits = hitSprites.Length +1;
        if (tag == "Breakable")
        {
            timesHit++;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }

        }
    }

    private void ShowNextHitSprite()
    {
        if (hitSprites != null)
        {
            int spriteIndex = timesHit - 1;
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("block sprite is missing" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockDestroyedSound, Camera.main.transform.position);
        TriggerSparkesVFX();
        level.RemoveBreakabeBlock();
        gamestatus.AddToScore();
        Destroy(gameObject);
    }

    private void TriggerSparkesVFX()
    {
        GameObject sparkles = Instantiate(blocksparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
