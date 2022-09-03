using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monsters, IHealth, IBattle
{
    private Transform hitBox;
    Collider2D me;
    AudioSource audioSource;
    QuestPanel questPanel;


    protected override void Awake()
    {
        base.Awake();
        questPanel = GetComponent<QuestPanel>();
        hitBox = transform.GetChild(1);
        audioSource = GetComponent<AudioSource>();
    }

    protected override void SpriteFlip()
    {
        trackDirection = target.position - this.transform.position;
        var cross = Vector3.Cross(trackDirection, this.transform.up);
        if (Vector3.Dot(cross, transform.forward) < 0)
        {   // 왼쪽
            sprite.flipX = true;
            hitBox.localPosition = new Vector3(-1.79f, 0f);
        }
        else
        {   // 오른쪽
            sprite.flipX = false;
            hitBox.localPosition = new Vector3(1.79f, 0f);
        }
    }

    public void PlayDieSound()
    {
        audioSource.PlayOneShot(SoundManager.Inst.clips[(byte)SoundID.GoblinDie].clip, 0.5f);
    }

    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(SoundManager.Inst.clips[(byte)SoundID.GoblinAttack].clip, 0.5f);
    }

    public void PlayGetHitSound()
    {
        audioSource.PlayOneShot(SoundManager.Inst.clips[(byte)SoundID.GoblinGetHit].clip, 0.5f);
    }

    protected override void Die()
    {
        if (!isDying)
        {
            QuestManager.CheckKillCount();
            anim.SetTrigger("onDie");
            currentSpeed = 0;
            StartCoroutine(DisableMonster());
            MonsterManager.ReturnPooledMonster(
                MonsterManager.PooledMonster[MonsterManager.Inst.GoblinID], this.gameObject);
        }
    }

    
}
