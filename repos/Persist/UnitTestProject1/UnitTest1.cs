using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persist;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public string fileName;
        StreamReader reader = null;
        List<CD> cds = new List<CD>();
        CD cd;
        [TestInitialize]
        public void SetUp()
        {
            fileName = "datafile.txt";
            StreamWriter writer = null;
            try
            {
                FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(stream);
                writer.Write("###");
                writer.Write("Examples of good music");
                writer.WriteLine("Sgt. Pepper's Lonely Hearts Club Band, 1967, The Beatles, 40, +");
                writer.WriteLine("Are you Experienced, 1967, Jimi Hendrix, 40, -");
                writer.WriteLine("Abbey Road, 1969, The Beatles, 47, +");
                writer.WriteLine("Revolver, 1966, The Beatles, 35, +");
                writer.WriteLine("Pet Sounds, 1966, The Beach Boys,35,  -");
                writer.WriteLine("Highway 61 Revisited, 1965, Bob Dylan, 51, -");
                writer.WriteLine("The Dark Side of the Moon, 1973, Pink Floyd, 42, +");
            }
            catch (IOException e)
            {
                Console.WriteLine("I/O Error occurred: " + e.Message);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        [TestMethod]
        public void TestReadFile()
        {
            try
            {
                ReadCDFile(ref reader);
            }
            catch (IOException e)
            {
                Console.WriteLine("I/O Error occurred: " + e.Message);
            }
            finally
            {
                reader.Close();
            }
            Assert.AreEqual(40, cds[0].PlayingTime);
            Assert.AreEqual(1973, cds[6].YearReleased);
        }

        private List<CD> ReadCDFile(ref StreamReader reader)
        {
            List<CD> result = new List<CD>();
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
            while (reader.Peek() != -1) //Continue until end of file
            {
                string line = reader.ReadLine(); //read a line from the file
                string[] fields = line.Split(',');//split the line into fields using a comma as delimiter
                string title = fields[0];
                int year = int.Parse(fields[1]);
                string artist = fields[2];
                int time = int.Parse(fields[3]);
                cd = new CD(title, time, year, artist); //create the CD object
                result.Add(cd); //add to list of CDs
            }
            return result;

        }

        [TestMethod]
        public void TestAddCD()
        {
            reader = null;
            CD cd = new CD("Willy and the Poor Poys", 34, 1969, "Credence Clearwater Revival");
            StreamWriter writer = null;
            try
            {
                FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(stream);
                writer.WriteLine(cd.Title + "," + cd.YearReleased + "," + cd.Artist + "," + cd.PlayingTime + "+");
                writer.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("I/O Error occurred: " + e.Message);
                Assert.Fail(e.Message);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            List<CD> cds = ReadCDFile(ref reader);
            Assert.AreEqual(34, cds[cds.Count - 1].PlayingTime);
        }
    }
}
