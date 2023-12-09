using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Textos
{
    [TextArea(5,10)]
    public string text;
}
[CreateAssetMenu(fileName ="TextData", menuName="ScriptableObject/TalkScript", order = 1)]
public class TextData : ScriptableObject
{
   public List<Textos> talkScript;
}
