﻿//author: adrian
//helpers:
//last_checked: futz@20.11.2015

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

namespace WcfServiceLibrary.Tests.DALTests
{
    [TestClass]
    public class DbLanguagesTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void DAL_ILanguage_InsertLanguage_InsertLanguage_LanguageIsInserted()
        {
            //arrange
            int languageId = 1;
            string languageName = "English";
            Language language_m1 = new Language(
                languageId,
                languageName
                );
            ILanguages _DbLanguages = new DbLanguages();

            //act
            int result = _DbLanguages.insertLanguage(language_m1);

            //assert
            Assert.AreEqual(1, result, "language not inserted into the database");
        }
    }
}
