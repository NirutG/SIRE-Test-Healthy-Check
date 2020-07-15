using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace Test_MouseMoveThenClick
{
    class AutoIt
    {
        AutoItX3 auto = new AutoItX3();

        public void mClick(string ClickSide, int x, int y, int manyClick, int Speed)
        {
            auto.MouseClick(ClickSide, x, y, manyClick, Speed);            
        }
        public void mScroll(string scrollDir, int scrollCount)
        {
            auto.MouseWheel(scrollDir, scrollCount);
        }
    }
}
