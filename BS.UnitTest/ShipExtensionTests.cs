﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using BS;

namespace Tests
{
    [TestFixture]
    public class ShipExtensionTests
    {

        [Test]
        public void GivenBattelship_ShouldGetBattelshipCell()
        {
            Assert.That(Ship.Battleship .ToCell(), Is.EqualTo(Cell.Battleship ));
        }

        public void GivenDestroyer_ShouldGetDestroyerCell()
        {
            Assert.That(Ship.Destroyer.ToCell(), Is.EqualTo(Cell.Destroyer));
        }
    }
}