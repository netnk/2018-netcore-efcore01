using System;
using System.Collections.Generic;
using ef_test.Models;

namespace ef_test {
    class Program {
        static void Main (string[] args) {

            Console.WriteLine ("Selected: 1/ADD 2/Query");
            int i = Convert.ToInt32(Console.ReadLine ());
            switch (i) {
                case 1:
                    {
                        using (var context = new lolscoreContext ()) {
                            string datetime = DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss");
                            DateTime dtnew = Convert.ToDateTime (datetime);

                            Team team1 = new Team ();
                            team1.Team02 = "100";
                            team1.Team03 = "1";
                            team1.Team04 = dtnew;

                            context.Add (team1);
                            context.SaveChanges ();
                        }
                        break;

                    }
                case 2:
                    {
                        using (var context = new lolscoreContext ()) 
                        {

                            foreach (var item in context.Team) 
                            {
                                Console.WriteLine (item.Team01.ToString() + ", " + item.Team02 + ", " + item.Team03 + ", " + item.Team04);
                                
                            }

                        }
                        break;

                    }
            }

        }
    }
}