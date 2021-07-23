
using System.Collections.Generic;
[System.Serializable]
public class Question 
{
   public string _id;
   public string Label;
   public string QuestionTxt;
   public string Creator;
   public string Visibility;
   
   public List<Options> OptionsList = new List<Options>();
}
