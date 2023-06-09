
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum ChessPieceType
{
    None=0,
    Pawn=1,
    Rook=2,
    Knight=3,
    Bishop=4,
    Queen=5,
    King=6
}
public class Chesspiece : MonoBehaviour
{
    public int team;
    public int currentX;
    public int currentY;    
    public ChessPieceType type;

    private Vector3 desiredPosition;
    private Vector3 desiredScale=Vector3.one;

    private void Start()
    {
        transform.rotation = Quaternion.Euler((team == 0) ? new Vector3(-90, -90, 0) : new Vector3(-90, 90, 0)) ;
    }

    private void Update()
    {
       /* if (type == ChessPieceType.Pawn)
        {
            Vector3 desiredPosition = new Vector3(0, 1, 0);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 20);



        }*/

        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 20);
        transform.localScale = Vector3.Lerp(transform.localScale, desiredScale, Time.deltaTime * 20);
    }
    public virtual List<Vector2Int> GetAvailableMoves(ref Chesspiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();
        r.Add(new Vector2Int(3, 3));
        r.Add(new Vector2Int(3, 4));
        r.Add(new Vector2Int(4, 3));
        r.Add(new Vector2Int(4, 4));


        return r;

    }
    public virtual void SetPosition(Vector3 position, bool force = false)
    {
    //    if(type==ChessPieceType.Pawn)
    //     {
            
    //         desiredPosition = position + new Vector3(0, 1, 0);
    //         if (force)
    //             transform.position = desiredPosition;
    //     }
    //     else
    //     {
    //         desiredPosition = position;
    //         if (force)
    //             transform.position = desiredPosition;
    //     }

     desiredPosition = position;
            if (force)
                transform.position = desiredPosition;
       


    }
    public virtual void SetScale(Vector3 scale, bool force = false)
    {
        desiredScale = scale;
        if (force)
            transform.localScale = desiredScale;


    }
    
}
