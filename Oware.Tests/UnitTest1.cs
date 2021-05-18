using NUnit.Framework;
using System.Collections.Generic;

namespace Oware.Tests
{
    public class MockScoreHouse: IScoreHouse
    {
        private List<Seed> seedsInHouse;
        public MockScoreHouse() {
            seedsInHouse = new List<Seed>();
        }
        
        public int GetCount() {
            return 1;
        }

        public void AddSeed(Seed seed) {
            seedsInHouse.Add(seed);
        }

        public void Reset() {
            throw new System.NotImplementedException();
        }
    }

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //ARRANGE:
            House h = new House(0, 0);
            for (int i = 0; i < 16; i++)
            {
                h.AddSeedInPot(new Seed());
            }
            //ACT:
            for (int i = 0; i < 16; i++)
            {
                h.ResetHouse(); // <-- THIS IS THE METHOD WE ARE TESTING
            }
            //ASSERT:
            Assert.AreEqual(4, h.GetCount(), "Restores the House to the same state that it was in just after it was initialized, with 4 seeds in the pot.");
        }

        [Test]
        public void AddSeedToScoreHouse()
        {
            //ARRANGE:
            IScoreHouse scoreHouse = new MockScoreHouse();
            Player p = new Player("boB", scoreHouse);
            //ACT:
            p.AddSeedToScoreHouse(new Seed());
            //ASSERT:
            Assert.AreEqual(1, p.GetScore(), "Should add a seed to the scoreHouse");
        }
    }
}