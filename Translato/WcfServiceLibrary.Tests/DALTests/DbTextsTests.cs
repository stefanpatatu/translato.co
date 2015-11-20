﻿//author: adrian
//helpers:
//last_checked: futz@20.11.2015 - to do

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

namespace WcfServiceLibrary.Tests.DALTests
{
    [TestClass]
    public class DbTextsTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void DAL_IText_InsertText_InsertText_TextIsInserted()
        {
            //arrange
            int textId = 1;
            string textData = "some long text here to be translated";
            Text text_m1 = new Text(
                textId,
                textData
                );
            ITexts _DbTexts = new DbTexts();

            //act
            int result = _DbTexts.insertText(text_m1);

            //assert
            Assert.AreEqual(1, result, "text not inserted into the database");
        }
    }
}
