using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static CardGame.Program;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputcards = new string[5];
            for (int i = 0; i < 5; i++)
            {
                inputcards[i] = Console.ReadLine();
            }
            Cards obj = new Cards();
            obj.PokerHandRankings(inputcards);
        }
        public class Cards
        {
            //assigning values of cards
            public string[] FaceCard = { "10s", "10h", "10d", "10c", "Ks", "Kh", "Kd", "Kc", "Qs", "Qh", "Qd", "Qc", "Js", "Jh", "Jd", "Jc", "As", "Ah", "Ad", "Ac" };
            public string[] FaceCardAll = { "10s", "10h", "10d", "10c", "Ks", "Kh", "Kd", "Kc", "Qs", "Qh", "Qd", "Qc", "Js", "Jh", "Jd", "Jc", "As", "Ah", "Ad", "Ac",
                                            "9s","9d","9c","9h","8s","8d","8c","8h","7s","7d","7c","7h","6s","6d","6c","6h","5s","5d","5c","5h",
                                            "4s","4d","4c","4h","3s","3d","3c","3h","2s","2d","2c","2h"};
            public string[] precedence = { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2","A"};
            public int ElseValue = 0;
            public string checking = " ";
            public void PokerHandRankings(string[] inputCards)
            {
                do
                {
                    RoyalFlush(inputCards);
                    checking ="added";
                    StraightFlush(inputCards);
                    FourOfAKind(inputCards); 
                    Flush(inputCards);
                    ThreeOfAKind(inputCards);
                    FullHOuse(inputCards);
                    TwoPair(inputCards);
                    Pair(inputCards);
                    HighCard(inputCards);
                    //Straight(inputCards);

                } while (false);


            }
            
            public bool RoyalFlush(string[] inputCards)
            {
                bool check = false;
                if (checking.Equals(" "))
                {
                    int temp = 0;
                    string first = inputCards[0];
                    char last1 = first[first.Length - 1];
                    foreach (string card in inputCards)
                    {
                        if (FaceCard.Contains(card) && card[card.Length - 1] == last1)
                        {
                            temp++;
                        }
                    }
                    if (temp == 5)
                    {
                        Console.WriteLine("Royal Flush");
                        check = true;
                    }
                    else
                    {
                        ElseValue++;
                    }
                    
                }
                return check;
            }
            public bool StraightFlush(string[] inputCards)
            {
                bool check = false;
                if (checking.Equals(" "))
                {
                    int temp = 0;
                    string first = inputCards[0];
                    char last1 = first[first.Length - 1];
                    foreach (string card in inputCards)
                    {
                        char last = card[card.Length - 1];
                        if (FaceCardAll.Contains(card) && card[card.Length - 1] == last1)
                        {
                            temp++;
                        }
                    }
                    if (temp == 5)
                    {
                        Console.WriteLine("Straight Flush");
                        check = true;
                    }
                    else
                    {
                        ElseValue++;
                    }
                }
                return check;
            }
            public bool FourOfAKind(string[] inputCards)
            {
                List<String> ar = new List<String>();
                foreach (string card in inputCards)
                {
                    if (FaceCardAll.Contains(card) && card.Length == 2)
                    {
                        string firstChar = card[0].ToString();
                        ar.Add(firstChar);
                    }
                    else if (FaceCard.Contains(card) && card.Length == 3)
                    {
                        string firstChar = card.Substring(0, 2);
                        ar.Add(firstChar);
                    }
                }
                var g = ar.GroupBy(i => i);
                int temp = 0;
                foreach (var grp in g)
                {
                    if (grp.Count() == 4)
                    {
                        Console.WriteLine("Four of a Kind");
                        temp = 1;
                    }
                }
                if (temp == 0)
                {
                    ElseValue++;
                }
                return false;
            }
            public bool FullHOuse(string[] inputCards)
            {
                List<String> ar = new List<String>();
                foreach (string card in inputCards)
                {
                    if (FaceCardAll.Contains(card) && card.Length == 2)
                    {
                        string firstChar = card[0].ToString();
                        ar.Add(firstChar);
                    }
                    else if (FaceCardAll.Contains(card) && card.Length == 3)
                    {
                        string firstChar = card.Substring(0, 2);
                        ar.Add(firstChar);
                    }
                    else
                    {

                    }
                }
                var g = ar.GroupBy(i => i);
                int temp = 0;
                foreach (var grp in g)
                {
                    if (grp.Count() == 3 )
                    {
                        temp ++;
                    }
                }
                //with a pair ==> last char comparison
                List<String> ar1 = new List<String>();
                foreach (string card in inputCards)
                {
                    if (FaceCardAll.Contains(card) && card.Length == 2)
                    {
                        string LastChar = card[1].ToString();
                        ar1.Add(LastChar);
                    }
                    else if (FaceCardAll.Contains(card) && card.Length == 3)
                    {
                        string LastChar = card.Substring(1, 2);
                        ar1.Add(LastChar);
                    }
                    else
                    {

                    }
                }
                    var g1 = ar1.GroupBy(i => i);
                    //int temp = 0;
                    foreach (var grp in g1)
                    {
                        if (grp.Count() == 2)
                        {
                            temp++;
                        }
                    }
                    if (temp == 2)
                    {
                    Console.WriteLine("Finl THree of a kind");
                    }
                else
                {
                    ElseValue++;
                }
                return false;
            }
            public bool ThreeOfAKind(string[] inputCards)
            {
                List<String> ar = new List<String>();
                foreach (string card in inputCards)
                {
                    if (FaceCardAll.Contains(card) && card.Length == 2)
                    {
                        string firstChar = card[0].ToString();
                        ar.Add(firstChar);
                    }
                    else if (FaceCardAll.Contains(card) && card.Length == 3)
                    {
                        string firstChar = card.Substring(0, 2);
                        ar.Add(firstChar);
                    }
                    else
                    {

                    }
                }
                var g = ar.GroupBy(i => i);
                int temp = 0;
                foreach (var grp in g)
                {
                    if (grp.Count() == 3)
                    {
                        temp++;
                    }
                }
                if(temp == 1)
                {
                    Console.WriteLine("THREE OF A KIND");
                }
                else
                {
                    ElseValue++;
                }
                return false;
            }
            public bool Flush(string[] inputCards)
            {
                List<String> ar1 = new List<String>();
                foreach (string card in inputCards)
                {
                    if (FaceCardAll.Contains(card) && card.Length == 2)
                    {
                        string LastChar = card[1].ToString();
                        ar1.Add(LastChar);
                    }
                    else if (FaceCardAll.Contains(card) && card.Length == 3)
                    {
                        string LastChar = card.Substring(1, 2);
                        ar1.Add(LastChar);
                    }
                    else
                    {

                    }
                }
                var g1 = ar1.GroupBy(i => i);
                int temp = 0;
                foreach (var grp in g1)
                {
                    if (grp.Count() == 2)
                    {
                        temp++;
                    }
                }
                if (temp == 5)
                {
                    Console.WriteLine("Flush");
                }
                else
                {
                    ElseValue++;
                }
                return false;
            }
            public bool TwoPair(string[] inputCards)
            {
                List<String> ar = new List<String>();
                foreach (string card in inputCards)
                {
                    if (FaceCardAll.Contains(card) && card.Length == 2)
                    {
                        string firstChar = card[0].ToString();
                        ar.Add(firstChar);
                    }
                    else if (FaceCardAll.Contains(card) && card.Length == 3)
                    {
                        string firstChar = card.Substring(0, 2);
                        ar.Add(firstChar);
                    }
                    else
                    {

                    }
                }
                var g = ar.GroupBy(i => i);
                int temp = 0;
                foreach (var grp in g)
                {
                    if (grp.Count() == 2)
                    {
                        temp++;
                    }
                }
                if (temp == 2)
                {
                    Console.WriteLine("it is two pair");
                }
                else
                {
                    ElseValue++;
                }
                return false;
            }
            public bool Pair(string[] inputCards)
            {
                List<String> ar = new List<String>();
                foreach (string card in inputCards)
                {
                    if (FaceCardAll.Contains(card) && card.Length == 2)
                    {
                        string firstChar = card[0].ToString();
                        ar.Add(firstChar);
                    }
                    else if (FaceCardAll.Contains(card) && card.Length == 3)
                    {
                        string firstChar = card.Substring(0, 2);
                        ar.Add(firstChar);
                    }
                    else
                    {

                    }
                }
                var g = ar.GroupBy(i => i);
                int temp = 0;
                foreach (var grp in g)
                {
                    if (grp.Count() == 2)
                    {
                        temp++;
                    }
                }
                if (temp == 1)
                {
                    Console.WriteLine("it is pair");
                }
                else
                {
                    ElseValue++;
                }
                return false;
            }
            public bool Straight(string[] inputCards)
            {
                List<String> ar = new List<String>();
                foreach (string card in inputCards)
                {
                    if (FaceCardAll.Contains(card) && card.Length == 2)
                    {
                        string firstChar = card[0].ToString();
                        ar.Add(firstChar);
                    }
                    else if (FaceCard.Contains(card) && card.Length == 3)
                    {
                        string firstChar = card.Substring(0, 2);
                        ar.Add(firstChar);
                    }
                }
                
                /*var g = ar.GroupBy(i => i);
                int temp = 0;
                var min = ar.Min();
                var max = ar.Max();
                var all = Enumerable.Range(min, diff + 1);
                return ar.SequenceEqual(all);*/
                /*foreach (var grp in g)
                {
                    if (grp.Count() == 4)
                    {
                        Console.WriteLine("Four of a Kind");
                        temp = 1;
                    }
                }*/
                return false;
            }
            
            public bool HighCard(string[] inputCards)
            {
                
                if(ElseValue == 7)
                {
                    Console.WriteLine("High Card");
                }
                return false;
            }
        }
    }
}
        
    
