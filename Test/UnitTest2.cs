using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgengry;

namespace Test
{
    [TestClass]
    public class UnitTest2
    {
        Book b1, b2, b3;
        Amulet a11, a12, a13;
        Course c111, c112;
        //CourseRepository courses = new CourseRepository();
        //BookRepository books = new BookRepository();
        //AmuletRepository amulets = new AmuletRepository();
        //MerchandiseRepository merchandises = new MerchandiseRepository();
        ValuableRepository repo = new ValuableRepository();


        [TestInitialize]
        public void Init()
        {
            b1 = new Book("1");
            b2 = new Book("2", "Falling in Love with Yourself");
            b3 = new Book("3", "Spirits in the Night", 123.55);
            repo.AddValuable(b1);
            repo.AddValuable(b2);
            repo.AddValuable(b3);

            a11 = new Amulet("11");
            a12 = new Amulet("12", Level.high);
            a13 = new Amulet("13", Level.low, "Capricorn");
            repo.AddValuable(a11);
            repo.AddValuable(a12);
            repo.AddValuable(a13);

            c111 = new Course("Eufori med røg");
            c112 = new Course("Nuru Massage using Chia Oil", 157);
            repo.AddValuable(c111);
            repo.AddValuable(c112);
        }

        [TestMethod]
        public void TestGetValueForBook()
        {
            Assert.AreEqual(0.0, b1.GetValue());
            Assert.AreEqual(0.0, b2.GetValue());
            Assert.AreEqual(123.55, b3.GetValue());
        }

        [TestMethod]
        public void TestGetValueForAmulet()
        {
            Assert.AreEqual(20.0, a11.GetValue());
            Assert.AreEqual(27.5, a12.GetValue());
            Assert.AreEqual(12.5, a13.GetValue());
        }

        [TestMethod]
        public void TestGetValueForCourse()
        {
            Assert.AreEqual(0.0, c111.GetValue());
            Assert.AreEqual(2475.00, c112.GetValue());
        }
    }
}
