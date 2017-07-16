using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : CollisionManager
{

    public CollisionInfo collisions;

    public void Move(Vector2 moveAmount)
    {
        Move(moveAmount, Vector2.zero);
    }

    public void Move(Vector2 moveAmount, Vector2 input)
    {
        ///
        /// Collision Detection
        ///

        transform.Translate(moveAmount);
    }

    public struct CollisionInfo
    {
        public bool above, below;
        public bool left, right;

        public bool climbingSlope;
        public bool descendingSlope;
        public bool slidingDownMaxSlope;

        public float slopeAngle, slopeAngleOld;
        public Vector2 slopeNormal;
        public Vector2 moveAmountOld;
        public int faceDir;
        public bool fallingThroughPlatform;

        public void Reset()
        {
            above = below = false;
            left = right = false;
            climbingSlope = false;
            descendingSlope = false;
            slidingDownMaxSlope = false;
            slopeNormal = Vector2.zero;

            slopeAngleOld = slopeAngle;
            slopeAngle = 0;
        }
    }

}