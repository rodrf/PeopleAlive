using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeoopleAlive
{
    class AliveCount
    {
        public void countPeopleAlive(string jsonData) {
            
            int[] totalCountAlive; 
            List<int> totalBirth = new List<int>();
            List<int> totalDeath = new List<int>();
            List<int> totalLineYears = new List<int>();
          
            try
            {
                //1.- Deserialize Json
                var list = Newtonsoft.Json.JsonConvert.DeserializeObject<People>(jsonData);
                //2.- Obtain the total of births and deaths
                foreach (Data p in list.data) {
                    totalBirth.Add(p.birthYear);
                    totalDeath.Add(p.deathYear);
                }
                //3.- Get min and max year
                var minBirthYear = totalBirth.Min(min => min);
                var maxDeathYear = totalDeath.Max(max => max);
                //4.- List all the years involved
                for (int x = minBirthYear; x <= maxDeathYear; x++) {
                    totalLineYears.Add(x);
                }
                totalCountAlive = new int[maxDeathYear+1];
                //Only for a better viewing
                totalLineYears.Sort();
                //5.- Iterate the list of live people to add to the years
                foreach (Data livePeople in list.data) {
                    var start = livePeople.birthYear;
                    while (start <= livePeople.deathYear) {
                        totalCountAlive[start] = totalCountAlive[start] + 1;
                        start++;
                    }
                }
                //6.- Print the total of years with their sum 
                foreach (int anio in totalLineYears) {
                    Console.WriteLine("Anio: {0} | Personas vivas: {1} {2}", anio, totalCountAlive[anio], totalCountAlive[anio]==1 ? "persona." : "personas.");
                }        
                //7.- Finally, we get the max number of people alive and print the result.
                var mayor = totalCountAlive.Max();
                var anioo = Array.IndexOf(totalCountAlive, mayor);
                Console.WriteLine("\nEl anio con más personas vivas es: {0}, con un total de: {1} {2}", anioo,mayor,(mayor == 1) ? "persona." : "personas.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
            }

    }

    }
}
