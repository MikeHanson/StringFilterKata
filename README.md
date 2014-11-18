StringFilterKata
================

As a technical test for a contract role I was put forward for I was given the following assignment.  This repository contains the code I came up with as I investigate the best solution to the problem.

Write some code in c# that can filter a list of strings.  Only six letter strings that are composed of two concatenated smaller strings (that are also in the list) should pass through the filter.

For example, given the list 

al, albums, aver, bar, barely, be, befoul, bums, by, cat, con, convex, ely, foul, here, hereby, jig, jigsaw, or, saw, tail, tailor, vex, we, weaver

The program should return 

albums, barely, befoul, convex, hereby, jigsaw, tailor, weaver

Because these are a concatenation of two other strings:

al + bums => albums
bar + ely => barely
be + foul => befoul
con + vex => convex
here + by => hereby
jig + saw => jigsaw
tail + or => tailor
we + aver => weaver

Use of TDD techniques or Unit Testing is required.   Please comment your code with any relevant information about what is good or bad about your solution – trade-offs etc.

