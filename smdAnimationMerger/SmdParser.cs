using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace smdAnimationMerger
{
    class SmdParser
    {
        private String[] m_files;
        private String m_outFilePath;
        private LinkedList<String> m_outData =  new LinkedList<string>();
        private int m_offset = 0; // offset used for timecodes


        public SmdParser(String[] files, String outFilePath)
        {
            m_files = files;
            m_outFilePath = outFilePath;
        }

        public void doParse()
        {
            bool firstFile = true;
            foreach (String filePath in m_files)
            {
                String line;
                int endTime = 0;
                StreamReader file = new StreamReader(filePath);
                bool timeSectionFound = false;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("time"))
                    {
                        String[] subString = line.Split(' ');
                        if (subString.Length == 2)
                        {
                            int time = Convert.ToInt32(subString[1]);
                            endTime = time + m_offset; // stores the last time value read in

                            // Create the new time line
                            line = "time " + endTime; 
                        }
                        else
                        {
                            throw new Exception("Unexpected format of smd file. Things are not where they should be!");
                        }
                        timeSectionFound = true;
                    }
                    else if (firstFile && line.Contains("skeleton"))
                    {
                        m_outData.AddLast("end"); // closes to preamble
                    }
                    if ((firstFile || timeSectionFound) && !line.Contains("end"))
                    {
                        m_outData.AddLast(line);
                    }
                }
                file.Close();
                firstFile = false;
                m_offset = endTime + 1;
            }
            m_outData.AddLast("end");

            StreamWriter writter = new StreamWriter(m_outFilePath);
            foreach (String line in m_outData)
            {
                writter.WriteLine(line);
            }
            writter.Close();
        }
    }
}
