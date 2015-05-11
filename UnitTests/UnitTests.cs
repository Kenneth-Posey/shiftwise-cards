using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using ShiftwiseTestCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CardValueMustBePositive()
        {
            try
            {
                var badCard = new Card(Card.Face.Clubs, -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "out of range");
                return;
            }

            Assert.Fail("The card constructor did not fail with negative card value.");
        }

        [TestMethod]
        public void CardValueMustBeLessThan14()
        {
            try
            {
                var badCard = new Card(Card.Face.Clubs, int.MaxValue);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "out of range");
                return;
            }

            Assert.Fail("The card constructor did not fail with huge card value.");
        }
    }

    [TestClass]
    public class CardDeckTests
    {
        [TestMethod]
        public void DeckMustContains52Cards()
        {
            var newDeck = CardDeck.BuildDeck();

            Assert.AreEqual(52, newDeck.Count);           
        }

        [TestMethod]
        public void DeckMustContainFourFaces()
        {
            var newDeck = CardDeck.BuildDeck();
            int faceCount = newDeck.Select(x => x.CardFace).Distinct().Count();

            Assert.AreEqual(4, faceCount);
        }

        [TestMethod]
        public void SortDeckShouldEqualStartingDeck()
        {
            var newDeck = CardDeck.BuildDeck();
            var shuffledDeck = CardDeck.ShuffleDeck(newDeck);
            var sortedDeck = CardDeck.SortDeck(shuffledDeck);

            for (int i = 0; i < newDeck.Count; i++)
            {
                Assert.AreEqual(newDeck[i].CardFace, shuffledDeck[i].CardFace);
                Assert.AreEqual(newDeck[i].CardValue, sortedDeck[i].CardValue);
            }
        }
    }

    [TestClass]
    public class ExtensionTests
    {
        [TestMethod]
        public void ShuffleShouldBeTheSameSizeList()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5 };
            var shuffledList = testList.Shuffle(0);

            Assert.AreEqual(testList.Count, shuffledList.Count);
        }

        [TestMethod]
        public void ShuffleShouldBeDeterministic()
        {
            // Incidentally this also tests that the shuffling works
            var knownList = new List<int> { 5, 4, 1, 3, 2 };
            var testList = new List<int> { 1, 2, 3, 4, 5 };
            var shuffledList = testList.Shuffle(0);

            for (int i = 0; i < knownList.Count; i++)
                Assert.AreEqual(knownList[i], shuffledList[i]);
        }        
    }
}
