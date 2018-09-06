using SimCorp_sSmartWordCounter;
using System;
using System.Collections.Generic;
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
        //Xunit has a Fetaure Which allows us to create parameterised tests
        //This Theory attribute denotes a parameterised Test
        //We can pass multiple parameters by using inline data attribute as you can see below,
        // Based on the number of inline data attributes and its values, xunit automatically creates a test case.
        [Theory]
        [InlineData(@"C:\Users\DB.EV-ECOMMERCE\source\repos\SimCorp'sSmartWordCounter\WhySimCorp.txt")]
        [InlineData(@"C:\Temp\SimCorps_UserStory.txt")]
        public void Test_GetWordCountOccurences(string pPath)
        {
            try
            {
                //Arrange
                Dictionary<string, int> lWordCount = new Dictionary<string, int>();
                //Act
                var lCount = WordCountDetails.GetWordCountOccurrences(pPath);
                foreach (KeyValuePair<string, int> words in lCount)
                {
                    //all the output results can be found in the Test result explorer by clicking OutPut button.
                    output.WriteLine("Name of the Word:  " + words.Key.ToUpper() +Environment.NewLine+ "No of Occurences: " + words.Value);
                    output.WriteLine("--------------------------------------------------------------");
                }
                //Assert
                Assert.True(true);

            }
            catch (Exception e)
            {
                output.WriteLine(e.Message);
                Assert.False(true);
            }
        }

    }
}
