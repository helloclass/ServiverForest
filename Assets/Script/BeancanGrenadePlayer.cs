using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeancanGrenadePlayer : Buki
{
    public GameObject ThrowPositionObject;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isThrowHold = true;
            BodyAnimator.SetBool("IsThrow", false);

            BodyAnimator.SetBool("IsThrowHold", true);
        }
    }

    // ȭ��, �Ѿ� ���� �Ҹ�ǰ���� ���� �� ����Ͽ�����
    public override void ThrowObjectIsEmpty()
    {
        HandPlayer.GetComponent<PlayerController>().ThrowedHandleObject();
    }

    // ȭ��, �Ѿ� ���� �Ҹ�ǰ���� �������� ��
    public override void ChargingThrowObject()
    {

    }

    public override IEnumerator CalcNextClip()
    {
        yield return new WaitForSeconds(0.1f);
    }
    public override IEnumerator UpdateAnimator()
    {
        while (true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (isThrowHold)
                {
                    isThrowHold = false;
                    isThrow = true;
                    BodyAnimator.SetBool("IsThrowHold", false);
                    BodyAnimator.SetBool("IsThrow", true);
                }
            }

            yield return null;
        }
    }

    public void ThrowGrenade()
    {
        GameObject ThrowObject = Instantiate(HandleThrowBody, ThrowPositionObject.transform);
        ThrowObject.SetActive(true);
        ThrowObject.transform.parent = null;

        ThrowObject.GetComponent<Beancan>().Fire(transform.forward);
    }

    public void ThrowEnd()
    {
        ThrowObjectIsEmpty();
    }
}
