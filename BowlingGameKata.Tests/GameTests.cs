using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BowlingGameKata;

namespace BowlingGameKata.Tests
{
    public class GameTests
    {
        Game g;

        public GameTests()
        {
            g = new Game();
        }

        private void rollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.Roll(pins);
            }
        }

        private void rollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }

        private void rollStrike()
        {
            g.Roll(10);
        }

        [Fact]
        public void GutterGame()
        {
            rollMany(20, 0);

            Assert.Equal(0, g.Score());
        }

        [Fact]
        public void AllOnes()
        {
            rollMany(20, 1);

            Assert.Equal(20, g.Score());
        }

        [Fact]
        public void OneSpare()
        {
            rollSpare();
            g.Roll(3);

            rollMany(17, 0);

            Assert.Equal(16, g.Score());
        }

        [Fact]
        public void OneStrike()
        {
            rollStrike();
            g.Roll(3);
            g.Roll(4);

            rollMany(16, 0);

            Assert.Equal(24, g.Score());
        }

        [Fact]
        public void PerfectGame()
        {
            rollMany(12, 10);

            Assert.Equal(300, g.Score());
        }

        [Fact]
        public void AllFives()
        {
            rollMany(21, 5);

            Assert.Equal(150, g.Score());
        }
    }
}
