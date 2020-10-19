using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Camera
    {
        private CameraState state;
        public Vector2 CameraPos { get; set; }
        public Matrix ViewMatrix { get; set; }
        public int ScreenWidth { get; }
        public int ScreenHeight { get; }
        public bool IsMoving { get; set; }

        public Camera(int screenWidth, int screenHeight, Vector2 initialPos)
        {
            this.ScreenHeight = screenHeight;
            this.ScreenWidth = screenWidth;
            this.CameraPos = new Vector2(initialPos.X, initialPos.Y);
            this.ViewMatrix = Matrix.CreateTranslation(new Vector3(-initialPos, 0));
            this.state = new CameraState(this);
        }

        public void MoveUp()
        {
            state.MoveUp();
        }

        public void MoveDown()
        {
            state.MoveDown();
        }

        public void MoveLeft()
        {
            state.MoveLeft();
        }
        public void MoveRight()
        {
            state.MoveRight();
        }

        public void Update()
        {
            state.Update();
        }

    }
}
