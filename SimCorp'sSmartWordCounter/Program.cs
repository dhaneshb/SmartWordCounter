using System;
using System.Collections.Generic;
using System.IO;
namespace SimCorp_sSmartWordCounter
{
    public class WordCountDetails
    {
        private static readonly char[] separators = { ' ' };
        static void Main(string[] args)
        {
            //Change  the values with your file location
            string lTextfile = Environment.CurrentDirectory+ "\\WhySimCorp.txt";
            var lCount= GetWordCountOccurrences(lTextfile);
            foreach (KeyValuePair<string, int> words in lCount)
            {
                Console.WriteLine("Name of the Word:  " + words.Key.ToUpper() + Environment.NewLine + "No of Occurences: " + words.Value);
                Console.WriteLine("--------------------------------------------------------------");
            }
            Console.Read();
        }
        /// <summary>  
        /// To Get the number of Occurrences of every word from a text file.
        /// </summary>  
        /// <param name="filepath"></param>  
        public static IDictionary<string, int> GetWordCountOccurrences(string filepath)
        {
            var lwordOccurrences = new Dictionary<string, int>();
            try
            {
                #region ReadValuesFromFilepathLocation
                using (var fileStream = File.Open(filepath, FileMode.Open, FileAccess.Read))
                using (var streamReader = new StreamReader(fileStream))
                {
                    #endregion
                    string ltextfromFile;
                    while ((ltextfromFile = streamReader.ReadLine()) != null)
                    {
                        #region Words after splitting from the text
                        var Words = ltextfromFile.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        #endregion
                        #region Looping through every work to check the word Occurrences
                        foreach (var word in Words)
                        {
                            if (lwordOccurrences.ContainsKey(word))
                            {
                                lwordOccurrences[word] = lwordOccurrences[word] + 1;
                            }
                            else
                            {
                                lwordOccurrences.Add(word, 1);
                            }
                        }
                        #endregion
                    }
                }
            }
            catch (FileNotFoundException Fex)
            {
                Console.WriteLine("Could not find the file in: " + filepath);
                Console.WriteLine("Solution: Verify that the file exists in the provided path.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #region Word's and its occurences
            return lwordOccurrences;
            #endregion
        }
    }
}
