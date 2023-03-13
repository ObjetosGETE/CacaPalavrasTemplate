using UnityEngine;
using System.Collections.Generic;
using System.Text;

public class BoardGenerator : MonoBehaviour
{

    [SerializeField] private SettingsObject gameData;
    [SerializeField] private BoardObject boardData;

    private const string Placeholder = "0";

    private string[,] _board;
    private Dictionary<string,float> _letterProbability = new()
    {
        {"A",14.63f},
        {"E",12.57f},
        {"O",10.73f},
        {"S",7.81f},
        {"R",6.53f},
        {"I",6.18f},
        {"N",5.05f},
        {"D",4.99f},
        {"M",4.74f},
        {"U",4.63f},
        {"T",4.34f},
        {"C",3.88f},
        {"L",2.78f},
        {"P",2.52f},
        {"V",1.67f},
        {"G",1.30f},
        {"H",1.28f},
        {"Q",1.20f},
        {"B",1.04f},
        {"F",1.02f},
        {"Z",0.47f},
        {"J",0.40f},
        {"X",0.21f},
        {"K",0.02f},
        {"W",0.01f},
        {"Y",0.01f},


    };

    private void Awake()
    {
        _board = new string[gameData.boardSize,gameData.boardSize];

        PopulateWithZeroes();

        //PrintBoard();

        PlaceWords();

        //PrintBoard();

        FillBlanksRandomly();

        //PrintBoard();

        boardData.Board = _board;

    }

    public string[,] GetBoard()
    {
        return _board;
    }

    private void FillBlanksRandomly()
    {
        for (int i = 0; i < gameData.boardSize; i++)
        {
            for(int j = 0; j< gameData.boardSize;j++)
            {
                if(_board[i,j].Equals(Placeholder))
                {
                    float prob = Random.Range(0,100f);

                    foreach (var l in _letterProbability.Keys)
                    {
                        if (prob < _letterProbability[l])
                        {
                            _board[i,j] = l;
                            break;
                        }
                        prob -= _letterProbability[l];
                    }

                }
            }
        }
    }

    private void PopulateWithZeroes()
    {
        for (int i = 0; i < gameData.boardSize; i++)
        {
            for(int j = 0; j< gameData.boardSize;j++)
            {
                _board[i,j] = Placeholder;
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
    private void PlaceWords()
    {
        foreach (string w in gameData.words)
        {
            var word = w.ToUpper();
            GetPossiblePlacements(word);
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

                var range = BoardObject.GetLineBetweenPoints(newPos,endPoint);

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

    private bool TryPlaceWord(string word, List<Vector2Int> range)
    {
        Debug.Log(string.Format("A palavra é {0} tam {2}, e o tamanho do range é {1}.",word,range.Count,word.Length));
        var replaceble = new List<Vector2Int>();
        
        for (int i =0;i < range.Count; i++)
        {
            var x = range[i].x;
            var y = range[i].y;
            var l = char.ToString(word[i]);

            if (_board[x,y].Equals(Placeholder))
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
                    _board[x,y] = Placeholder;
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
                new(initialPos.x,initialPos.y-wSize+1),
                new(initialPos.x,initialPos.y+wSize-1),
                new(initialPos.x+wSize-1,initialPos.y),
                new(initialPos.x-wSize+1,initialPos.y)
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
            if(l.Equals(Placeholder) || l.Equals(word[0]))
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
