using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public class CameraState
    {
        enum MovingDirection
        {
            IDLE, UP, DOWN, LEFT, RIGHT
        }
        private Camera camera;
        private MovingDirection movingDirection;
        private int movingLength = 0;
        private int currentDistance = 0;
        private Vector2 position;
        private Vector2 currentPos;
        public CameraState(Camera camera)
        {
            this.camera = camera;
            this.movingDirection = MovingDirection.IDLE;
            camera.IsMoving = false;
            this.currentPos = camera.CameraPos;
        }

        public void Idle()
        {
            camera.IsMoving = false;
            movingDirection = MovingDirection.IDLE;
        }

        public void MoveLeft()
        {
            camera.IsMoving = true;
            movingDirection = MovingDirection.LEFT;
            movingLength = camera.ScreenWidth;
        }

        public void MoveRight()
        {
            camera.IsMoving = true;
            movingDirection = MovingDirection.RIGHT;
            movingLength = camera.ScreenWidth;
        }

        public void MoveUp()
        {
            camera.IsMoving = true;
            movingDirection = MovingDirection.UP;
            movingLength = camera.ScreenHeight;
        }

        public void MoveDown()
        {
            camera.IsMoving = true;
            movingDirection = MovingDirection.DOWN;
            movingLength = camera.ScreenHeight;
        }
        public void Update()
        {
            if (this.camera.IsMoving)
            {
                currentDistance += 10;
                switch (movingDirection)
                {
                    case MovingDirection.LEFT:
                        position = new Vector2(-(currentPos.X - currentDistance), -currentPos.Y);
                        camera.ViewMatrix = Matrix.CreateTranslation(new Vector3(position, 0));
                        break;
                    case MovingDirection.RIGHT:
                        position = new Vector2(-(currentPos.X + currentDistance), -currentPos.Y);
                        camera.ViewMatrix = Matrix.CreateTranslation(new Vector3(position, 0));
                        break;
                    case MovingDirection.UP:
                        position = new Vector2(-currentPos.X, -(currentPos.Y - currentDistance));
                        camera.ViewMatrix = Matrix.CreateTranslation(new Vector3(position, 0));
                        break;
                    case MovingDirection.DOWN:
                        position = new Vector2(-currentPos.X, -(currentPos.Y + currentDistance));
                        camera.ViewMatrix = Matrix.CreateTranslation(new Vector3(position, 0));
                        break;
                    default:
                        break;
                }
                if (currentDistance >= movingLength)
                {
                    currentDistance = 0;
                    this.Idle();
                    currentPos = new Vector2(-position.X, -position.Y);
                }
            }
        }
    }
}
