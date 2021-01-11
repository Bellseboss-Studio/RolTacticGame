using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class MapTDD
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CreateChestMap_whitHeightAndWitd()
        {
            //arange
            var readFile = new ReadMapFromDevice();
            Map map = new Map("cheest",readFile);

            //act
            int heigth = map.Heigth;
            int width = map.Width;

            //assert
            Assert.AreEqual(8, heigth,"the chest map are 8 rows");
            Assert.AreEqual(8, width, "the chest map are 8 columns");
        }
    }
}
