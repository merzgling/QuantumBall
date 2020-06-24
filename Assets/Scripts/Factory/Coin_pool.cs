using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_pool : Pool
{
    public int number_of_shapes;

    protected bool[][][] shape;
    protected int[] width;
    protected int[] height;
    protected int[] starting_y;

    void set_plus_shape()
    {
        width[0] = 3;
        height[0] = 3;
        starting_y[0] = 11;
        shape[0] = new bool[3][];
        shape[0][0] = new bool[3];
        shape[0][1] = new bool[3];
        shape[0][2] = new bool[3];

        shape[0][0][1] = true;
        shape[0][2][1] = true;
        shape[0][1][0] = true;
        shape[0][1][1] = true;
        shape[0][1][2] = true;
    }

    void set_arrow_shape()
    {
        width[1] = 7;
        height[1] = 5;
        starting_y[1] = 12;
        shape[1] = new bool[height[1]][];
        for (int i = 0; i < height[1]; i++)
            shape[1][i] = new bool[width[1]];

        shape[1][0][4] = true;
        shape[1][1][0] = true;
        shape[1][1][1] = true;
        shape[1][1][2] = true;
        shape[1][1][3] = true;
        shape[1][1][4] = true;
        shape[1][1][5] = true;
        shape[1][2][0] = true;
        shape[1][2][1] = true;
        shape[1][2][2] = true;
        shape[1][2][3] = true;
        shape[1][2][4] = true;
        shape[1][2][5] = true;
        shape[1][2][6] = true;
        shape[1][3][0] = true;
        shape[1][3][1] = true;
        shape[1][3][2] = true;
        shape[1][3][3] = true;
        shape[1][3][4] = true;
        shape[1][3][5] = true;
        shape[1][4][4] = true;
    }


    void set_X_shape()
    {
        width[2] = 9;
        height[2] = 7;
        starting_y[2] = 12;
        shape[2] = new bool[height[2]][];
        for (int i = 0; i < height[2]; i++)
            shape[2][i] = new bool[width[2]];

        shape[2][0][0] = true;
        shape[2][0][1] = true;
        shape[2][1][2] = true;
        shape[2][1][1] = true;
        shape[2][2][2] = true;
        shape[2][2][3] = true;
        shape[2][3][4] = true;
        shape[2][3][3] = true;
        shape[2][4][5] = true;
        shape[2][4][6] = true;
        shape[2][5][7] = true;
        shape[2][5][6] = true;
        shape[2][6][7] = true;
        shape[2][6][8] = true;
        
        shape[2][6][0] = true;
        shape[2][6][1] = true;
        shape[2][5][2] = true;
        shape[2][5][1] = true;
        shape[2][4][2] = true;
        shape[2][4][3] = true;
        shape[2][3][5] = true;
        shape[2][2][6] = true;
        shape[2][2][5] = true;
        shape[2][1][6] = true;
        shape[2][1][7] = true;
        shape[2][0][8] = true;
        shape[2][0][7] = true;
    }

    void set_litte_arrow_shape()
    {
        width[3] = 6;
        height[3] = 9;
        starting_y[3] = 12;
        shape[3] = new bool[height[3]][];
        for (int i = 0; i < height[3]; i++)
            shape[3][i] = new bool[width[3]];

        shape[3][0][0] = true;
        shape[3][0][1] = true;
        shape[3][1][2] = true;
        shape[3][1][1] = true;
        shape[3][2][2] = true;
        shape[3][2][3] = true;
        shape[3][3][4] = true;
        shape[3][3][3] = true;
        shape[3][4][4] = true;
        shape[3][4][5] = true;
        shape[3][5][4] = true;
        shape[3][5][3] = true;
        shape[3][6][2] = true;
        shape[3][6][3] = true;
        shape[3][7][2] = true;
        shape[3][7][1] = true;
        shape[3][8][0] = true;
        shape[3][8][1] = true;
    }

    void set_square_shape()
    {
        width[4] = 6;
        height[4] = 6;
        starting_y[4] = 11;
        shape[4] = new bool[height[4]][];
        for (int i = 0; i < height[4]; i++)
            shape[4][i] = new bool[width[4]];

        for (int i = 0; i < height[4]; i++)
        {
            for (int j = 0; j < width[4]; j++)
            {
                shape[4][i][j] = true;
            }
        }
    }

    public void Awake()
    {
        base.Awake();

        width = new int[number_of_shapes];
        height = new int[number_of_shapes];
        shape = new bool[number_of_shapes][][];
        starting_y = new int[number_of_shapes];


        for (int i = 0; i < number_of_shapes; i++)
        {
            for (int j = 0; j < height[i]; j++)
            {
                for (int k = 0; k < width[i]; k++)
                {
                    shape[i][j][k] = false;
                }
            }
        }

        set_plus_shape();
        set_arrow_shape();
        set_X_shape();
        set_litte_arrow_shape();
        set_square_shape();
    }
    

    public GameObject get(int _shape)
    {
        GameObject new_shape = new GameObject();

        for (int i = 0; i < height[_shape]; i++)
        {
            for (int j = 0; j < width[_shape]; j++)
            {
                if (shape[_shape][i][j])
                {
                    GameObject coin = get();
                    coin.transform.position = new Vector3(j, i);
                    coin.transform.parent = new_shape.transform;
                }
            }
        }

        new_shape.AddComponent<Coin_shape>();
        new_shape.transform.position = new Vector3 (0, starting_y[_shape]);

        return new_shape;
    }
}
