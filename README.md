# PokerCardGame
In this challenge, you have to establish which kind of Poker combination is 
present in a deck of five cards. 
Every card is a string containing the card value 
(with the upper-case initial for face-cards) 
and the lower-case initial for suits, as in the examples below:

<ul>
<li>"Ah" ➞ Ace of hearts</li>
<li>"Ks" ➞ King of spades</li>
<li>"3d" ➞ Three of diamonds</li>
<li>"Qc" ➞ Queen of clubs</li>
<li>"10c" ➞ Ten of clubs</li>
There are 10 different combinations. Here's the list, in decreasing order of importance:
</ul>

Name	Description
Royal Flush	A, K, Q, J, 10, all with the same suit.
Straight Flush	Five cards in sequence, all with the same suit.
Four of a Kind	Four cards of the same rank.
Full House	Three of a Kind with a Pair.
Flush	        Any five cards of the same suit, not in sequence.
Straight	Five cards in a sequence, but not of the same suit.
Three of a Kind	Three cards of the same rank.
Two Pair	Two different Pair.
Pair	        Two cards of the same rank.
High Card	No other valid combination.
Given an array hand containing five strings being the cards,
implement a function that returns a string with the name of the highest combination obtained, accordingly to the table above.

Examples
PokerHandRanking({ "10h", "Jh", "Qh", "Ah", "Kh" }) ➞ "Royal Flush"

PokerHandRanking({ "3h", "5h", "Qs", "9h", "Ad" }) ➞ "High Card"

PokerHandRanking({ "10s", "10c", "8d", "10d", "10h" }) ➞ "Four of a Kind"
