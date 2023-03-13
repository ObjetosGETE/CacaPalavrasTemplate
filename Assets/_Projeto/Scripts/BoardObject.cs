using UnityEngine;
using System.Collections.Generic;
using System.Text;


[CreateAssetMenu(fileName = "BoardData", menuName = "ScriptableObjects/BoardData")]
public class BoardObject : ScriptableObject
{

    public string[,] Board;

    public static List<Vector2Int> GetLineBetweenPoints(Vector2Int p1, Vector2Int p2)
    {
        var range = new List<Vector2Int>();

        if(p1.x == p2.x)
        {
            //P1 to P2 Y
            if (p1.y < p2.y)
            {
                for (int i = p1.y; i <= p2.y; i++)
                {
                    range.Add(new Vector2Int(p1.x,i));
                }
            }
            //P2 to P1 Y
            else
            {
                for (int i = p2.y; i <= p1.y; i++)
                {
                    range.Add(new Vector2Int(p1.x,i));
                }
            }
        }
        // Infers Y is equal for both;
        else
        {
            //P1 to P2 X
            if (p1.x < p2.x)
            {
                for (int i = p1.x; i <= p2.x; i++)
                {
                    range.Add(new Vector2Int(i,p1.y));
                }
            }
            //P2 to P1 X
            else
            {
                for (int i = p2.x; i <= p1.x; i++)
                {
                    range.Add(new Vector2Int(i,p1.y));
                }
            }
        }
        
        
        return range;
    }

}
