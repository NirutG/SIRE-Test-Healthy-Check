using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace SIRE_Test_Healthy_Check
{
    class AutoHand
    {
        AutoItX3 auto = new AutoItX3(); //Decare to use DLL File of AutoIt

        public void mouseMoveAndClick(string ClickSide, int x, int y, int countClick, int speedMove)
        {
            auto.MouseClick(ClickSide, x, y, countClick, speedMove);
        }

        public void mouseScroll(string scrollDir, int scrollCount)
        {
            auto.MouseWheel(scrollDir, scrollCount);
        }

        public void mouseDrag(string ClickSide, int x0, int y0, int x1, int y1, int speed)
        {
            auto.MouseClickDrag(ClickSide, x0, y0, x1, y1, speed);
        }
    }
}
