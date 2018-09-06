using SimCorp_sSmartWordCounter;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace SmartWordCounter.Tests
{
    public class WordCount
    {
        private  readonly ITestOutputHelper output;
        public  WordCount(ITestOutputHelper output)
        {
            this.output = output;
        }
        //Xunit has a Fetaure called Theory Which allows us to create parameterised tests
        //This Theory attribute denotes a parameterised Test
        //We can pass multiple parameters by using inline data attribute as you can see below,
        // Based on the number of inline data attributes and its values, xunit automatically creates a test case.
        [Theory]
        //Change  the values with your file location
        [InlineData(@"C:\Users\DB.EV-ECOMMERCE\source\repos\SimCorp'sSmartWordCounter\WhySimCorp.txt")]
        [InlineData(@"C:\Temp\SimCorps_UserStory.txt")]
        public void Test_GetWordCountOccurences(string filepath)
        {
            try
            {
                //Arrange
                Dictionary<string, int> lWordCount = new Dictionary<string, int>();
                //Act
                if (File.Exists(filepath))
                    {
                    var lCount = WordCountDetails.GetWordCountOccurrences(filepath);
                    foreach (KeyValuePair<string, int> words in lCount)
                    {
                        //all the output results can be found in the Test result explorer by clicking OutPut button.
                        output.WriteLine("Name of the Word:  " + words.Key.ToUpper() + Environment.NewLine + "No of Occurences: " + words.Value);
                        output.WriteLine("--------------------------------------------------------------");
                    }
                    //Assert
                    Assert.True(true);
                }
                else
                    throw new FileNotFoundException();

            }
            catch (FileNotFoundException Fex)
            {
                output.WriteLine("Could not find the file in: "+filepath);
                output.WriteLine("Solution: Verify that the file exists in the provided path.");
                Assert.False(true);
            }
            catch (Exception ex)
            {
                output.WriteLine(ex.Message);
                Assert.True(false);
            }
        }

    }
}
