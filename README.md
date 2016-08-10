Requirements
============

Please create a word puzzle solver, using the information loaded from the files in this repo. JSON, XML or both

1.  Using the set of rules and values implement a solution based on  [Markov Algorithm](https://en.wikipedia.org/wiki/Markov_algorithm)  to generate a word matrix for the puzzle

    -   **Cypher**: Contains a list with the strings to be solved with  Markov Algorithm \[\*\]
    -   **Rules**: Contains a list with the rules that will be used in Markov Algorithm \[\*\*\]
    -   **Values**: Contains a list which has a set of rules that must be applied to the character list, where “input” is the text that will be deciphered with Markov Algorithm and “constraints” where each node has the following values \[\*\*\*\]:
        -   **Order**: Represents the order in which the rules will be executed
        -   **Rule**: Contains the ID of the rule that has to be used \[\*\*\]
        -   **isTermination**: Whether the rule should be last one to be executed
    -   **Words**: This file contains a list of the possible Word matches inside the Word puzzle

- \[\*\] *Cypher ID* corresponds to it's position in the array from the cypher file
- \[\*\*\] *Rule ID* corresponds to it's position in the array from the rule file
- \[\*\*\*\] *Node ID* corresponds to the it's position in the array from the values file and is directly related to the Cypher ID

2.  Based on the result from the previous point design and implement an algorithm to find the provided words in the puzzle matrix using the following criteria:

    -   From left to right and viceversa

    -   From top to bottom and viceversa

    -   In any diagonal

    -   Combination of all them (Optional) \*\*

|     |       |     |
|-----|-------|-----|
| ⇖   | ⇑     | ⇗   |
| ⇐   | [**A**](#) | ⇒   |
| ⇙   | ⇓     | ⇘   |
|     |       |     |

\*\* As long as the letters are next to each other in any direction, forward or backwards the algorithm must be capable of finding the word. Ex: \[BONUS\]

|     |     |       |       |       |       |     |
|-----|-----|-------|-------|-------|-------|-----|
| A   | R   | W     | D     | I     | C     | V   |
| Q   | Z   | P     | [**O**](#) | [**U**](#) | [**S**](#) | Q   |
| R   | L   | [**B**](#) | X     | [**N**](#) | R     | L   |
| B   | T   | Y     | U     | C     | O     | X   |
|     |     |       |       |       |       |     |

For the output at least a JSON with the following format is expected, although any additional console or graphic representation will be taken into account.

```javascript
[{
    word: 'GFT',
    breakdown: [
        {
            character: 'G',
            row: 1,
            column: 2
        },
        {
            character: 'F',
            row: 1,
            column: 3
        },
        {
            character: 'T',
            row: 1,
            column: 3
        }
    ]
}]
```
