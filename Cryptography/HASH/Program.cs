using  System;
using  System.Security.Cryptography;
using System.Text;
using System.Timers;
using System.Threading;


namespace HASH
{
    class Program
    {
         
 
         static string challenge = "";
         static string url = " http://240589d2.ngrok.io/api/values";
         static string node = "BondMan"+ DateTime.Now.Minute.ToString()+ DateTime.Now.Second.ToString();
        static void Main(string[] args)
        {
         Console.WriteLine("Hello I am Player  "+ node );
         challenge =  getChallenge();
         playgame();
        }  
          static string getChallenge()
        {
      
             string challenge = callrestapi.CallRestMethod(url);
             Console.WriteLine(challenge);
             return challenge;
        }

        static void playgame()
        {
            Console.WriteLine("### Timer Started ###");

            DateTime nowTime = DateTime.Now;
            DateTime scheduledTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute, 0, 0); //Specify your scheduled time HH,MM,SS [8am and 42 minutes]
          
            scheduledTime = scheduledTime.AddMinutes(1);
            Console.WriteLine("scheduled to execute @ "+  scheduledTime);
           
           
            int tickTime = (int)(scheduledTime - DateTime.Now).TotalMilliseconds;
            Console.WriteLine("Seconds to Start : " + (tickTime / 1000).ToString());
            Thread.Sleep(tickTime);
            Console.WriteLine("### Hash game started exactly @" +  DateTime.Now.ToString() + "@### \n\n");
           
             string answer = solvechallenge(challenge);
             string result = submitchallenge(answer);
        }
       
      
        static string submitchallenge(string number)
        {
             string result = callrestapi.CallRestMethod(url+ "/1?answer=" + number + "&node="+node);
             Console.WriteLine(result);
             return result;
        }
         private static string  solvechallenge(string challenge)
        {
            DateTime start = System.DateTime.Now;
            bool found =false;
            Console.WriteLine("starting mining to find "+ challenge);

            string answer = "";
            while(!found)
            {
              Random rnd = new Random();
            int intchallenge = rnd.Next(1,1000000);
            
            if (createHAsh(intchallenge.ToString()) == challenge)
            {
            Console.WriteLine("found");
            answer = intchallenge.ToString();
            found = true;
            }

            }
               Console.WriteLine("ended mining and the answer is " + answer);
               DateTime   end = System.DateTime.Now;
               TimeSpan span = end.Subtract(start);
               Console.WriteLine("time taken " + span.Seconds.ToString() + "second");
               return answer;
        }
        
        private static string createHAsh (string tohash)
        {
             SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(tohash);
            byte[] hash = sha512.ComputeHash(bytes);
            string y = GetStringFromHash(hash);
            return y;
        }
        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result  =  new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

       

    }
}
