Instructions
============

* You are expected to come up with a solution for at least 2 different problems using the files provided in this repository.
* Functionality, design and implementation of the solution will be evaluated.
* Use any of the available files (JSON, XML or both) as your source.
* HR will provide further instructions in which language to use, as well as additional details.
* Minimal requirements for the output of each exercise are expected, feel free to add any additional console or graphic representation you consider might be useful

Exercises
=========

1. **Markov Algorithm** [*Required*]

  Implement a solution of Markov's Algorithm that generates a word matrix using a set of rules and values given by the following files:

  cypher: Constains a list strings (size N) that need to be decyphered
  base: Contains a list (size M) with the base rules that will be used in Markov's algorithm.
  values: Contains a list of objects (size N), in which one each node has the following form:
    order: Determines the order in which one the rules should be executed
    rule: Determines the index of the rule in "base" list
    isTermination: Determines wether the execution should continue or be halted

  Using base and values please generate a rule sequence which will be used to solve the cypher using your Markov implementation.

  For the ***output*** a word matrix print is expected

  ===
2. **Word Puzzle** [*Required*]

  Please create a custom implementation as a puzzle solver using the following statements:

  * Use the output of the exercise #1 as the word matrix
  * Use the file named 'words' as the possible matches, taking into account that not all words have a match in the puzzle

  Using the previous information please craft a solution that can search words in many ways as posible of the following directions:

  * From left to right and viceversa
  * From top to bottom and viceversa
  * In any diagonal

  ===
    *Example*:

  |     |       |     |
  |-----|-------|-----|
  | ⇖   | ⇑     | ⇗   |
  | ⇐   | [**A**](#) | ⇒   |
  | ⇙   | ⇓     | ⇘   |
  |     |       |     |

  For the ***output*** at least a JSON with the following format is expected:

  ===
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
  ===
3. **Complex Search** [*Optional*]

  As a BONUS exercise you are expected to add an additional case to the word search, which comes as follow:

  * As long as the letters are next to each other in any direction, forward or backwards the algorithm must be capable of finding the word

  ===
  *Example*:

  |     |     |       |       |       |       |     |
  |-----|-----|-------|-------|-------|-------|-----|
  | A   | R   | W     | D     | I     | C     | V   |
  | Q   | Z   | P     | [**O**](#) | [**U**](#) | [**S**](#) | Q   |
  | R   | L   | [**B**](#) | X     | [**N**](#) | R     | L   |
  | B   | T   | Y     | U     | C     | O     | X   |
  |     |     |       |       |       |       |     |
