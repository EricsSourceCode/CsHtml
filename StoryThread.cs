/*

Can this do a thread for reading each story 
file?  How do I get the one story back
from that separate thread?

How do I pass it the file name to read and
other parameters?

using System.Threading;
https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread?view=net-8.0

2 or 3 threads going?
URLFileDct.readAllStories(
                     StoryDct storyDct,
                     WordDct paragDct )


using System;
using System.Threading;

public class ThreadWork
{
   public static void DoWork()
   {
      for(int i = 0; i<3;i++) {
         Console.WriteLine("Working thread...");
         Thread.Sleep(100);
      }
   }
}
class ThreadTest
{
   public static void Main()
   {
      Thread thread1 = new Thread(ThreadWork.DoWork);
      thread1.Start();
      for (int i = 0; i<3; i++) {
         Console.WriteLine("In main.");
         Thread.Sleep(100);
      }
   }
}
// The example displays output like the following:
//       In main.
//       Working thread...
//       In main.
//       Working thread...
//       In main.
//       Working thread...


*/

