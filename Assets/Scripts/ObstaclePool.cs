using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool
{
    private Obstacle[] obstacles = new Obstacle[15];

    public Obstacle TakeObstacle()
    {
        if (obstacles.Length > 0)
        {
            var item = obstacles[0];
            return item;
        }
        //instansiate
        
        return null;
    }

    public void ReleaseObstacle(Obstacle obstacleToRelese)
    {
        //obstacles.Add(obstacleToRelese);
        obstacleToRelese.Reset();
    }


}
