using UnityEngine;
using System.Collections.Generic;
using System.Text;

public class Board : MonoBehaviour
{

    [SerializeField] private SettingsObject gameData;

    private const string _PLACEHOLDER = "0";

    private string[,] _board;
    private void Start()
    {
        _board = new string[gameData.boardSize,gameData.boardSize];

        PopulateWithZeroes();

        PrintBoard();

        GenerateBoard();

        PrintBoard();
    }

    private void PopulateWithZeroes()
    {
        for (int i = 0; i < gameData.boardSize; i++)
        {
            for(int j = 0; j< gameData.boardSize;j++)
            {
                _board[i,j] = _PLACEHOLDER;
            }
        }
    }

    private void PrintBoard()
    {
        int rowLength = _board.GetLength(0);
        int colLength = _board.GetLength(1);

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                sb.Append(string.Format("{0} ", _board[i, j]));
            }
            sb.Append("\n");   
        }
        Debug.Log(sb.ToString());
    }

    private void GenerateBoard()
    {

        PlaceWords();
    }

    private void PlaceWords()
    {
        foreach (string w in gameData.words)
        {
            var word = w.ToUpper();
            GetPossiblePlacements(word);
            PrintBoard();
        }  
    }

    private void GetPossiblePlacements(string w)
    {
        var visitedPoints = new HashSet<Vector2Int>();
        var wordSize = w.Length;
        bool fit = false;

        for (int i =0;i < gameData.boardSize * gameData.boardSize; i++)
        {
            var newPos = GetRandomValidPointInBoard(w, visitedPoints);

            var posDir = GetPossibleDirections(newPos,wordSize);

            if (posDir.Count == 0)
            {
                visitedPoints.Add(newPos);
                continue;
            }


            //Try to place
            var len = posDir.Count;
            for (int j = 0; j < len; j++)
            {
                var next = Random.Range(0,posDir.Count);
                var endPoint = posDir[next];
                posDir.RemoveAt(next);

                var range = GetLineBetweenPoints(newPos,endPoint);

                if(TryPlaceWord(w,range))
                {
                    fit = true;
                    break;
                }

            }
            
            if (fit)
            {
                break;
            }

        }

        if (!fit)
        {
            throw new UnityException(string.Format("Program was not able to fit the word ({0})",w));
        }
    }

    private List<Vector2Int> GetLineBetweenPoints(Vector2Int p1, Vector2Int p2)
    {
        var range = new List<Vector2Int>();

        if(p1.x == p2.x)
        {
            //P1 to P2 Y
            if (p1.y < p2.y)
            {
                for (int i = 0; i < p2.y-p1.y; i++)
                {
                    range.Add(new Vector2Int(p1.x,p1.y+i));
                }
            }
            //P2 to P1 Y
            else
            {
                for (int i = 0; i < p1.y-p2.y; i++)
                {
                    range.Add(new Vector2Int(p1.x,p2.y+i));
                }
            }
        }
        // Infers Y is equal for both;
        else
        {
            //P1 to P2 X
            if (p1.x < p2.x)
            {
                for (int i = 0; i < p2.x-p1.x; i++)
                {
                    range.Add(new Vector2Int(p1.x+i,p1.y));
                }
            }
            //P2 to P1 X
            else
            {
                for (int i = 0; i < p1.x-p2.x; i++)
                {
                    range.Add(new Vector2Int(p2.x+i,p1.y));
                }
            }
        }


        return range;
    }

    private bool TryPlaceWord(string word, List<Vector2Int> range)
    {

        var replaceble = new List<Vector2Int>();
        
        for (int i =0;i < range.Count; i++)
        {
            var x = range[i].x;
            var y = range[i].y;
            var l = word[i];

            if (_board[x,y].Equals(_PLACEHOLDER))
            {
                _board[x,y] = string.Format("{0}",l);
                replaceble.Add(range[i]);
            }
            else if (!_board[x,y].Equals(l))
            {
                foreach (var r in replaceble)
                {
                    x = r.x;
                    y = r.y;
                    _board[x,y] = _PLACEHOLDER;
                }
                replaceble.Clear();
                return false;
            }
        }
        replaceble.Clear();
        return true;
    }

    private List<Vector2Int> GetPossibleDirections(Vector2Int initialPos, int wSize)
    {
        List<Vector2Int> possibilities = new List<Vector2Int>
            {
                new Vector2Int(initialPos.x,initialPos.y-wSize),
                new Vector2Int(initialPos.x,initialPos.y+wSize),
                new Vector2Int(initialPos.x+wSize,initialPos.y),
                new Vector2Int(initialPos.x-wSize,initialPos.y)
            };

        if (gameData.diagonal)
        {
            //Diagonal
        }

        for(int i = 0; i < possibilities.Count; i++)
        {
            if (!IsInsideBoard(possibilities[i]))
            {
                possibilities.RemoveAt(i);
                i--;
            }
        }

        return possibilities;
    }

    private bool IsInsideBoard(Vector2Int point)
    {
        if (point.x < 0 || point.y < 0 || point.x >= gameData.boardSize || point.y >= gameData.boardSize)
        {
            return false;
        }

        return true;
    }

    private Vector2Int GetRandomValidPointInBoard(string word, HashSet<Vector2Int> visitedPoints)
    {
        string l = "a";
        Vector2Int p = Vector2Int.zero;
        bool found = false;
        for(int i = 0; i < gameData.boardSize * gameData.boardSize; i++)
        {
            p = new Vector2Int(Random.Range(0,gameData.boardSize),Random.Range(0,gameData.boardSize));

            if(visitedPoints.Contains(p))
            {
                continue;
            }
            
            l = _board[p.x,p.y];

            // IF Chosen point is empty, or has the same letter as the first letter of the word we are trying to place.
            if(l.Equals(_PLACEHOLDER) || l.Equals(word[0]))
            {
                found = true;
                break;
            }

        }

        if (!found)
        {
            throw new UnityException(string.Format("Program was not able to find an empty space, try choosing less words."));
        }

        return p; 
    }

}
