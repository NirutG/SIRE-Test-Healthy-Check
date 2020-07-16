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
    }
}
