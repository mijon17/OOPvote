using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestForAssessment1
{
    // A Class that will hold the information for each party
    class Party
    {
        // Private declarations of party details

        private string partyName;
        private List<string> partyCandidates = new List<string>();

        private int partyVotes;
        private int partySeats;

        // This will allow the programmer to access and modify the values in each party
        public string Name
        {
            get
            {
                return partyName;
            }

            set
            {
                partyName = value;
            }
        }

        public List<string> Candidates
        {
            get
            {
                return partyCandidates;
            }

            set
            {
                partyCandidates = value;
            }
        }

        public int Votes
        {
            get
            {
                return partyVotes;
            }

            set
            {
                partyVotes = value;
            }
        }

        public int Seats
        {
            get
            {
                return partySeats;
            }

            set
            {
                partySeats = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Finds the location of the 'assessmentData.txt' 
            // Reads the file to get the data
            string dataPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "AssessmentData.txt");
            string[] partyLines = System.IO.File.ReadAllLines(dataPath);

            // Creates a list to contain the parties information
            List<string> seperatedLines = new List<string>();

            // For loop,
            // Starts at the index of 3, where the first party is held,
            // Loops over until value of 'i' is equal to the length of the list
            for (int i = 3; i < partyLines.Length; i++)
            {
                seperatedLines.Add(partyLines[i]);
            }

            // Creates a new list for the parties to be stored in
            List<Party> parties = new List<Party>();

            // Manually create parties
            // I didn't have the time nor knowledge to do this automatically
            Party BrexitParty = new Party();
            Party LiberalDemocrats = new Party();
            Party Labour = new Party();
            Party Conservatives = new Party();
            Party Green = new Party();
            Party UKIP = new Party();
            Party ChangeUK = new Party();
            Party IndependentNetwork = new Party();
            Party Independent = new Party();

            // Adds the parties into a list
            parties.Add(BrexitParty);
            parties.Add(LiberalDemocrats);
            parties.Add(Labour);
            parties.Add(Conservatives);
            parties.Add(Green);
            parties.Add(UKIP);
            parties.Add(ChangeUK);
            parties.Add(IndependentNetwork);
            parties.Add(Independent);

            // For loop,
            // Loops over for the number of parties in the list
            for (int i = 0; i < parties.Count; i++)
            {
                // Creates a string array
                // String array will hold the party details split by the comma to extract the needed data
                string[] newLine = seperatedLines[i].Split(",");

                // Assigns the party details from 'newLine' into the party list
                parties[i].Name = newLine[0];
                parties[i].Votes = int.Parse(newLine[1]);

                // For loop,
                // Loops over the candidates in the array
                // 'j' starts at index 2 where the first candidate is located, carries on until it reaches the max lenght of array
                for (int j = 2; j < newLine.Length; j++)
                {
                    // Adds the candidate to the
                    parties[i].Candidates.Add(newLine[j]);
                }

                // This here is just a debug method
                // Used this to see whether the values are assigned corretly
                //Console.WriteLine(parties[i].Name);
                //Console.WriteLine(parties[i].Votes);
                //foreach (string candidate in parties[i].Candidates)
                //{
                //    Console.WriteLine(candidate);
                //}

            }

            // Parses the string into an int
            // Gets the number of seats
            int numOfSeats = int.Parse(partyLines[1]);

            // Calls function
            Calculator(parties, numOfSeats);
        }

        static void Calculator(List<Party> parties, int numOfSeats)
        {
            //Console.WriteLine("Calculator called");

            // For loop
            // Creates a loop that goes through the number of seats that were passed through
            for (int i = 0; i < numOfSeats; i++)
            {
                // Creates a new List with each new iteration
                List<int> partiesVotes = new List<int>();

                // For loop
                // Goes through every party in the list
                for (int j = 0; j < parties.Count; ++j)
                {
                    // Adds the parties vote into the list
                    partiesVotes.Add(parties[j].Votes);
                }

                // declares highestVote to max value among votes
                int highestVote = partiesVotes.Max();

                // This block was used to test against all the votes manually
                //for(int k = 0; k < partiesVotes.Count; k++)
                //{
                //    Console.WriteLine(partiesVotes[k]);
                //}
                //Console.WriteLine("break");
                
                // For loop
                // Loops for the length of parties
                for(int l = 0; l < parties.Count; l++)
                {
                    // Compares party vote against the highestVote to find the winning party
                    if(parties[l].Votes == highestVote)
                    {
                        // Adds a seat to the party
                        // Divides the parties votes by the formula
                        parties[l].Seats += 1;
                        parties[l].Votes = parties[l].Votes / (1 + parties[l].Seats);
                        break;
                    }
                }

            }

            // For loop
            // Goes through the number of parties
            for(int i = 0; i < parties.Count; i++)
            {
                // Checks which party has seats
                if(parties[i].Seats != 0)
                {
                    // Displays the name of the party with seats
                    Console.WriteLine(parties[i].Name);

                    // Goes through the number of candidates
                    for(int j = 0; j < parties[i].Seats; j++)
                    {
                        // Displays the candidates that were elected
                        Console.WriteLine(parties[i].Candidates[j]);
                    }
                }
            }
        }
    }
}