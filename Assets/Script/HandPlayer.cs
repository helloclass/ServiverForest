using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPlayer : Buki
{
    Animator HandAnimator;

    // Start is called before the first frame update
    void Start()
    {
        HandAnimator = GetComponent<Animator>();

        HandAnimator.SetBool("isWave", false);
        HandAnimator.SetBool("isVictory", false);
        HandAnimator.SetBool("isClap", false);
        HandAnimator.SetBool("isOk", false);
        HandAnimator.SetBool("isThumbDown", false);
        HandAnimator.SetBool("isThumbUp", false);
        HandAnimator.SetBool("isFriendly", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ȭ��, �Ѿ� ���� �Ҹ�ǰ���� ���� �� ����Ͽ�����
    public override void ThrowObjectIsEmpty()
    {

    }
    // ȭ��, �Ѿ� ���� �Ҹ�ǰ���� �������� ��
    public override void ChargingThrowObject()
    {

    }

    public override IEnumerator UpdateAnimator()
    {
        yield return null;
    }
    public override IEnumerator CalcNextClip()
    {
        yield return null;
    }
}
