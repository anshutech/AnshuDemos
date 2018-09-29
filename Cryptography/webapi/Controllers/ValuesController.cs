using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Caching.Memory;



namespace webapi.Controllers
{



    [Route("api/[controller]")]
     public class ValuesController : Controller
     {
        // GET api/values
        private readonly IMemoryCache _cache;
        public ValuesController(IMemoryCache memoryCache)
        {
       _cache = memoryCache;
        }
        [HttpGet]
      
        public string GetChallenge(bool resetflag=false)
        {
         if(_cache.TryGetValue("chl", out string challenge))
             {
           if (challenge == "" || resetflag)
           {
           challenge = challengemaker();
             }
             
            
        }
      
        else
             {
          challenge = challengemaker();
             }
             return challenge;
        }
        public string challengemaker()
        {
            string challenge;
            Random rnd = new Random();
            int task =rnd.Next(1,1000000);
            Console.WriteLine("hash of" + task.ToString());
            challenge =  createHAsh (task.ToString());
            _cache.Set("chl", challenge, TimeSpan.FromSeconds(3000));
           
            _cache.Set("claimed", false, TimeSpan.FromSeconds(3000));
        
             _cache.Set("answer", task.ToString(), TimeSpan.FromSeconds(3000));
             _cache.Set("node", "", TimeSpan.FromSeconds(3000));
             return challenge;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string GetResult(string answer,string node)
        {     string result="No challenge thrown before";
       

             if(_cache.TryGetValue("answer", out string actual))
             {
          
            if  ( actual == answer)
            {
                if (_cache.TryGetValue("claimed",out bool claimflag))
                {
                    if (!claimflag)
                    {
                result = "Winner";
             
                  _cache.Set("claimed", true, TimeSpan.FromSeconds(3000));
                    _cache.Set("node", node, TimeSpan.FromSeconds(3000));
                }
 else
 {
     if (_cache.TryGetValue("node", out string nodename))
     {
     result = "Ah you are late, Winner is Node :- " + nodename;
     }
     else
     {
        result = "Ah you are late"; 
     }
    
 }

            }}}
            
            return result;
        }

       
private string createHAsh (string tohash)
        {
             SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(tohash);
            byte[] hash = sha512.ComputeHash(bytes);
            string y = GetStringFromHash(hash);
            return y;
        }
         private  string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2")); 
            }
            return result.ToString();
        } 

               
        

    }
}                                                                  
