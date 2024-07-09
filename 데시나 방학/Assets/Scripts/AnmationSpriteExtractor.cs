using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;              //������ ���̺귯�� ����

public class SpriteInfo
{
    public float time;                          //��������Ʈ�� ���Ǵ� �ð�
    public string spriteName;                   //��������Ʈ �̸�
}

public class AnmationSpriteExtractor : EditorWindow
{
    private AnimationClip animationClip;                                                //���õ� �ִϸ��̼� Ŭ��
    private List<SpriteInfo> spriteInfoList = new List<SpriteInfo>();                   //��������Ʈ ������ ������ ����Ʈ

    [MenuItem("Winow/Animation Sprite Extractor")]                                      //�޴��� Animation Sprite Extractor �׸��� �߰�

    public static void Showindow()
    {
        GetWindow<AnmationSpriteExtractor>("AnmationSpriteExtractor");                  //������ â ����
    }

    private void OnGUI()
    {
        GUILayout.Label("Extract Sprites Info form Animtaion Clip" , EditorStyles.boldLabel);   //������ â�� ���̺�� �ִϸ��̼� Ŭ�� �ʵ� ǥ��

        //����ڰ� �巡�� �� ������� �ִϸ��̼� Ŭ���� ������ �� �ְ� ����
        animationClip = EditorGUILayout.ObjectField("Animation Clip" , animationClip, typeof(AnimationClip), false) as AnimationClip;
    
        if(animationClip != null)           //�ִϸ��̼� Ŭ���� ������ ���
        {
            if(GUILayout.Button("Extract Sprites Info"))            //��ư�� Ŭ�� �Ǹ� ��������Ʈ ������ ����
            {
                ExtractSpritesInfo(animationClip);
            }

            if(spriteInfoList.Count > 0)                            //��������Ʈ ���� ����Ʈ�� ������� ���� ���
            {
                GUILayout.Label("Sprites Info :", EditorStyles.boldLabel);
                foreach(var spriteInfo in spriteInfoList)
                {
                    GUILayout.BeginHorizontal();                                            //���� ���̾ƿ� �ð�
                    GUILayout.Label("Time:", GUILayout.Width(50));                          //Time ���̺�
                    GUILayout.Label(spriteInfo.time.ToString(), GUILayout.Width(100));      //�ð� ��
                    GUILayout.Label("Sprite : " , GUILayout.Width(50));                     //Sprite ���̺�
                    GUILayout.Label(spriteInfo.spriteName, GUILayout.Width(200));           //��������Ʈ �̸�
                    GUILayout.EndHorizontal();                                              //���� ���̾ƿ� ����
                }
            }
        }
    }

    private void ExtractSpritesInfo(AnimationClip clip)         //��������Ʈ ������ ���� �ϴ� �Լ�
    {
        spriteInfoList.Clear();                                 //���� ��������Ʈ ���� �ʱ�ȭ
        var bindings = AnimationUtility.GetObjectReferenceCurveBindings(clip);      //�ִϸ��̼� Ŭ������ Object Reference Curve ���ε��� ������
    
        foreach (var binding in bindings)
        {
            if(binding.propertyName.Contains("Sprite"))                 //���ε��� ������Ƽ�� ��������Ʈ�� ���
            {
                var Keyframes = AnimationUtility.GetObjectReferenceCurve(clip, binding);

                foreach(var keyframe in Keyframes)
                {
                    Sprite spriite = keyframe.value as Sprite;          //Ű������ ���� �������̵�� ĳ����
                    if(spriite != null)
                    {
                        spriteInfoList.Add(new SpriteInfo { time = keyframe.time, spriteName = sprite.name });          //��������Ʈ ������ ����Ʈ�� �߰�
                    }
                }
            }
        }
    }
}
